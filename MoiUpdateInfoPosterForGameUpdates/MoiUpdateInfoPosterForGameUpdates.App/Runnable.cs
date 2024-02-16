using MoiUpdateInfoPosterForGameUpdates.Logic;
namespace MoiUpdateInfoPosterForGameUpdates
{
    public class Runnable
    {
        public static void Run(Settings settings)
        {
            //this is a loop that keeps the application running. Breaking essentially ends the application.
            while (true)
            {

                string enterPinCode = "Enter super secret Pincode...\n";
                string invalidPin = "Invalid Pin";
                string? enteredPinCode = "";
                string pinCode = settings.getAdminPinCode();

                //loop that gets pin and checks it againts the correct pin
                while (true)
                {

                    do
                    {
                        try
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine(enterPinCode);
                            Console.ForegroundColor = ConsoleColor.White;
                            enteredPinCode = Console.ReadLine();



                            if (!enteredPinCode.Equals(pinCode))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine(invalidPin);
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                        }
                        catch (Exception e)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid");
                            Console.WriteLine(e.Message);
                            Console.ForegroundColor = ConsoleColor.White;

                        }

                    } while (!enteredPinCode.Equals(pinCode));
                    //
                    break;
                }

                //enter admin class here
                Admin.Menu(settings);

                break;
            }
        }
    }
}