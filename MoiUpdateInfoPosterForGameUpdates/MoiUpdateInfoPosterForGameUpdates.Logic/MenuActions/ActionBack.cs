namespace MoiUpdateInfoPosterForGameUpdates.Logic
{
    public class ActionBack : MenuItemAction
    {

        public override void Action()
        {
            Console.WriteLine("Back");
            grandParentMenu.option = 0; //sets the parent menu option to 0 which breaks the menu loop

        }
    }
}