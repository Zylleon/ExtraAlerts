using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;
using RimWorld;
using UnityEngine;

namespace Z_MoreAlerts
{
    public class Alert_Blight : Alert_Critical
    {
        private IEnumerable<Thing> BlightedPlants
        {
            get
            {
                List<Map> maps = Find.Maps;
                for (int i = 0; i < maps.Count; i++)
                {
                    List<Thing> plants = maps[i].listerThings.ThingsInGroup(ThingRequestGroup.HarvestablePlant);
                    //Log.Message("Plants found: " + plants.Count);
                    if (!plants.NullOrEmpty())
                    {
                        foreach (Thing p in plants)
                        {
                            if ((p as Plant)?.Blight != null)
                            {
                                yield return p;
                            }
                        }
                    }
                    
                }
            }
        }

        public override AlertReport GetReport()
        {
            if (!ExtraAlertSettings.cb_blight)
            {
                return AlertReport.Inactive;
            }
            return AlertReport.CulpritsAre(this.BlightedPlants.ToList());
        }

        public override string GetLabel()
        {
            return "AlertBlight".Translate();
        }

        public override TaggedString GetExplanation()
        {
            return "AlertBlightDesc".Translate();
        }
    }
}
