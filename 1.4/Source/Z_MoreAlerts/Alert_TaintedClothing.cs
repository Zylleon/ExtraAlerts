using RimWorld;
using Verse;

namespace Z_MoreAlerts
{
    public class Alert_TaintedApparel : Alert_Thought
    {
        protected override ThoughtDef Thought
        {
            get
            {
                return ThoughtDefOf.DeadMansApparel;
            }
        }

        public Alert_TaintedApparel()
        {
            this.defaultLabel = "AlertDeadMansApparel".Translate();
            this.explanationKey = "AlertDeadMansApparelDesc";
        }

        public override AlertReport GetReport()
        {
            if (!ExtraAlertSettings.cb_deadApparel)
            {
                return AlertReport.Inactive;
            }
            return base.GetReport();
        }

    }
}
