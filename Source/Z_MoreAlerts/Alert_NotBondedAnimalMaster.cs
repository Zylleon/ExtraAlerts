using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            this.defaultLabel = "NotBondedAnimalMaster".Translate();

            this.explanationKey = "NotBondedAnimalMasterDesc";
        }
    }
}

