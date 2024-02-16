namespace MoiUpdateInfoPosterForGameUpdates.Logic

{
    public class ActionChangeBody : MenuItemAction
    {

        public override void Action()
        {
            string body;
            Console.WriteLine("Type body text: ");
            body = Console.ReadLine();
            StartNewUpdate.postObject.body = body;
            parentMenuItem.title = $"Body: {StartNewUpdate.postObject.body}";
        }

    }
}