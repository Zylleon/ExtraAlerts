using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;
using RimWorld;
using UnityEngine;

namespace Z_MoreAlerts
{
    public class Alert_EnemyNeedsRescue : Alert_SemiCritical
    {
        private IEnumerable<Pawn> EnemiesNeedingRescue
        {
            get
            {
                foreach (Pawn p in PawnsFinder.AllMaps_Spawned.Where(p => p.RaceProps.Humanlike && p.HostileTo(Faction.OfPlayer)))
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
            return "AlertEnemyNeedsRescue".Translate();
        }

        public override TaggedString GetExplanation()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (Pawn current in this.EnemiesNeedingRescue)
            {
                stringBuilder.AppendLine("    " + current.LabelShort);
            }
            return string.Format("AlertEnemyNeedsRescueDesc".Translate(), stringBuilder.ToString());
        }

        public override AlertReport GetReport()
        {
            if (!ExtraAlertSettings.cb_enemyRescue)
            {
                return AlertReport.Inactive;
            }
            return AlertReport.CulpritsAre(this.EnemiesNeedingRescue.ToList());
        }
    }
}
