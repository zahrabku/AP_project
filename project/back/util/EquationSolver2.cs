using project.back.domain.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.back.util
{
    class EquationSolver2
    {
        // This functions finds the determinant of Matrix 
        public static double determinantOfMatrix(double[,] mat)
        {
            double ans;
            ans = (mat[0, 0] * mat[1, 1]) - (mat[0, 1] * mat[1, 0]);
            return ans;
        }
        // This function finds the solution of system of 
        // linear equations using cramer's rule 
        public static Answer findSolution(double[,] coeff)
        {
            Answer ansr = new Answer();
            // Matrix d using coeff as given in cramer's rule 
            double[,] d = {
        { coeff[0,0], coeff[0,1]},
        { coeff[1,0], coeff[1,1]},
    };

            // Matrix d1 using coeff as given in cramer's rule 
            double[,] d1 = {
        { coeff[0,2], coeff[0,1]},
        { coeff[1,2], coeff[1,1]},
    };

            // Matrix d2 using coeff as given in cramer's rule 
            double[,] d2 = {
        { coeff[0,2], coeff[0,0]},
        { coeff[1,2],coeff[1,0] },
    };


            // Calculating Determinant of Matrices d, d1, d2, d3 
            double D = determinantOfMatrix(d);
            double D1 = determinantOfMatrix(d1);
            double D2 = determinantOfMatrix(d2);


            // Case 1 
            if (D != 0)
            {
                // Coeff have a unique solution. Apply Cramer's Rule 
                double x = D1 / D;
                double y = D2 / D;
                ansr.Answer1 = x;
                ansr.Answer2 = y;
                ansr.Answer3 = null;
            }

            // Case 2 
            else
            {
                if (D1 == 0 && D2 == 0)
                {
                    ansr.Answer4 = "Infinite solutions";
                    ansr.Answer1 = null;
                    ansr.Answer2 = null;
                    ansr.Answer3 = null;
                }
                else if (D1 != 0 || D2 != 0)
                {
                    ansr.Answer4 = "No solutions";
                    ansr.Answer1 = null;
                    ansr.Answer2 = null;
                    ansr.Answer3 = null;
                }
            }
            return ansr;
        }
    }
}
