using System;
using System.Collections.Generic;
using System.Text;
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
    }
}
