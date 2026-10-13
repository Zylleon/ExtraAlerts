using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;
using RimWorld;
using UnityEngine;

namespace Z_MoreAlerts
{
    public class Alert_EntitiesDowned : Alert_SemiCritical
    {
        private IEnumerable<Pawn> EntitiesDowned
        {
            get
            {
                //foreach (Pawn p in PawnsFinder.AllMaps_Spawned.Where(p => p.RaceProps.IsAnomalyEntity && p.HostileTo(Faction.OfPlayer)))
                foreach (Pawn p in PawnsFinder.AllMaps_Spawned.Where(p => p.RaceProps.IsAnomalyEntity))
                    {
                    if (Alert_EnemiesOnMap.NeedsRescue(p))
                    {
                        yield return p;
                    }
                }
            }
        }

        public override string GetLabel()
        {
            return "AlertEntityDowned".Translate();
        }

        public override TaggedString GetExplanation()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (Pawn current in this.EntitiesDowned)
            {
                stringBuilder.AppendLine("    " + current.LabelShort);
            }
            return string.Format("AlertEntityDownedDesc".Translate(), stringBuilder.ToString());
        }

        public override AlertReport GetReport()
        {
            if (!ExtraAlertSettings.cb_enemyRescue)
            {
                return AlertReport.Inactive;
            }
            return AlertReport.CulpritsAre(this.EntitiesDowned.ToList());
        }
    }
}
