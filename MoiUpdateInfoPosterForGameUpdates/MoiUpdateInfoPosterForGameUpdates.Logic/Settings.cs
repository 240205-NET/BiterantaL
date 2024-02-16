using System;
using System.Xml.Serialization;

namespace MoiUpdateInfoPosterForGameUpdates.Logic
{
    public class Settings
    {
        
        public string adminPinCode;
        public string posturl { get; set; } = "https://moi.lawranta.com/updatePatchNotes.php";
        private static string defaultPinCode = "420420";
        private static string defaultPath = @"./";
        private string path { get; set; }
        public string logPath { get; set; } = @"./saved/";
        private static string fileName = "settings.xml";

        private static XmlSerializer Serializer = new XmlSerializer(typeof(Settings));
        public Settings()
        {
            this.path = defaultPath + fileName;
            this.adminPinCode = defaultPinCode;
            //first check if saved settings file exists
        }

        private static Settings loadFromFile(string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Settings));
            using StreamReader reader = new StreamReader(path);
            var record = (Settings)serializer.Deserialize(reader);
            if (record is null)
            {
                throw new InvalidDataException();

            }
            else
            {
                //upload this settings objects to the loaded record
                return record;
                Console.WriteLine("loaded settings...");


            }
        }

        public void setAdminPinCode()
        {
            do
            {
                int newPinAsNumeral = 0;
                string newPinAsString = "";
                try
                {   //ask for pin code here

                    Console.WriteLine("Enter 6 digit pin code here");
                    newPinAsString = Console.ReadLine();
                    if (int.TryParse(newPinAsString, out newPinAsNumeral))
                    {
                        //check pin is valid
                        if (newPinAsNumeral >= 0 && newPinAsNumeral < 1000000)
                        {

                            Console.Out.WriteLine($"{newPinAsString} is a valid pin");
                            this.adminPinCode = newPinAsString;
                            Console.WriteLine("New pin set.");
                            this.SaveSettings();
                            break;
                        }


                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }





            } while (true);



        }



        public void SetPostURL()
        {
            Console.WriteLine("Current POST url is:");
            Console.WriteLine(this.posturl);
            Console.WriteLine("Change URL, yes (y) or No (n)?\n");
            Char option = Console.ReadKey().KeyChar;
            Console.WriteLine();
            if (option == 'y')
            {
                bool result = false;
                do
                {
                    Console.WriteLine("Type new FULL URL.\n");
                    string uriName;
                    uriName = Console.ReadLine();

                    Uri uriResult;
                    result = Uri.TryCreate(uriName, UriKind.Absolute, out uriResult)
                        && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);

                    if (result == false)
                    {
                        Console.WriteLine($"{uriName} is not a valid URL\n");
                    }
                    else
                    {
                        Console.WriteLine($"New URL will be: {uriResult.ToString()}\n");



                        Console.WriteLine("Confirm change, yes (y) or No (n)?\n");
                        Char op2 = Console.ReadKey().KeyChar;
                        Console.WriteLine();
                        if (op2 == 'y')
                        {
                            this.posturl = uriResult.ToString();
                            SaveSettings();
                            Console.WriteLine($"Saved {uriResult.ToString()}\n");


                        }





                    }

                } while (result != true);







            }
        }











        public void setAdminPinCode(string pincode)
        {
            this.adminPinCode = pincode;

        }

        public string getAdminPinCode()
        {

            return this.adminPinCode;
        }

        public static string[] SerializeXML(Settings settings)
        {
            var stringWriter = new StringWriter();
            Serializer.Serialize(stringWriter, settings);
            stringWriter.Close();
            string[] s = { stringWriter.ToString() };
            return s;
        }

        public static void checkFile(Settings setting)
        {
            string path = setting.path;
            if (File.Exists(path))
            {

                Console.WriteLine($"Settings file exists at {path}");
                Settings loadedSettings = loadFromFile(path);
                //loaded pin code, comment this line out later
                //Console.WriteLine($"Loaded code: {loadedSettings.adminPinCode}");
                setting.posturl = loadedSettings.posturl;
                setting.setAdminPinCode(loadedSettings.getAdminPinCode());
            }
            else
            {
                Console.WriteLine($"Settings file does not exist at {path}");
                setting.adminPinCode = defaultPinCode;
                File.WriteAllLines(path, SerializeXML(setting));
                Console.WriteLine($"New settings file created at {path}");
            }

        }



        private void SaveSettings()
        {
            try
            {
                File.WriteAllLines(path, SerializeXML(this));
                Console.WriteLine($"Settings file saved at {path}");


            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());

            }



        }




    }
}