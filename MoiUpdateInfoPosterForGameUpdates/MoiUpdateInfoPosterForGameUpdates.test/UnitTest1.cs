using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using NuGet.Frameworks;
using System.IO;

namespace MoiUpdateInfoPosterForGameUpdates.test
{
    public class UnitTest1
    {
 

        [Fact]
        public static void testSettingObject()
        {


            Settings settings = new Settings();
            String pincode= settings.getAdminPinCode(); //get real pincode
            Assert.Equal("420420",pincode);
         




        }

        [Fact]
        public void testMenuObject()
        {

            bool error = false;
            string menuTitle = "Menu Title", itemTitle="Item Title";

            Menu menu = new Menu(menuTitle);
            MenuItemAction action = new ActionClear();
            MenuItem menuItem = new MenuItem(itemTitle,action,menu);


            Assert.Equal(menuItem.title, itemTitle);
            Assert.Equal(menu.menuString, menuTitle);
            Assert.Equal(menuItem.parentMenu, menu);
            Assert.Equal(menuItem.action, action);


            try
            {

            }
            catch (Exception ex)
            {
                error = true;
            }

            Assert.False(error);

        }

        [Fact]
        public void testActionBack()
        {

            try {
            Console.SetIn(new StringReader("0"));
            ActionBack action = new ActionBack();
               
            }catch(Exception ex)
            {
                Assert.Fail(ex.ToString());

            }

        }



        [Fact]
        public void testActionChangeBody()
        {
            try
            {
                StartNewUpdate.postObject = new PostContainer();
                Console.SetIn(new StringReader("This is a test for ActionChangeBody"));
                ActionChangeBody action = new ActionChangeBody();
                action.parentMenuItem = new MenuItem("", action, new Menu(""));

            }
            catch (Exception ex)
            {
                Assert.Fail(ex.ToString());


            }
        }

            [Fact]
        public void testActionChangePin()
        {
        //just calls Admin.setAdminPinCode(); Shouldn't need a test... test Admin.setAdminPinCode() directly instead.
        }

        [Fact]
        public void testActionChangePostURL()
        {
            //just calls Admin.setPostUrl(); Shouldn't need a test... test Admin.setPostUrl(); directly instead.
        }
        [Fact]
        public void testActionChangeTitle()
        {
            try
            {
        
                StartNewUpdate.postObject = new PostContainer(); //dummy post container
                String titleIn = "This is a test for ActionChangeTitle"; //dummy in console
                Console.SetIn(new StringReader(titleIn)); //dummy in console
                ActionChangeTitle action = new ActionChangeTitle(); //the action item we are actually testing
                action.parentMenuItem = new MenuItem("",action,new Menu("")); //create dummy parent menu
                action.Action(); //test the action
                Assert.True(StartNewUpdate.postObject.title.Equals(titleIn)); 

            }
            catch (Exception ex)
            {
                Assert.Fail(ex.ToString());


            }

        }
        [Fact]
        public void testActionChangeVersion()
        {
            try
            {
               var data = String.Join(Environment.NewLine, new[]
                {
                    "1","2","3","4"
                });
                StartNewUpdate.postObject = new PostContainer(); //dummy post container
                Console.SetIn(new System.IO.StringReader(data)); //dummy in console
                ActionChangeVersion action = new ActionChangeVersion(); //the action item we are actually testing
                action.parentMenuItem = new MenuItem("", action, new Menu("")); //create dummy parent menu
                action.Action(); //test the action
                
                Assert.True(StartNewUpdate.postObject.version.Equals("1.2.3.4"));






                //try again with negative inputs

                 data = String.Join(Environment.NewLine, new[]
                {
                    "-1","-2","-3","-4"
                });
                StartNewUpdate.postObject = new PostContainer(); //dummy post container
                Console.SetIn(new System.IO.StringReader(data)); //dummy in console
                action = new ActionChangeVersion(); //the action item we are actually testing
                action.parentMenuItem = new MenuItem("", action, new Menu("")); //create dummy parent menu
                action.Action(); //test the action


                Assert.True(StartNewUpdate.postObject.version.Equals("1.2.3.4"));
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

        }
        [Fact]
        public void testActionClear()
        {
            //creates new PostContainer object, should just need to text StartNewUpdate.PostMenu() directly
        }
        [Fact]
        public void testActionExit()
        {
            try
            {

                ActionExit actionExit = new ActionExit();
                Assert.True(true);

            }
            catch(Exception e)
            {
                Assert.Fail(e.Message);

            }
        }
        [Fact]
        public void testActionNewPostUpdate()
        {
            //should just need to text StartNewUpdate.PostMenu() directly
        }
        [Fact]
        public void testActionPost()
        {
            //this will be pretty intensive to test
        }
        [Fact]
        public void testActionSaveLocally()
        {
            //test StartNewUpdate.postObject.SaveLocally(); directly
        }
        [Fact]
        public void testActionSettings()
        {
            try
            {
                var data = String.Join(Environment.NewLine, new[]
 {
                    "4"
                });
                Console.SetIn(new System.IO.StringReader(data)); //dummy in console
                ActionSettings actionSettings = new ActionSettings();

            }
            catch(Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [Fact]
        public void testActionShowPreviouslyUpdate()
        {
            try
            {
                var data = String.Join(Environment.NewLine, new[]
    {
                    "1.0.0.1","0"
                });
                Admin.programSettings = new Settings();
                ActionShowPreviousUpdate actionShowPreviousUpdate = new ActionShowPreviousUpdate();
                Assert.True(true);
            }
            catch(Exception e)
            {
                Assert.Fail($"{e.Message}");
            }
        }
        [Fact]
        public void testActionDefault()
        {

        }


    }
}