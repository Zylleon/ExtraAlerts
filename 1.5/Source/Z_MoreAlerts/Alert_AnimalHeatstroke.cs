using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RimWorld;
using Verse;

namespace Z_MoreAlerts
{
    public class Alert_AnimalHeatstroke : Alert
    {
        private List<Pawn> heatstrokeAnimalsResult = new List<Pawn>();

        private List<Pawn> HeatstrokeAnimals
        {
            get
            {
                this.heatstrokeAnimalsResult.Clear();
                List<Pawn> allMaps_Spawned = PawnsFinder.AllMaps_Spawned.ToList();
                for (int i = 0; i < allMaps_Spawned.Count; i++)
                {
                    if (allMaps_Spawned[i].RaceProps.Animal && allMaps_Spawned[i].Faction == Faction.OfPlayer && allMaps_Spawned[i].health.hediffSet.GetFirstHediffOfDef(HediffDefOf.Heatstroke, false)?.CurStageIndex >= 2)
                    {
                        this.heatstrokeAnimalsResult.Add(allMaps_Spawned[i]);
                    }
                }
                return this.heatstrokeAnimalsResult;
            }
        }

        public override string GetLabel()
        {
            return "AlertAnimalHeatstroke".Translate();
        }

        public override TaggedString GetExplanation()
        {
            return "AlertAnimalHeatstrokeDesc".Translate();
        }

        public override AlertReport GetReport()
        {
            if (!ExtraAlertSettings.cb_animalHeatstroke)
            {
                return AlertReport.Inactive;
            }
            return AlertReport.CulpritsAre(this.HeatstrokeAnimals);
        }
    }
}
