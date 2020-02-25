using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;
using RimWorld;
using UnityEngine;

namespace Z_MoreAlerts
{
    public class Alert_AllyNeedsRescue : Alert_Critical
    {
        private IEnumerable<Pawn> EnemiesNeedingRescue
        {
            get
            {
                foreach (Pawn p in PawnsFinder.AllMaps_Spawned.Where(p => p.RaceProps.Humanlike && p.HostileTo(Faction.OfPlayer)))
                {
                    if (Alert_AllyNeedsRescue.NeedsRescue(p))
                    {
                        yield return p;
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
            if (this.EnemiesNeedingRescue.Count<Pawn>() == 1)
            {
                return "AlertEnemyNeedsRescue".Translate();
            }
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

        protected override Color BGColor
        {
            get
            {
                float num = Pulser.PulseBrightness(0.5f, Pulser.PulseBrightness(0.5f, 0.6f));
                return new Color(num, num, num) * Color.grey;
            }
        }
    }
}
