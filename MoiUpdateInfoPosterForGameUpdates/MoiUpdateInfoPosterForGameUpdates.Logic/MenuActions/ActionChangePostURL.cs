using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoiUpdateInfoPosterForGameUpdates.Logic
{
    internal class ActionChangePostURL : MenuItemAction
    {
        public override void Action()
        {

            Admin.programSettings.SetPostURL();


        }
    }
}
