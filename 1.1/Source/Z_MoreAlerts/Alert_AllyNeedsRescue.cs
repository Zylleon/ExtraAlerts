using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;
using RimWorld;
using UnityEngine;

namespace Z_MoreAlerts
{
    public class Alert_EnemyNeedsRescue : Alert_Critical
    {
        private IEnumerable<Pawn> AlliesNeedingRescue
        {
            get
            {
                foreach (Pawn p in PawnsFinder.AllMaps_Spawned.Where(p => p.RaceProps.Humanlike && p.Faction != Faction.OfPlayer && !p.HostileTo(Faction.OfPlayer)))

                {
                    if (Alert_EnemyNeedsRescue.NeedsRescue(p))
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
            if (this.AlliesNeedingRescue.Count<Pawn>() == 1)
            {
                return "AlertAllyNeedsRescue".Translate();
            }
            return "AlertAllyNeedsRescue".Translate();
        }

        public override TaggedString GetExplanation()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (Pawn current in this.AlliesNeedingRescue)
            {
                stringBuilder.AppendLine("    " + current.LabelShort);
            }
            return string.Format("AlertAllyNeedsRescueDesc".Translate(), stringBuilder.ToString());
        }

        public override AlertReport GetReport()
        {
            if (!ExtraAlertSettings.cb_allyRescue)
            {
                return AlertReport.Inactive;
            }
            return AlertReport.CulpritsAre(this.AlliesNeedingRescue.ToList());
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
