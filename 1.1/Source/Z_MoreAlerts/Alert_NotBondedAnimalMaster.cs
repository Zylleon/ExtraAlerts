using Verse;
using RimWorld;

namespace Z_MoreAlerts
{
    public class Alert_NotBondedAnimalMaster : Alert_Thought
    {
        protected override ThoughtDef Thought
        {
            get
            {
                return MoreAlertsDefOf.NotBondedAnimalMaster;
            }
        }

        public Alert_NotBondedAnimalMaster()
        {
            this.defaultLabel = "AlertNotBondedAnimalMaster".Translate();

            this.explanationKey = "AlertNotBondedAnimalMasterDesc";
        }

        public override AlertReport GetReport()
        {
            if (!ExtraAlertSettings.cb_bondedAnimal)
            {
                return AlertReport.Inactive;
            }
            return base.GetReport();
        }
    }
}

