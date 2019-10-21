using System;
using System.IO;

namespace Model
{
    public class Logging
    {
        public int ID { get; set; }
        public string Entitet { get; set; }
        public string Egenskap { get; set; }
        public string Nokkelverdi { get; set; }
        public string GammelVerdi { get; set; }
        public string NyVerdi { get; set; }
        public DateTime DatoEndret { get; set; }




        private static String ErrorLinje, ErrorMsg, ErrorType, ErrorUrl, HostIp, ErrorLokasjon, HostAdd;

        public static void errorTilFil(Exception e)
        {
            var linje = Environment.NewLine + Environment.NewLine;

            ErrorLinje = e.StackTrace.Substring(e.StackTrace.Length - 7, 7);
            ErrorMsg = e.GetType().Name.ToString();
            ErrorType = e.GetType().ToString();
            ErrorLokasjon = e.Message.ToString();

            try
            {
                string filepath = @"C:\Error.txt";
                if (!Directory.Exists(filepath))
                {
                    Directory.CreateDirectory(filepath);
                }

                filepath = filepath + DateTime.Today.ToString("dd-MM-yy") + ".txt";

                if (!File.Exists(filepath))
                {
                    File.Create(filepath).Dispose();
                }

                using (StreamWriter sw = File.AppendText(filepath))
                {
                    var error = "Logg dato: " + " " + DateTime.Now.ToString() + linje + "Error linje nr: " + " " +
                                   ErrorLinje + linje + "Error melding: " + ErrorMsg + linje + "Error type: " + " " +
                                   ErrorType + linje + "Error lokasjon: " + " " + ErrorLokasjon + linje +
                                   "Bruker ip: " + " " + HostIp + linje;
                    sw.WriteLine("Exception ved datoen:  " + " " + DateTime.Now.ToString());
                    sw.WriteLine(linje);
                    sw.WriteLine(error);
                    sw.WriteLine();

                    sw.Flush();
                    sw.Close();
                }


            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

    }

 }