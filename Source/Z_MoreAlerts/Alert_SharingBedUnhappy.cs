using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    }
}

