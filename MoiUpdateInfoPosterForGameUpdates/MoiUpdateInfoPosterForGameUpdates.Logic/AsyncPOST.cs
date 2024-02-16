using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace MoiUpdateInfoPosterForGameUpdates.Logic
{
    public class AsyncPOST
    {
       public static async Task TryPost(Dictionary<string, string> values, String url)
        {
            // Convert data to form content
            var content = new FormUrlEncodedContent(values);

            // Create HttpClient instance
            using (HttpClient client = new HttpClient())
            {
                // Post data to the URL
                HttpResponseMessage response = await client.PostAsync(url, content);
              //  Console.WriteLine("test1");
                // Check response status
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Data posted successfully. Status code: " + response.StatusCode);
                }
                else
                {
                    Console.WriteLine("Failed to post data. Status Code: " + response.StatusCode);
                }
                string s = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Response "+s);
              //  Console.WriteLine("test2");
            }


        }



    }
}
