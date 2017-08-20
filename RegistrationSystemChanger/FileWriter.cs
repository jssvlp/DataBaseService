using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrationSystemChanger
{
    class FileWriter
    {
        public void WriteFile(String texto)
        {
            string path = string.Format("{0}/{1}", "C://", "Log.txt");
            try
            {
                if (!File.Exists(path))
                {
                    File.Create(path).Dispose();
                    using (TextWriter tw = new StreamWriter(path))
                    {
                        tw.WriteLine(texto + " " + DateTime.Now.ToString());
                        tw.Close();
                    }
                }
                if (File.Exists(path))
                {
                    using (TextWriter tw = new StreamWriter(path))
                    {
                        tw.WriteLine(texto +" " + DateTime.Now.ToString());
                        tw.Close();
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

    }
}
