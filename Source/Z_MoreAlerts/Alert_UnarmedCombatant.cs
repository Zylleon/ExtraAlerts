using RimWorld;
using System.Collections.Generic;
using System.Text;
using Verse;

namespace Z_MoreAlerts
{
    public class Alert_UnarmedCombatant : Alert
    {
        private List<Pawn> unarmedCombatants = new List<Pawn>();

        private List<Pawn> UnarmedCombatants
        {
            get
            {
                unarmedCombatants.Clear();
                foreach (Pawn p in PawnsFinder.AllMaps_FreeColonistsSpawned)
                {
                    if (p.equipment.Primary == null && !p.WorkTagIsDisabled(WorkTags.Violent) && !p.Downed && p.health.capacities.CapableOf(PawnCapacityDefOf.Manipulation))
                    {
                        unarmedCombatants.Add(p);
                    }
                }

                if(!ExtraAlertSettings.cb_childCombatant)
                {
                    unarmedCombatants.RemoveAll(c => c.DevelopmentalStage.Juvenile());
                }


                return unarmedCombatants;
            }
        }

        public override string GetLabel()
        {
            return "AlertUnarmedCombatant".Translate();
        }

        public override TaggedString GetExplanation()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (Pawn current in unarmedCombatants)
            {
                stringBuilder.AppendLine("    " + current.NameShortColored.Resolve());
            }
            return string.Format("AlertUnarmedCombatantDesc".Translate(), stringBuilder.ToString());
        }

        public override AlertReport GetReport()
        {
            if (!ExtraAlertSettings.cb_unarmedCombatant)
            {
                return AlertReport.Inactive;
            }
            return AlertReport.CulpritsAre(UnarmedCombatants);
        }

    }
}
