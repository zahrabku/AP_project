using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.back.domain.entity
{
    class Equation
    {
        public string equation1 { get; set; }
        public string equation2 { get; set; }
        public string equation3 { get; set; }

        public Equation(string var1,string var2,string var3,double a1,double a2,double a3,double b1,double b2,double b3,double c1,double c2,double c3,double quant1,double quant2,double quant3)
        {
            if (b1 > 0 && c1 > 0) { this.equation1 = $"{a1}{var1}+{b1}{var2}+{c1}{var3}={quant1}"; }
            else if (b1 > 0) { this.equation1 = $"{a1}{var1}+{b1}{var2}{c1}{var3}={quant1}"; }
            else if (c1 > 0) { this.equation1 = $"{a1}{var1}{b1}{var2}+{c1}{var3}={quant1}"; }
            else { this.equation1 = $"{a1}{var1}{b1}{var2}{c1}{var3}={quant1}"; }

            if (b2 > 0 && c2 > 0) { this.equation2 = $"{a2}{var1}+{b2}{var2}+{c2}{var3}={quant2}"; }
            else if (b2 > 0) { this.equation2 = $"{a2}{var1}+{b2}{var2}{c2}{var3}={quant2}"; }
            else if (c2 > 0) { this.equation2 = $"{a2}{var1}{b2}{var2}+{c2}{var3}={quant2}"; }
            else { this.equation2 = $"{a2}{var1}{b2}{var2}{c2}{var3}={quant2}"; }

            if (b3 > 0 && c3 > 0) { this.equation3 = $"{a3}{var1}+{b3}{var2}+{c3}{var3}={quant3}"; }
            else if (b3 > 0) { this.equation3 = $"{a3}{var1}+{b3}{var2}{c3}{var3}={quant3}"; }
            else if (c3 > 0) { this.equation3 = $"{a3}{var1}{b3}{var2}+{c3}{var3}={quant3}"; }
            else { this.equation3 = $"{a3}{var1}{b3}{var2}{c3}{var3}={quant3}"; }

            if (a1 == 0 && b1 == 0 && c1 == 0 && quant1 == 0)
            {
                equation1 = null;
            }
            if (a2 == 0 && b2 == 0 && c2 == 0 && quant2 == 0)
            {
                equation2 = null;
            }
            if (a3==0&&b3==0&&c3==0&&quant3==0)
            {
                equation3 = null;
            }
            if(equation1==equation2)
            {
                equation2 = null;
            }
            if (equation2 == equation3)
            {
                equation3 =null;
            }
            if( equation1 == equation3)
            {
                equation3 = null;
            }
        }

    }
}
