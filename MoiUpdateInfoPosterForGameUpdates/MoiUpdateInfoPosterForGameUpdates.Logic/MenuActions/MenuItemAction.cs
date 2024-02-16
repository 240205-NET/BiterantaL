using MoiUpdateInfoPosterForGameUpdates.Logic;
namespace MoiUpdateInfoPosterForGameUpdates.Logic { 
    public abstract class MenuItemAction
    {

        public static bool? testing;
        public string Name { get; set; }

        public Menu grandParentMenu { get; set; }
        public MenuItem parentMenuItem { get; set; }
        public abstract void Action();

    }
}