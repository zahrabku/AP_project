using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.back.util
{
    class queryUtils
    {
        private static string name="";
        public static string QueryName { get { return name; } set { if (value != null) { name = value; } else { name = ""; } } }

        private static string lastName="";
        public static string QueryLastName { get { return lastName; } set { if (value != null) { lastName = value; } else { lastName = ""; } } }

        private static string ageGT="";
        public static string QueryAgeGT { get { return ageGT; } set { if (value != null) { ageGT = value; } else { ageGT = ""; } } }

        private static string ageLT="";
        public static string QueryAgeLT { get { return ageLT; } set { if (value != null) { ageLT = value; } else { ageLT = ""; } } }

        private static string city="";
        public static string QueryCity { get { return city; } set { if (value != null) { city = value; } else {city = ""; } } }

        private static string equation="";
        public static string QueryEquation { get { return equation; } set { if (value != null) { equation = value; } else { equation = ""; } } }

        private static string result="";
        public static string QueryResult { get { return result; } set { if (value != null) {result = value; } else { result = ""; } } }


    }
}
