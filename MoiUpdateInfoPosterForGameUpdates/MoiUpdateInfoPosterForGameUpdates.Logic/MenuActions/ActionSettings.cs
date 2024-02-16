namespace MoiUpdateInfoPosterForGameUpdates.Logic { 
    public class ActionSettings : MenuItemAction
    {
        bool testing = false;
        public override void Action()
        {
            Console.WriteLine("Settings");
            Menu settingsMenu = new Menu("Select a setting.");
            settingsMenu.addMenuItem(new MenuItem("Change login PIN", new ActionChangePin(), settingsMenu));
            settingsMenu.addMenuItem(new MenuItem("Change POST URL destination", new ActionChangePostURL(), settingsMenu));
            settingsMenu.addMenuItem(new MenuItem("Back", new ActionBack(), settingsMenu));
            settingsMenu.showMenu();
        }
    }
}