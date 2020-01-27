using project.back.domain.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace project
{
    class FileUtils
    {

        public void writeInfo(UserInfo userinfo)
        {
            using (StreamWriter writer = new StreamWriter($@"D:\CE\AP\project\project\bin\Debug\userInfo\{userinfo.Name + "_" + userinfo.LastName}.txt"))
            {
                writer.WriteLine(userinfo.Name);
                writer.WriteLine(userinfo.LastName);
                writer.WriteLine(userinfo.Age);
                writer.WriteLine(userinfo.City);
                if (userinfo.Equation.equation1 != null) { writer.WriteLine(userinfo.Equation.equation1); }
                if (userinfo.Equation.equation2 != null) { writer.WriteLine(userinfo.Equation.equation2); }
                if (userinfo.Equation.equation3 != null) { writer.WriteLine(userinfo.Equation.equation3); }
                if (userinfo.Answer.Answer1 != null) { writer.WriteLine(userinfo.Answer.Answer1); }
                if (userinfo.Answer.Answer1 != null) { writer.WriteLine(userinfo.Answer.Answer2); }
                if (userinfo.Answer.Answer1 != null) { writer.WriteLine(userinfo.Answer.Answer3); }
                if (userinfo.Answer.Answer1 != null) { writer.WriteLine(userinfo.Answer.Answer4); }
            }
        }

    }
}
