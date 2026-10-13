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
                        List<Building> allBuildingsColonist = maps[i].listerBuildings.allBuildingsColonist;
                        
                        if (allBuildingsColonist.Any(b => b.def.defName == "CommsConsole"))
                        {
                            return true;
                        }


                    }
                    
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
