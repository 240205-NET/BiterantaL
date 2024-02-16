namespace MoiUpdateInfoPosterForGameUpdates.Logic
{
    public class ActionChangeTitle : MenuItemAction
    {

        public override void Action()
        {
            string title;
            Console.WriteLine("Type New Title: ");
            title = Console.ReadLine();
            StartNewUpdate.postObject.title = title;
            parentMenuItem.title = $"Title: {StartNewUpdate.postObject.title}";
        }


    }
}