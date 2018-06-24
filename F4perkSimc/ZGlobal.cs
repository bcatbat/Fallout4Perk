using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F4perkSimc
{
    public class ZGlobal
    {
        public static Person role;
        public static ZProgress progress = ZProgress.Stat;

        public static List<Tuple<int, string>> record = new List<Tuple<int, string>>();

        public static void Rest()
        {
            progress = ZProgress.Stat;
        }
    }

    public enum ZProgress
    {
        Stat,
        Perk,
    }
}
