using System.Collections.Generic;
using System.Linq;
using RimWorld;
using Verse;

namespace Z_MoreAlerts
{
    public class Alert_AsceticBedroomQuality : Alert
    {
        private readonly List<Pawn> affectedPawns = new List<Pawn>();

        public Alert_AsceticBedroomQuality()
        {
            this.defaultLabel = "AlertAsceticBedroomQuality".Translate();
            this.defaultExplanation = "AlertAsceticBedroomQualityDesc".Translate();
            this.defaultPriority = AlertPriority.Medium;
        }

        public override AlertReport GetReport()
        {
            if (!ExtraAlertSettings.cb_asceticBedroom)
            {
                return AlertReport.Inactive;
            }
            return AlertReport.CulpritsAre(this.AffectedPawns());
        }

        private static List<Thought> tmpThoughts = new List<Thought>();

        private List<Pawn> AffectedPawns()
        {
            affectedPawns.Clear();

            foreach (Pawn p in PawnsFinder.AllMapsCaravansAndTravellingTransporters_Alive_FreeColonists_NoCryptosleep)
            {
                if (p.Dead)
                {
                    Log.Error("Dead pawn in PawnsFinder.AllMapsCaravansAndTravelingTransportPods_Alive_FreeColonists:" + p);
                }
                else
                {
                    p.needs.mood.thoughts.GetAllMoodThoughts(Alert_AsceticBedroomQuality.tmpThoughts);
                    try
                    {
                        ThoughtDef requiredDef = MoreAlertsDefOf.Ascetic;
                        for (int i = 0; i < Alert_AsceticBedroomQuality.tmpThoughts.Count; i++)
                        {
                            if (Alert_AsceticBedroomQuality.tmpThoughts[i].def == requiredDef)
                            {
                                if (tmpThoughts[i].CurStageIndex >= 5)
                                {
                                    affectedPawns.Add(p);
                                }
                            }
                        }
                    }

                    finally
                    {
                        //base.__Finally0();
                    }
                }
            }

            return affectedPawns;
        }
    }
}