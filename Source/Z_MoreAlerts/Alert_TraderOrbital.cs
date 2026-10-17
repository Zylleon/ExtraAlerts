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
        private static ThingDef[] commsConsoleDefs;
        private readonly List<Thing> activeCommsConsoles = new List<Thing>();

        private static ThingDef[] CommsConsoleDefs
        {
            get
            {
                if (commsConsoleDefs == null)
                {
                    commsConsoleDefs = DefDatabase<ThingDef>.AllDefs.Where(thingDef => thingDef.IsCommsConsole).ToArray();
                }

                return commsConsoleDefs;
            }
        }

        private static bool IsCommsConsoleActive(Thing commsConsole, Faction faction) =>
            commsConsole.Faction == faction &&
            ((commsConsole as ThingWithComps)?.GetComp<CompPowerTrader>()?.PowerOn ?? true);

        private List<Thing> ActiveCommsConsoles
        {
            get
            {
                Faction playerFaction = Faction.OfPlayer;

                activeCommsConsoles.Clear();

                foreach (var map in Find.Maps)
                {
                    if (map.passingShipManager.passingShips.Count > 0)
                    {
                        foreach (var commsConsoleDef in CommsConsoleDefs)
                        {
                            foreach (var commsConsole in map.listerThings.ThingsOfDef(commsConsoleDef))
                            {
                                if (IsCommsConsoleActive(commsConsole, playerFaction))
                                {
                                    activeCommsConsoles.Add(commsConsole);
                                }
                            }
                        }
                    }
                }

                return activeCommsConsoles;
            }
        }

        public override AlertReport GetReport()
        {
            if (!ExtraAlertSettings.cb_tradeOrbital)
            {
                return AlertReport.Inactive;
            }

            return AlertReport.CulpritsAre(ActiveCommsConsoles);
        }

        public override string GetLabel()
        {
            return "AlertOrbitalTrader".Translate();
        }

        public override TaggedString GetExplanation()
        {
            Map currentMap = Find.CurrentMap;
            Faction playerFaction = Faction.OfPlayer;

            string detail = Utility.BuildString(stringBuilder =>
            {
                foreach (var map in Find.Maps)
                {
                    if (map.passingShipManager.passingShips.Count > 0 &&
                        CommsConsoleDefs.SelectMany(map.listerThings.ThingsOfDef).Any(c => IsCommsConsoleActive(c, playerFaction)))
                    {
                        stringBuilder.AppendLine();
                        stringBuilder.AppendLine();

                        if (map == currentMap)
                        {
                            stringBuilder.Append("<b>");
                        }

                        stringBuilder.Append(map.info.parent.LabelCap.Colorize(map == currentMap ? ColoredText.FactionColor_Ally : ColoredText.FactionColor_Neutral));

                        if (map == currentMap)
                        {
                            stringBuilder.Append("</b>");
                        }

                        stringBuilder.Append(":");

                        foreach (var passingShip in map.passingShipManager.passingShips)
                        {
                            stringBuilder.AppendLine();
                            stringBuilder.AppendLine();
                            stringBuilder.Append("    ");
                            stringBuilder.Append(passingShip.FullTitle);
                            stringBuilder.Append(": ");
                            stringBuilder.Append(passingShip.ticksUntilDeparture.ToStringTicksToPeriod());
                        }
                    }
                }
            });

            return "AlertOrbitalTraderDesc".Translate() + detail;
        }
    }
}
