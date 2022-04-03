using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace netwise
{
    class Program
    {
        // Write to file
        public static void writeToFile(string fact)
        {
            StreamWriter sw = File.AppendText("E:\\Netwise.txt");
            sw.WriteLine(fact);
            sw.Close();
        }
        
        //http response
        static readonly HttpClient client = new HttpClient();

        static async Task Main()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("https://catfact.ninja/fact");
                //response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                writeToFile(responseBody);
                //Console.WriteLine(responseBody);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
        }
    }
}
