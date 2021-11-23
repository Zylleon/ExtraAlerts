using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RimWorld;
using Verse;

namespace Z_MoreAlerts
{
    public class Alert_UnroofedElectrical : Alert
    {
        private HashSet<Building> UnroofedBuildings
        {
            get
            {
                HashSet<Building> buildings = new HashSet<Building>();
                HashSet<Building> unroofed = new HashSet<Building>();
                List<Map> maps = Find.Maps;
                for (int i = 0; i < maps.Count; i++)
                {
                    buildings = maps[i].listerBuildings.allBuildingsColonistElecFire;

                    foreach (Building b in buildings)
                    {
                        if (!maps[i].roofGrid.Roofed(b.Position))
                        {
                            unroofed.Add(b);
                        }
                    }
                }

                return unroofed;
            }
        }

        public override AlertReport GetReport()
        {
            if (!ExtraAlertSettings.cb_unroofedElectrical)
            {
                return AlertReport.Inactive;
            }

            List<Thing> culprits = new List<Thing>();
            foreach(Building b in this.UnroofedBuildings)
            {
                culprits.Add((Thing)b);
            }

            return AlertReport.CulpritsAre(culprits);
        }

        public override string GetLabel()
        {
            return "AlertUnroofedElectrical".Translate();
        }

        public override TaggedString GetExplanation()
        {
            return "AlertUnroofedElectricalDesc".Translate();
        }
    }
}
