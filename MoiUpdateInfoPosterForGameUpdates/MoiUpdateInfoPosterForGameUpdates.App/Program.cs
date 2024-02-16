using MoiUpdateInfoPosterForGameUpdates.Logic;
namespace MoiUpdateInfoPosterForGameUpdates
{
    public class Program
    {
        public static Settings settings = new Settings();
        public static void Main(string[] args)
        {
            String welcomeMessage = "Welcome, developer for MOI!";
            Console.WriteLine(welcomeMessage);


            //check settings object already exists externally

            Settings.checkFile(settings);

            //displays the pin code
            // Console.WriteLine(settings.adminPinCode);


            Runnable.Run(settings);

        }
    }
}