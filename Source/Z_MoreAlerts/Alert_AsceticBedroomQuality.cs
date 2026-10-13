using System.Collections.Generic;
using System.Linq;
using RimWorld;
using Verse;

namespace Z_MoreAlerts
{
    public class Alert_AsceticBedroomQuality : Alert
    {
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
            return AlertReport.CulpritsAre(this.AffectedPawns().ToList());
        }

        private static List<Thought> tmpThoughts = new List<Thought>();

        private IEnumerable<Pawn> AffectedPawns()
        {
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
                                if(tmpThoughts[i].CurStageIndex >= 5)
                                {
                                    yield return p;
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
        }
    }
}