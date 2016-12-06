using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_CORA
{
    static class JoyStickState
    {
        public static bool connected { get; set; }
        public static int Xaxis { get; set; }
        public static int Yaxis { get; set; }
        public static int Zaxis { get; set; }
        public static bool[] buttons { get; set; }
    }
}
