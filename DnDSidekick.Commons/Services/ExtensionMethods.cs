using System;
using System.Collections.Generic;
using System.Text;

namespace DnDSidekick.Commons.Services
{
    public static class ExtensionMethods
    {
        public static int Modifier(this int abilityScore) => Convert.ToInt32(Math.Floor(((float)abilityScore - 10) / 2));
    }
}
