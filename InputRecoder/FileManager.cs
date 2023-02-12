using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InputRecoder
{
    public class FileUtils
    {
        public static string CreateNoRepeatFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                
            }
            else
            {
                string newFilePath = filePath.Replace(Path.GetFileName(filePath), "");
                string fileName = Path.GetFileNameWithoutExtension(filePath);
                string fileExtension = Path.GetExtension(filePath);
                int i = 1;
                while (File.Exists(filePath))
                {
                    filePath = newFilePath + fileName + "(" + i + ")" + fileExtension;
                    i++;
                }
            }
            return filePath;
        }
    }
}
