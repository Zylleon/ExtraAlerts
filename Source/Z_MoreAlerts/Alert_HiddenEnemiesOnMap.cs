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
        private IEnumerable<Pawn> Enemies
        {
            get
            {
                foreach (Pawn p in PawnsFinder.AllMaps_Spawned)
                {
                    if (p.HostileTo(Faction.OfPlayer) && !p.Downed)
                    {
                        if(IsHidden(p))
                        {
                            yield return p;

                        }

                    }
                }
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
            StringBuilder stringBuilder = new StringBuilder();
            foreach (Pawn current in this.Enemies)
            {
                stringBuilder.AppendLine("    " + current.LabelShort);
            }
            return string.Format("AlertHiddenEnemiesDesc".Translate(), this.Enemies.Count(), stringBuilder.ToString());
        }

        public override AlertReport GetReport()
        {
            if (!ExtraAlertSettings.cb_hiddenEnemies || !ExtraAlertSettings.cb_enemies)
            {
                return AlertReport.Inactive;
            }
            return AlertReport.CulpritsAre(this.Enemies.ToList());
        }
    }
}
