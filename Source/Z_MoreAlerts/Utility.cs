using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RimWorld;
using Verse;

namespace Z_MoreAlerts
{
    static class Utility
    {
        static readonly StringBuilder stringBuilder = new StringBuilder();

        public static string BuildString(Action<StringBuilder> f)
        {
            var savedLength = stringBuilder.Length;

            try
            {
                f(stringBuilder);

                return stringBuilder.ToString(savedLength, stringBuilder.Length - savedLength);
            }
            finally
            {
                stringBuilder.Length = savedLength;
            }
        }

        public static string BuildPawnListText(IEnumerable<Pawn> pawns)
        {
            return BuildString(stringBuilder =>
            {
                foreach (var pawn in pawns)
                {
                    stringBuilder.AppendLine();
                    stringBuilder.Append("    ");
                    stringBuilder.Append(pawn.NameShortColored.Resolve());
                }
            });
        }

        public static bool NeedsRescue(Pawn p)
        {
            return p.Downed && !p.InBed() && !(p.ParentHolder is Pawn_CarryTracker) && (p.jobs.jobQueue == null || p.jobs.jobQueue.Count <= 0 || !p.jobs.jobQueue.Peek().job.CanBeginNow(p, false));
        }

        private static IEnumerable<Pawn> SpawnedPawnsByFactionRelationKind(FactionRelationKind factionRelationKind)
        {
            var playerFaction = Faction.OfPlayer;

            foreach (Map map in Find.Maps)
            {
                MapPawns mapPawns = map.mapPawns;

                foreach (var faction in Find.FactionManager.AllFactions)
                {
                    if (faction != playerFaction && faction.RelationKindWith(playerFaction) == factionRelationKind)
                    {
                        foreach (var pawn in mapPawns.SpawnedPawnsInFaction(faction))
                        {
                            yield return pawn;
                        }
                    }
                }

                // For pawns without factions.
                if (factionRelationKind == FactionRelationKind.Neutral)
                {
                    foreach (var pawn in mapPawns.SpawnedPawnsInFaction(null))
                    {
                        yield return pawn;
                    }
                }
            }
        }

        public static IEnumerable<Pawn> SpawnedAllies => SpawnedPawnsByFactionRelationKind(FactionRelationKind.Ally);
        public static IEnumerable<Pawn> SpawnedNeutrals => SpawnedPawnsByFactionRelationKind(FactionRelationKind.Neutral);

        public static IEnumerable<Pawn> SpawnedEnemies
        {
            get
            {
                var playerFaction = Faction.OfPlayer;

                // Not using `SpawnedPawnsByFactionRelationKind` because hostility can also be determined by other factors like mental condition, etc.
                return PawnsFinder.AllMaps_Spawned.Where(pawn => pawn.HostileTo(playerFaction));
            }
        }

        public static IEnumerable<Pawn> SpawnedColonyAnimals
        {
            get
            {
                var playerFaction = Faction.OfPlayer;

                foreach (var map in Find.Maps)
                {
                    foreach (var pawn in map.mapPawns.SpawnedPawnsInFaction(playerFaction))
                    {
                        if (pawn.IsAnimal)
                        {
                            yield return pawn;
                        }
                    }
                }
            }
        }
    }
}
