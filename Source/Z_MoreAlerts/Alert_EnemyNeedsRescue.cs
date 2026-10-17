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
                foreach (Pawn p in Utility.SpawnedEnemies)
                {
                    if (Utility.NeedsRescue(p))
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
            return string.Format("AlertEnemyNeedsRescueDesc".Translate(), Utility.BuildPawnListText(this.EnemiesNeedingRescue));
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
