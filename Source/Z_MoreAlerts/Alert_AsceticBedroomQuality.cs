using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RimWorld;
using Verse;

namespace Z_MoreAlerts
{
    public class Alert_AsceticBedroomQuality : Alert
    {
        public Alert_AsceticBedroomQuality()
        {
            this.defaultLabel = "AsceticBedroomQuality".Translate();
            this.defaultExplanation = "AsceticBedroomQualityDesc".Translate();
            this.defaultPriority = AlertPriority.Medium;
        }

        public override AlertReport GetReport()
        {
            return AlertReport.CulpritsAre(this.AffectedPawns());
        }

        private static List<Thought> tmpThoughts = new List<Thought>();

        private IEnumerable<Pawn> AffectedPawns()
        {
            foreach (Pawn p in PawnsFinder.AllMapsCaravansAndTravelingTransportPods_Alive_FreeColonists_NoCryptosleep)
            {
                if (p.Dead)
                {
                    Log.Error("Dead pawn in PawnsFinder.AllMapsCaravansAndTravelingTransportPods_Alive_FreeColonists:" + p, false);
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

    //public class Alert_AsceticBedroomQuality : Alert_Thought
    //{
    //    protected override ThoughtDef Thought
    //    {
    //        get
    //        {
    //            //ThoughtState.ActiveAtStage
    //            return MoreAlertsDefOf.Ascetic;
    //        }
    //    }

    //    public Alert_AsceticBedroomQuality()
    //    {
    //        this.defaultLabel = "AsceticBedroomQuality".Translate();
    //        this.explanationKey = "AsceticBedroomQualityDesc";
    //    }
    //}
}