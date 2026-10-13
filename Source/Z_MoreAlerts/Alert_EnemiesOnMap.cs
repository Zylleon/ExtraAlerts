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
                foreach (Pawn p in PawnsFinder.AllMaps_Spawned)
                {
                    if (p.HostileTo(Faction.OfPlayer) && !p.Downed)
                    {
                        if(!Alert_HiddenEnemiesOnMap.IsHidden(p))
                        {
                            yield return p;

                        }
                    }
                }
            }
        }

        public static bool NeedsRescue(Pawn p)
        {
            return p.Downed && !p.InBed() && !(p.ParentHolder is Pawn_CarryTracker) && (p.jobs.jobQueue == null || p.jobs.jobQueue.Count <= 0 || !p.jobs.jobQueue.Peek().job.CanBeginNow(p, false));
        }

        public override string GetLabel()
        {
            return "AlertEnemies".Translate();
        }

        public override TaggedString GetExplanation()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (Pawn current in this.Enemies)
            {
                stringBuilder.AppendLine("    " + current.LabelShort);
            }
            return string.Format("AlertEnemiesDesc".Translate(), this.Enemies.Count(), stringBuilder.ToString());
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
