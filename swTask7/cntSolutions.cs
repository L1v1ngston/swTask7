using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace swTask7
{
    internal class cntSolutions
    {
        int CntSolutions(double a, double b, double c)
        {
            double d = b * b - 4 * a * c;
            if (d < 0) return 0;
            else if (d == 0) return 1;
            else return 2
        }
    }
}
