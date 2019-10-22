using System;
using System.ComponentModel.Design;
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



        private static String ErrorLinje, ErrorMsg, ErrorType, ErrorLokasjon;

        public static void ErrorTilFil(Exception e)
        {
            var linje = Environment.NewLine + Environment.NewLine;

            ErrorLinje = e.StackTrace.Substring(e.StackTrace.Length-100,100);
            ErrorMsg = e.GetType().Name.ToString();
            ErrorType = e.GetType().ToString();
            ErrorLokasjon = e.Message.ToString();

            try
            {
                string filepath = @"C:\Logg\";

                if (!Directory.Exists(filepath))
                {
                    Directory.CreateDirectory(filepath);
                }

                filepath = filepath + DateTime.Now.ToString("dd-MM-yyyy") + ".txt";

                if (!File.Exists(filepath))
                {
                    File.Create(filepath).Dispose();
                }

                using (StreamWriter sw = File.AppendText(filepath))
                {
                    var error = "Logg dato: " + " " + DateTime.Now.ToString()
                                + linje + "Error linje :" + " " + ErrorLinje + linje
                                + "Error melding:" + " " + ErrorMsg + linje
                                + "Exception type:" + " " + ErrorType + linje
                                + "Error lokasjon :" + " " + ErrorLokasjon + linje;

                    sw.WriteLine("Exception på datoen:  " + " " + DateTime.Now.ToString());
                    sw.WriteLine(linje);
                    sw.WriteLine(error);
                    sw.Write(linje);
                    sw.Flush();
                    sw.Close();

                }
            }
            catch (Exception exception)
            {
                exception.ToString();
            }
        }

    }
}