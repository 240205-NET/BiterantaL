using System.Buffers.Text;
using System.Reflection.PortableExecutable;
using System;

namespace MoiUpdateInfoPosterForGameUpdates.Logic
{
    public class ActionPost : MenuItemAction
    {

        public override void Action()
        {

            //when I post to the database, I want to inlude the current time and date

            DateTime currentDateTime = DateTime.Now;
            Console.WriteLine("--------------");
            string formattedDateTime = currentDateTime.ToString("yyyy-MM-dd HH:mm:ss");
            Console.WriteLine(StartNewUpdate.postObject);
            Console.WriteLine("DateTime " + formattedDateTime);
            Console.WriteLine("--------------");
            Console.WriteLine($"Post to \"{Admin.programSettings.posturl}\"?");
            Console.WriteLine("Yes (y) or No (n)?\n");
            Char option = Console.ReadKey().KeyChar;
            Console.WriteLine();
            if (option == 'y')
            {
                //post here
                Console.WriteLine("Encoding in base64...");
                Console.WriteLine("...");
                String encodedDateTime = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(formattedDateTime));
                String encodedVersion = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(StartNewUpdate.postObject.version));
                String encodedHeader = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(StartNewUpdate.postObject.title));
                String encodedDescription = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(StartNewUpdate.postObject.body));


                var values = new Dictionary<string, string>
                  {
                      { "datetime", encodedDateTime },
                      { "version", encodedVersion },
                      { "header", encodedHeader },
                      { "description", encodedDescription }
                  };

                string postURL = Admin.programSettings.posturl;

                try
                {
                    var task = AsyncPOST.TryPost(values, postURL);
                    Console.WriteLine("Attempting post...");
                    task.Wait();
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }

                
            }






        }


    }
}