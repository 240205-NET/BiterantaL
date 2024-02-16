namespace MoiUpdateInfoPosterForGameUpdates.Logic
{
    public class ActionSaveLocally : MenuItemAction
    {

        public override void Action()
        {
            Console.WriteLine(StartNewUpdate.postObject.ToString());

            StartNewUpdate.postObject.SaveLocally();



        }
    }
}