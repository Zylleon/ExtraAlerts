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
        private readonly List<Thing> blightedPlants = new List<Thing>();

        private List<Thing> BlightedPlants
        {
            get
            {
                List<Map> maps = Find.Maps;

                blightedPlants.Clear();

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
                                blightedPlants.Add(p);
                            }
                        }
                    }

                }

                return blightedPlants;
            }
        }

        public override AlertReport GetReport()
        {
            if (!ExtraAlertSettings.cb_blight)
            {
                return AlertReport.Inactive;
            }
            return AlertReport.CulpritsAre(this.BlightedPlants);
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
