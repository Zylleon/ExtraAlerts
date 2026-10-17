using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;
using RimWorld;
using UnityEngine;

namespace Z_MoreAlerts
{
    public class Alert_EntitiesDowned : Alert_SemiCritical
    {
        private IEnumerable<Pawn> EntitiesDowned
        {
            get
            {
                //foreach (Pawn p in PawnsFinder.AllMaps_Spawned.Where(p => p.RaceProps.IsAnomalyEntity && p.HostileTo(Faction.OfPlayer)))
                foreach (Pawn p in PawnsFinder.AllMaps_Spawned.Where(p => p.RaceProps.IsAnomalyEntity))
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
            return "AlertEntityDowned".Translate();
        }

        public override TaggedString GetExplanation()
        {
            return string.Format("AlertEntityDownedDesc".Translate(), Utility.BuildPawnListText(this.EntitiesDowned));
        }

        public override AlertReport GetReport()
        {
            if (!ExtraAlertSettings.cb_enemyRescue)
            {
                return AlertReport.Inactive;
            }
            return AlertReport.CulpritsAre(this.EntitiesDowned.ToList());
        }
    }
}
