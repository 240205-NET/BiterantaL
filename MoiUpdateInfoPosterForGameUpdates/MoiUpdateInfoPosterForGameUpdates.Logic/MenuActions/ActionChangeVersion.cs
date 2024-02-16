namespace MoiUpdateInfoPosterForGameUpdates.Logic { 
    public class ActionChangeVersion : MenuItemAction
    {


        public override void Action()
        {
            int a, b, c, d;
            string version;
            Console.WriteLine("The version number contains four integers separated by decimals (eg. 1.0.0.1). ");


            //this is a series of do-while loops in order to force the user to correctly input the version number
            do
            {
                try
                {
                    Console.WriteLine("Type the first number: ");
                    a = Math.Abs(Int32.Parse(Console.ReadLine())); //parse int, use absolute value cuz negative versions are lame
                    break;
                }
                catch
                {
                    Console.WriteLine("invalid input");
                }
            } while (true);
            do
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{a}.");
                    Console.ResetColor();
                    Console.WriteLine("Type the second number: ");
                    b = Math.Abs(Int32.Parse(Console.ReadLine())); 
                    break;
                }
                catch
                {
                    Console.WriteLine("invalid input");
                }
            } while (true);
            do
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{a}.{b}.");
                    Console.ResetColor();
                    Console.WriteLine("Type the third number: ");
                    c = Math.Abs(Int32.Parse(Console.ReadLine()));
                    break;
                }
                catch
                {
                    Console.WriteLine("invalid input");
                }
            } while (true);
            do
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{a}.{b}.{c}");
                    Console.ResetColor();
                    Console.WriteLine("Type the fourth number: ");
                    d = Math.Abs(Int32.Parse(Console.ReadLine())); 
                    break;
                }
                catch
                {
                    Console.WriteLine("invalid input");
                }
            } while (true);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{a}.{b}.{c}.{d}");
            Console.ResetColor();
            version = $"{a}.{b}.{c}.{d}";


            StartNewUpdate.postObject.version = version;
            parentMenuItem.title = $"Version: {StartNewUpdate.postObject.version}";
        }
    }
}