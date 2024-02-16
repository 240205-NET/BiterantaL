using MoiUpdateInfoPosterForGameUpdates.Logic;
using System.Diagnostics;

namespace MoiUpdateInfoPosterForGameUpdates
{
    public class Admin
    {
        public static Settings programSettings;
        public static void Menu(Settings settings)
        {
            programSettings = settings;
            Menu mainMenu = new Menu("Enter menu number to select menu item.");
            mainMenu.addMenuItem(new MenuItem("New Update Post", new ActionNewUpdate(), mainMenu));
            mainMenu.addMenuItem(new MenuItem("Load Local updates", new ActionShowPreviousUpdate(), mainMenu));
            mainMenu.addMenuItem(new MenuItem("Settings", new ActionSettings(), mainMenu));
            mainMenu.addMenuItem(new MenuItem("Exit", new ActionExit(), mainMenu));


            String[] menuItems = { "1. Update Post", "2. Show previous updates", "3. Settings", "0. Exit" };

            mainMenu.showMenu();


        }







    }
}