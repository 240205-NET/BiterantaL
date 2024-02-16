namespace MoiUpdateInfoPosterForGameUpdates.Logic { 
    public class ActionClear : MenuItemAction
    {
        static bool? testing;
        public override void Action()
        {
            StartNewUpdate.postObject = new PostContainer();
            StartNewUpdate.postObject.Clear();
            StartNewUpdate.testing = testing; //unit testing?
            Console
                .WriteLine("Post container cleared");
            StartNewUpdate.PostMenu();
            grandParentMenu.option = 0;
        }


    }
}