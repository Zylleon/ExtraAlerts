using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Verse;

namespace Z_MoreAlerts
{
    public class Alert_NeutralNeedsRescue : Alert_SemiCritical
    {
        private IEnumerable<Pawn> AlliesNeedingRescue
        {
            get
            {
                foreach (Pawn p in Utility.SpawnedNeutrals)
                {
                    if (p.RaceProps.Humanlike && Utility.NeedsRescue(p))
                    {
                        yield return p;
                    }
                }
            }
        }

        public override string GetLabel()
        {
            return "AlertNeutralNeedsRescue".Translate();
        }

        public override TaggedString GetExplanation()
        {
            return string.Format("AlertNeutralNeedsRescueDesc".Translate(), Utility.BuildPawnListText(this.AlliesNeedingRescue));
        }

        public override AlertReport GetReport()
        {
            if (!ExtraAlertSettings.cb_neutralRescue)
            {
                return AlertReport.Inactive;
            }
            return AlertReport.CulpritsAre(this.AlliesNeedingRescue.ToList());
        }

    }
}
