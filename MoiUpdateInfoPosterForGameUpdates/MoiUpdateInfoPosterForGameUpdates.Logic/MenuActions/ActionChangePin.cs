using MoiUpdateInfoPosterForGameUpdates;
namespace MoiUpdateInfoPosterForGameUpdates.Logic
{
    public class ActionChangePin : MenuItemAction
    {

        public override void Action()
        {
            //I don't really want to have the main code in the action classes, so these will just be used to redirect to other classes that contain the code I want to change

            Admin.programSettings.setAdminPinCode();
        }
    }
}