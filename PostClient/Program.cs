using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PostClient
{
    class Program
    {
        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            string Name = ConfigurationManager.AppSettings["Name"];
            string Comment  = ConfigurationManager.AppSettings["Comment"];
            string URL = ConfigurationManager.AppSettings["URL"];
            

            using (HttpClient client = new HttpClient())
            {
                client.Timeout = new TimeSpan(0,0,10000);
                var formContent = new FormUrlEncodedContent(new[] { 
                        new KeyValuePair<string,string>("Name",Name),
                        new KeyValuePair<string,string>("Comment",Comment),
                });
               
                try
                {
                    HttpResponseMessage response = client.PostAsync(URL, formContent).GetAwaiter().GetResult();
                    Console.WriteLine(response.StatusCode);
                    response.EnsureSuccessStatusCode();
                    
                }
                catch (Exception e) 
                {
                    Console.WriteLine(e.InnerException);
                    File.WriteAllText("error.log", e.InnerException.ToString());
                }

            }
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            File.WriteAllText("error.log", e.ExceptionObject.ToString());
        }
    }
}
