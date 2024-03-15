using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RimWorld;
using Verse;

namespace Z_MoreAlerts
{
    public class Alert_AnimalHypothermia : Alert
    {
        private List<Pawn> hypothermicAnimalsResult = new List<Pawn>();

        private List<Pawn> HypothermicAnimals
        {
            get
            {
                this.hypothermicAnimalsResult.Clear();
                List<Pawn> allMaps_Spawned = PawnsFinder.AllMaps_Spawned.ToList();
                for (int i = 0; i < allMaps_Spawned.Count; i++)
                {
                    if (allMaps_Spawned[i].RaceProps.Animal && allMaps_Spawned[i].Faction == Faction.OfPlayer && allMaps_Spawned[i].health.hediffSet.GetFirstHediffOfDef(HediffDefOf.Hypothermia, false)?.CurStageIndex >= 2)
                    {
                        this.hypothermicAnimalsResult.Add(allMaps_Spawned[i]);
                    }
                }
                return this.hypothermicAnimalsResult;
            }
        }

        public override string GetLabel()
        {
            return "AlertAnimalHypothermia".Translate();
        }

        public override TaggedString GetExplanation()
        {
            return "AlertAnimalHypothermiaDesc".Translate();
        }

        public override AlertReport GetReport()
        {
            if (!ExtraAlertSettings.cb_animalHypothermia)
            {
                return AlertReport.Inactive;
            }
            return AlertReport.CulpritsAre(this.HypothermicAnimals);
        }
    }
}
