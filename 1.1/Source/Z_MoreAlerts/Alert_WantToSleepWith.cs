using RimWorld;
using Verse;

namespace Z_MoreAlerts
{
    public class Alert_WantToSleepWith : Alert_Thought
    {
        protected override ThoughtDef Thought
        {
            get
            {
                return MoreAlertsDefOf.WantToSleepWithSpouseOrLover;
            }
        }

        public Alert_WantToSleepWith()
        {
            this.defaultLabel = "AlertWantToSleepWith".Translate();
            this.explanationKey = "AlertWantToSleepWithDesc";
        }


        public override AlertReport GetReport()
        {
            if (!ExtraAlertSettings.cb_Lovers)
            {
                return AlertReport.Inactive;
            }
            return base.GetReport();
        }

    }
}

