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
        private readonly List<Pawn> enemies = new List<Pawn>();

        private List<Pawn> Enemies
        {
            get
            {
                enemies.Clear();

                foreach (Pawn p in Utility.SpawnedEnemies)
                {
                    if (!p.Downed && !Alert_HiddenEnemiesOnMap.IsHidden(p))
                    {
                        enemies.Add(p);
                    }
                }

                return enemies;
            }
        }

        public override string GetLabel()
        {
            return "AlertEnemies".Translate();
        }

        public override TaggedString GetExplanation()
        {
            return string.Format("AlertEnemiesDesc".Translate(), this.enemies.Count, Utility.BuildPawnListText(this.enemies));
        }

        public override AlertReport GetReport()
        {
            if (!ExtraAlertSettings.cb_enemies)
            {
                return AlertReport.Inactive;
            }
            return AlertReport.CulpritsAre(this.Enemies);
        }
    }
}
