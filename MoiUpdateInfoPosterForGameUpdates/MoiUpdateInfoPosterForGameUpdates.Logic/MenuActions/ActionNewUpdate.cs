namespace MoiUpdateInfoPosterForGameUpdates.Logic { 
    public class ActionNewUpdate : MenuItemAction
    {

        public override void Action()
        {
            Console.WriteLine("Create or edit an update Post");


            //I don't really want to have the main code in the action classes, so these will just be used to redirect to other classes that contain the code I want to change
            StartNewUpdate.PostMenu();







        }
    }
}