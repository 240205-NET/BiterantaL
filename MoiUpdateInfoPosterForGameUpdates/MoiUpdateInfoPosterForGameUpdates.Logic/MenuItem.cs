using MoiUpdateInfoPosterForGameUpdates.Logic;
namespace MoiUpdateInfoPosterForGameUpdates.Logic
{
    public class MenuItem
    {
        public string title { get; set; }
        public int number { get; set; }

        public Menu parentMenu { get; set; }

        public MenuItemAction action { get; set; }
        public MenuItem(string title, MenuItemAction action, Menu parentMenu)
        {
            this.parentMenu = parentMenu;
            this.title = title;
            this.action = action;
            this.action.parentMenuItem = this;
            this.action.grandParentMenu = parentMenu;
            //now each action is linked to its menuItem and its recepctive menu upon creation

        }


        //returns the menuItem number and title
        public string ListItem()
        {
            return $"({number}) {title}";

        }
    }
}