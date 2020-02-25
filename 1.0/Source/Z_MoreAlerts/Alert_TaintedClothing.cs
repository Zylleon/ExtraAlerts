using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        //public override AlertReport GetReport()
        //{
        //    if (!ExtraAlertSettings.cb_caravanWaiting)
        //    {
        //        return AlertReport.Inactive;
        //    }


        //    return this.base.GetReport();

        //    //return AlertReport.CulpritsAre(this.base.AffectedPawns());
        //}


        public override bool Active
        {
            get
            {
                return ExtraAlertSettings.cb_deadApparel && this.GetReport().active; 
            }
        }
    }
}
