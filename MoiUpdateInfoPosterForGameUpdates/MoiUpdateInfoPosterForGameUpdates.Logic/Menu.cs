namespace MoiUpdateInfoPosterForGameUpdates.Logic
{
    public class Menu
    {
        List<MenuItem> menuItemList;
       public string menuString;
        public int option { get; set; }
        public Menu(string s)
        {
            menuItemList = new List<MenuItem>();
            menuString = s;
        }
        public void addMenuItem(MenuItem item)
        {
            menuItemList.Add(item);
            item.number = menuItemList.Count;
        }

        public void showMenu()
        {
                do
                {
                    option = 0;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(menuString);

                    // Console.BackgroundColor = ConsoleColor.White;
                    for (int i = 0; i < menuItemList.Count; i++)
                    {
                        if (i % 2 == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Magenta;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                        }


                        Console.WriteLine(menuItemList[i].ListItem());
                    }
                    //  Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    try
                    {
                        option = int.Parse(Console.ReadKey().KeyChar.ToString());
                        Console.WriteLine();

                    }
                    catch (Exception e)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid");
                        Console.WriteLine(e.Message + " (Empty?)");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Made it here");
                        showMenu(); //restart the method

                    }
                    Console.ResetColor();



                    if (option <= menuItemList.Count && option >= 0 && option != null)
                    {
                        try
                        {
                            //OPTION != INDEX, so subtract 1 to get the correct number choice. I wanted to avoid using 0 as an option, so I set each item's number to the length of the menuList as it was added. This makes the number equiveland to its index + 1
                            //itterate through the menu item list
                            int selection = option;

                            for (int i = 0; i < menuItemList.Count; i++)
                            {
                                if (selection == menuItemList[i].number)
                                {
                                    menuItemList[i].action.Action(); //for the current menuItem iteration, if selection is the same as number, get the action object that is linked to that menu item and call it's Action() method;
                                    break;
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Enter correct menu choice.");
                        }

                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("--------------\nInvalid choice\n--------------");
                        Console.ResetColor();
                    }
                } while (option != 0);

        }


    }
}