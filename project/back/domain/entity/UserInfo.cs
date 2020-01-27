using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.back.domain.entity
{
    class UserInfo
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
        public Equation Equation { get; set; }
        public Answer Answer { get; set; }
    }
}
