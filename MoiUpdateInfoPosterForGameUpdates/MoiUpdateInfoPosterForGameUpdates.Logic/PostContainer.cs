using System.Xml.Serialization;

namespace MoiUpdateInfoPosterForGameUpdates.Logic
{
    public class PostContainer
    {
        public string title { get; set; }
        public string version { get; set; }
        public string body { get; set; }

        private static XmlSerializer Serializer = new XmlSerializer(typeof(PostContainer));


        public PostContainer()
        {
            this.title = "New Update";
            this.version = "1.0.0.0";
            this.body = "...";
        }

        public override string ToString()
        {
            string s;
            s = $"Title: {this.title}\nVersion: {this.version}\nBody: {this.body}";

            return s;
        }

        public static string[] SerializeXML(PostContainer post)
        {
            var stringWriter = new StringWriter();
            Serializer.Serialize(stringWriter, post);
            stringWriter.Close();
            string[] s = { stringWriter.ToString() };
            return s;
        }

        public void SaveLocally()
        {
            String path = Admin.programSettings.logPath + this.version + ".xml";
            try
            {
                System.IO.Directory.CreateDirectory(Admin.programSettings.logPath);
                File.WriteAllLines(path, SerializeXML(this));
                Console.WriteLine($"Settings file saved at {path}");


            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());

            }



        }

        public void Clear()
        {
            this.title = "";
            this.version = "0.0.0.0";
            this.body = "";
        }
    }
}
