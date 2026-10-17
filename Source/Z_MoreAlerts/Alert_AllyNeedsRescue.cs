using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;
using RimWorld;
using UnityEngine;

namespace Z_MoreAlerts
{
    public class Alert_AllyNeedsRescue : Alert_SemiCritical
    {
        private IEnumerable<Pawn> AlliesNeedingRescue
        {
            get
            {
                foreach (Pawn p in Utility.SpawnedAllies)
                {
                    if (p.RaceProps.Humanlike && !p.IsPrisoner && Utility.NeedsRescue(p))
                    {
                        yield return p;
                    }
                }
            }
        }

        public override string GetLabel()
        {
            return "AlertAllyNeedsRescue".Translate();
        }

        public override TaggedString GetExplanation()
        {
            return string.Format("AlertAllyNeedsRescueDesc".Translate(), Utility.BuildPawnListText(this.AlliesNeedingRescue));
        }

        public override AlertReport GetReport()
        {
            if (!ExtraAlertSettings.cb_allyRescue)
            {
                return AlertReport.Inactive;
            }
            return AlertReport.CulpritsAre(this.AlliesNeedingRescue.ToList());
        }
    }
}
