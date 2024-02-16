using System.Xml.Serialization;
namespace MoiUpdateInfoPosterForGameUpdates.Logic
{
    public class ActionShowPreviousUpdate : MenuItemAction
    {

        public override void Action()
        {
            Console.WriteLine("Show Previous");
            String path = Admin.programSettings.logPath;
            String loaded = "Failed to load anything.";
            try
            {
                System.IO.Directory.CreateDirectory(path);
                string[] ls = Directory.GetFiles(path);

                Console.WriteLine("\nType exact version number to load, or anything else to exit.\n");
                Console.WriteLine("==============");

                //list the files in the directory if 'ls' is not empty

                if (ls.Length > 0)
                {
                    for (int i = 0; i < ls.Length; i++)
                    {
                        Console.WriteLine(Path.GetFileNameWithoutExtension(ls[i]));
                    }
                }
                else
                {
                    Console.WriteLine("No files found.");
                }
                Console.WriteLine("==============\n");

                //get input to load file
                string? input = Console.ReadLine();

                //iterate through all files and compare input
                for (int i = 0; i < ls.Length; i++)
                {
                    if (input == Path.GetFileNameWithoutExtension(ls[i]))
                    {

                        Console.WriteLine("Saved version found. Loading in...\n");

                        //load file here
                        try
                        {


                            XmlSerializer serializer = new XmlSerializer(typeof(PostContainer));
                            using StreamReader reader = new StreamReader(Path.GetFullPath(ls[i]));
                            var record = (PostContainer)serializer.Deserialize(reader);
                            if (record is null)
                            {
                                throw new InvalidDataException();

                            }
                            else
                            {
                                //upload this settings objects to the loaded record
                                StartNewUpdate.postObject = record;
                                loaded = "";
                                //now load back into the Post Menu
                                reader.Close();
                                StartNewUpdate.PostMenu();

                            }


                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                }
                Console.WriteLine(loaded);


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}