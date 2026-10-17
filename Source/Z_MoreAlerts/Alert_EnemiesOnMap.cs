using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;
using RimWorld;
using UnityEngine;

namespace Z_MoreAlerts
{
    public class Alert_EnemiesOnMap : Alert_Critical
    {
        private IEnumerable<Pawn> Enemies
        {
            get
            {
                foreach (Pawn p in Utility.SpawnedEnemies)
                {
                    if (!p.Downed && !Alert_HiddenEnemiesOnMap.IsHidden(p))
                    {
                        yield return p;
                    }
                }
            }
        }

        public override string GetLabel()
        {
            return "AlertEnemies".Translate();
        }

        public override TaggedString GetExplanation()
        {
            return string.Format("AlertEnemiesDesc".Translate(), this.Enemies.Count(), Utility.BuildPawnListText(this.Enemies));
        }

        public override AlertReport GetReport()
        {
            if (!ExtraAlertSettings.cb_enemies)
            {
                return AlertReport.Inactive;
            }
            return AlertReport.CulpritsAre(this.Enemies.ToList());
        }
    }
}
