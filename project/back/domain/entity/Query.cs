using project.back.domain.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using project.back.util;

namespace project
{
    
    class query
    {
        public static string GetFileText(string name)
        {
            string fileContents = String.Empty;

            // If the file has been deleted since we took   
            // the snapshot, ignore it and return the empty string.  
            if (File.Exists(name))
            {
                fileContents =File.ReadAllText(name);
            }
            return fileContents;
        }
        public static List<string> queryMethod()
        {
            List<string> result = new List<string>();
            string startFolder = @"D:\CE\AP\project\project\bin\Debug\userInfo";

            // Take a snapshot of the file system.  
            DirectoryInfo dir = new DirectoryInfo(startFolder);

            // This method assumes that the application has discovery permissions  
            // for all folders under the specified path.  
            IEnumerable<FileInfo> fileList = dir.GetFiles("*_*",SearchOption.AllDirectories);


            // Search the contents of each file.  
            // A regular expression created with the RegEx class  
            // could be used instead of the Contains method.  
            // queryMatchingFiles is an IEnumerable<string>.  
            var queryMatchingFiles =
                from file in fileList
                where file.Extension == ".txt"
                let fileText = GetFileText(file.FullName)
                where  fileText.Contains(queryUtils.QueryName) && fileText.Contains(queryUtils.QueryLastName) && fileText.Contains(queryUtils.QueryCity) && fileText.Contains(queryUtils.QueryAgeGT)
                && fileText.Contains(queryUtils.QueryAgeLT) && fileText.Contains(queryUtils.QueryEquation) && fileText.Contains(queryUtils.QueryResult)
                select file.FullName;
            foreach(string fileNm in queryMatchingFiles)
            {
                result.Add(fileNm);
            }
            return result;
        }
    }
}
