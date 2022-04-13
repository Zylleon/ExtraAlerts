using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RimWorld;
using Verse;

namespace Z_MoreAlerts
{
    public class Alert_TraderOrbital : Alert
    {

        private bool HasOrbitalTrader
        {
            get
            {
                List<Map> maps = Find.Maps;
                for (int i = 0; i < maps.Count; i++)
                {
                    if (maps[i].passingShipManager.passingShips.Count > 0)
                    {
                        return true;
                        //Log.Message("extra alerts - trade ship found");
                        //List<Building> allBuildingsColonist = maps[i].listerBuildings.allBuildingsColonist;
                        //return true;

                        //for (int j = 0; j < allBuildingsColonist.Count; j++)
                        //{
                        //    Log.Message("building found: " + allBuildingsColonist[i].def.defName);
                        //    if (allBuildingsColonist[i].def.defName == "CommsConsole")
                        //    {
                        //        return true;
                        //    }
                        //}
                        //return false; 
                    
                    }
                    //return false;
                    
                }
                return false;
            }
        }

        public override AlertReport GetReport()
        {
            if (!ExtraAlertSettings.cb_tradeOrbital)
            {
                return AlertReport.Inactive;
            }
            return HasOrbitalTrader;
        }

        public override string GetLabel()
        {
            return "AlertOrbitalTrader".Translate();
        }

        public override TaggedString GetExplanation()
        {
            return "AlertOrbitalTraderDesc".Translate();
        }
    }
}
