using System;
using System.IO;
using System.Diagnostics;
using System.Configuration;

namespace CoreBVN
{
    class LogWriter
    {
        public LogWriter() { }

        public static object obj = new object();
        internal void WriteErrorLog(String message)
        {

            Debug.WriteLine(message);

            StreamWriter sw = null;
            string path = AppDomain.CurrentDomain.BaseDirectory;
          //  string path = ConfigurationManager.AppSettings["errorLog"].ToString();
            try
            {

                DateTime dateTime = DateTime.Now;
                String filename = String.Format("{0}_{1}_{2}_BVN_Report_ServiceLog.txt", dateTime.Year.ToString(), dateTime.Month.ToString(), dateTime.Day.ToString());
                String fullpath = System.IO.Path.Combine(path, filename);

                lock (LogWriter.obj)
                {

                    using (System.IO.FileStream stream = System.IO.File.Open(fullpath, System.IO.FileMode.Append))
                    {

                        sw = new System.IO.StreamWriter(stream);
                        sw.AutoFlush = true;
                        sw.WriteLine(DateTime.Now.ToString() + " : " + message);
                        sw.Close();

                    }

                }
            }
            catch (Exception ex)
            {

                System.Diagnostics.Debug.WriteLine(ex.Message);

            }
        }
    }
}
