using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileUpload
{
    class Program
    {
        public static List<string> AddNID()
        {
            List<string> NIDs = new List<string>();
            NIDs.Add("28602202100177");
            NIDs.Add("28809150107091");
            NIDs.Add("28503100100077");
            NIDs.Add("25712150100661");
            NIDs.Add("27909092105318");
            
            return NIDs;
        }

        public static List<string> GetFiles(string srcDir)
        {
            var allFiles = Directory.GetFiles(srcDir, "*.*", SearchOption.AllDirectories);
            return allFiles.ToList();
        }

        public static void CopyFiles(string srcDir, string path)
        {
            string uploadpath = "C:\\Users\\rt_svrmgr\\Desktop\\Copied";
            string dest_path = Path.Combine(uploadpath, "NIDImages");

            if (!Directory.Exists(dest_path))
            {
                Directory.CreateDirectory(dest_path);
            }

            var allFiles = Directory.GetFiles(path, srcDir, SearchOption.AllDirectories);

            foreach (string file in allFiles)
            {
                string sourcefile = Path.GetFileName(srcDir);
                string Imgpath = Path.Combine(dest_path, sourcefile);
                File.Copy(file, Imgpath, true);
            }
        }

        static void Main(string[] args)
        {
            List<string> NationalIDs = AddNID();

            foreach (var excelNID in NationalIDs)
            {
                foreach (var Src in GetFiles("D:\\WebApplications\\Raya Installment System\\PDFs\\NationalIDs"))
                {
                    string NID = Src.Contains(excelNID) ? excelNID : "";
                    if (excelNID == NID)
                    {
                        CopyFiles(Src.Replace("D:\\WebApplications\\Raya Installment System\\PDFs\\NationalIDs\\", ""), "D:\\WebApplications\\Raya Installment System\\PDFs\\NationalIDs\\");
                    }
                }
            }
            
        }


    }
}
