using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public override bool Active
        {
            get
            {
                return this.GetReport().active && ExtraAlertSettings.cb_humanApparel;
            }
        }
    }
}
