using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;
using RimWorld;
using UnityEngine;

namespace Z_MoreAlerts
{
    public class Alert_PorcupineQuills : Alert
    {
        private List<Pawn> pawnsWithQuills = new List<Pawn>();

        private List<Pawn> ColonistsWithQuills
        {
            get
            {
                pawnsWithQuills.Clear();
                if (ModsConfig.OdysseyActive)
                {
                    foreach (Pawn p in PawnsFinder.AllMapsCaravansAndTravellingTransporters_AliveSpawned_FreeColonists_NoSuspended)
                    {
                        Hediff quills = p.health.hediffSet.GetFirstHediffOfDef(HediffDefOf.PorcupineQuill);
                        if (quills != null)
                        {
                            pawnsWithQuills.Add(p);
                        }
                    }
                }
                return pawnsWithQuills;
            }
        }
        public override string GetLabel()
        {
            return "AlertPorcupineQuills".Translate();
        }

        public override TaggedString GetExplanation()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (Pawn current in pawnsWithQuills)
            {
                stringBuilder.AppendLine("    " + current.NameShortColored.Resolve());
            }
            return string.Format("AlertPorcupineQuillsDesc".Translate(), stringBuilder.ToString());
        }

        public override AlertReport GetReport()
        {
            if (!ExtraAlertSettings.cb_porqupineQuills || !ModsConfig.OdysseyActive)
            {
                return AlertReport.Inactive;
            }
            return AlertReport.CulpritsAre(ColonistsWithQuills);
        }
    }
}
