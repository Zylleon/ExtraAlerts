using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    }
}

