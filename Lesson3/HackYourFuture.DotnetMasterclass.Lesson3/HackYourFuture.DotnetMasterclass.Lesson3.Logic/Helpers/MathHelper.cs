using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackYourFuture.DotnetMasterclass.Lesson3.Logic.Helpers
{
    public static class MathHelper
    {
        public static int CalculateAverageAndRoundDownToNearestInt(List<int> integers)
        {
            return (int)integers.Average();
        }
    }
}
