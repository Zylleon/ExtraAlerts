using RimWorld;
using Verse;

namespace Z_MoreAlerts
{
    class Alert_HumanLeatherApparelSad : Alert_Thought
    {
        protected override ThoughtDef Thought
        {
            get
            {
                return ThoughtDefOf.HumanLeatherApparelSad;
            }
        }

        public Alert_HumanLeatherApparelSad()
        {
            this.defaultLabel = "AlertHumanLeatherApparelSad".Translate();
            this.explanationKey = "AlertHumanLeatherApparelSadDesc";
        }


        public override AlertReport GetReport()
        {
            if (!ExtraAlertSettings.cb_humanApparel)
            {
                return AlertReport.Inactive;
            }
            return base.GetReport();
        }

    }
}
