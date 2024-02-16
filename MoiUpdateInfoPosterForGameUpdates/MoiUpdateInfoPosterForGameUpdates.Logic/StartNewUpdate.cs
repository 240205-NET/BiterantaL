using MoiUpdateInfoPosterForGameUpdates.Logic;
namespace MoiUpdateInfoPosterForGameUpdates
{
    public class StartNewUpdate
    {
        public static bool? testing;
        public static PostContainer postObject = new PostContainer(); //I want this object to be be able to be referenced and changed from the actions objects
        public static void PostMenu()
        {

            Menu postMenu = new Menu("Edit post details. Input the number from the list below to change the attribute.");
            postMenu.addMenuItem(new MenuItem($"Title: {postObject.title}", new ActionChangeTitle(), postMenu));
            postMenu.addMenuItem(new MenuItem($"Version: {postObject.version}", new ActionChangeVersion(), postMenu));
            postMenu.addMenuItem(new MenuItem($"Body: {postObject.body}", new ActionChangeBody(), postMenu));
            postMenu.addMenuItem(new MenuItem($"Save Locally", new ActionSaveLocally(), postMenu));
            postMenu.addMenuItem(new MenuItem($"Post to URL", new ActionPost(), postMenu));
            postMenu.addMenuItem(new MenuItem($"Clear All Attributes", new ActionClear(), postMenu));
            postMenu.addMenuItem(new MenuItem($"Back", new ActionBack(), postMenu));

            postMenu.showMenu();

        }
    }
}