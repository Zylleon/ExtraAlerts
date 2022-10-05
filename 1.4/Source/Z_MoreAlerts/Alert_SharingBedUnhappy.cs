using RimWorld;
using Verse;

namespace Z_MoreAlerts
{
    public class Alert_SharingBedUnhappy : Alert_Thought
    {
        protected override ThoughtDef Thought
        {
            get
            {
                return MoreAlertsDefOf.SharedBed;
            }
        }

        public Alert_SharingBedUnhappy()
        {
            this.defaultLabel = "AlertSharingBedUnhappy".Translate();
            this.explanationKey = "AlertSharingBedUnhappyDesc";
        }

        public override AlertReport GetReport()
        {
            if (!ExtraAlertSettings.cb_sharedBed)
            {
                return AlertReport.Inactive;
            }
            return base.GetReport();
        }
    }
}

