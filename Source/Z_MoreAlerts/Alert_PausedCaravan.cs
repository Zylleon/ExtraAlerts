using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RimWorld;
using RimWorld.Planet;
using Verse;

namespace Z_MoreAlerts
{
    public class Alert_PausedCaravan : Alert
    {
        private IEnumerable<Caravan> ImmobileCaravans
        {
            get
            {
                List<Caravan> caravans = Find.WorldObjects.Caravans;
                for (int i = 0; i < caravans.Count; i++)
                {
                    if (caravans[i].IsPlayerControlled && (CaravanVisitUtility.SettlementVisitedNow(caravans[i]) != null || !caravans[i].pather.Moving || caravans[i].pather.Paused))
                    {
                        yield return caravans[i];
                    }
                }
            }
        }

        public Alert_PausedCaravan()
        {
            this.defaultLabel = "AlertPausedCaravan".Translate();
            this.defaultExplanation = "AlertPausedCaravanDesc".Translate();
        }

        public override AlertReport GetReport()
        {
            if (!ExtraAlertSettings.cb_caravanWaiting)
            {
                return AlertReport.Inactive;
            }

            return AlertReport.CulpritsAre(this.ImmobileCaravans);
        }
    }
}