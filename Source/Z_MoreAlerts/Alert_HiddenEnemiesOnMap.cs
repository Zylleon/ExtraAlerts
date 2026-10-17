using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;
using RimWorld;
using UnityEngine;

namespace Z_MoreAlerts
{
    public class Alert_HiddenEnemiesOnMap : Alert_Critical
    {
        private readonly List<Pawn> enemies = new List<Pawn>();

        private List<Pawn> Enemies
        {
            get
            {
                enemies.Clear();

                foreach (Pawn p in Utility.SpawnedEnemies)
                {
                    if (!p.Downed && IsHidden(p))
                    {
                        enemies.Add(p);
                    }
                }

                return enemies;
            }
        }

        public static bool IsHidden(Pawn p)
        {
            if (p.Fogged())
            {
                return true;
            }

            else if (p.IsHiddenFromPlayer())
            {
                return true;
                //if(ModLister.AnomalyInstalled)
                //{
                //    if (p.health.hediffSet.GetFirstHediffOfDef(HediffDefOf.HoraxianInvisibility)?.TryGetComp<HediffComp_Invisibility>() != null && p.mindState.lastBecameVisibleTick < p.mindState.lastBecameInvisibleTick)
                //    {
                //        return true;
                //    }
                //}
            }


            return false;
        }

        public override string GetLabel()
        {
            return "AlertHiddenEnemies".Translate();
        }

        public override TaggedString GetExplanation()
        {
            return string.Format("AlertHiddenEnemiesDesc".Translate(), this.enemies.Count, Utility.BuildPawnListText(this.enemies));
        }

        public override AlertReport GetReport()
        {
            if (!ExtraAlertSettings.cb_hiddenEnemies || !ExtraAlertSettings.cb_enemies)
            {
                return AlertReport.Inactive;
            }
            return AlertReport.CulpritsAre(this.Enemies);
        }
    }
}
