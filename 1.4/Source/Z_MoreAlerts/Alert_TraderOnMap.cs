using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RimWorld;
using Verse;

namespace Z_MoreAlerts
{
    public class Alert_TraderOnMap : Alert
    {

        private IEnumerable<Pawn> Traders
        {
            get
            {
                foreach (Pawn p in PawnsFinder.AllMaps_Spawned.Where(p => p.RaceProps.Humanlike))
                {
                    if (p.trader != null && p.trader.CanTradeNow)
                    {
                        yield return p;
                    }
                }
            }
        }


        public override AlertReport GetReport()
        {
            if (!ExtraAlertSettings.cb_trader)
            {
                return AlertReport.Inactive;
            }
            return AlertReport.CulpritsAre(this.Traders.ToList());
        }

        public override string GetLabel()
        {
            return "AlertTradeCaravan".Translate();
        }

        public override TaggedString GetExplanation()
        {
            return "AlertTradeCaravanDesc".Translate();
        }
    }
}
