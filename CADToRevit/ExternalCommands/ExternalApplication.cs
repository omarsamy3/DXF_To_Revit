using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using netDxf.Header;
using netDxf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using netDxf.Collections;
using netDxf.Tables;
using Autodesk.Revit.Attributes;
using netDxf.Entities;
using System.Reflection;
using System.Windows.Media.Imaging;

namespace CADToRevit
{
    public class ExternalApplication : IExternalApplication
    {
        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }

        public Result OnStartup(UIControlledApplication application)
        {
            //Create The Plugin Tab.
            application.CreateRibbonTab("CAD To Revit");

            #region Load the file path
            //Create The Plugin Panel.
            RibbonPanel Panel = application.CreateRibbonPanel("CAD To Revit", "Architecture");
            Assembly assembly = Assembly.GetExecutingAssembly();

            //Create The Plugin Button.
            PushButtonData Button4 = new PushButtonData("Button4", "Load file", assembly.Location, "CADToRevit.LoadFile");
            PushButton pushButton4 = Panel.AddItem(Button4) as PushButton;

            Uri UriPath4 = new Uri("pack://application:,,,/CADToRevit;component/PluginIcons/LoadFile.png");
            BitmapImage Image4 = new BitmapImage(UriPath4);
            pushButton4.LargeImage = Image4;
            #endregion

            #region Create The Grids
            

            //Create The Plugin Button.

            PushButtonData Button1 = new PushButtonData("Button1", "Draw Grids", assembly.Location, "CADToRevit.CreateGrids");
            PushButton pushButton1 = Panel.AddItem(Button1) as PushButton;

            Uri UriPath1 = new Uri("pack://application:,,,/CADToRevit;component/PluginIcons/Grids.png");
            BitmapImage Image1 = new BitmapImage(UriPath1);
            pushButton1.LargeImage = Image1;
            #endregion

            #region Create The Walls
            //Create The Plugin Button.
            PushButtonData Button2 = new PushButtonData("Button2", "Draw Walls", assembly.Location, "CADToRevit.CreateWalls");
            PushButton pushButton2 = Panel.AddItem(Button2) as PushButton;

            Uri UriPath2 = new Uri("pack://application:,,,/CADToRevit;component/PluginIcons/Walls.png");
            BitmapImage Image2 = new BitmapImage(UriPath2);
            pushButton2.LargeImage = Image2;
            #endregion

            #region Create The Floor
            //Create The Plugin Button.
            PushButtonData Button3 = new PushButtonData("Button3", "Draw Floors", assembly.Location, "CADToRevit.CreateFloor");
            PushButton pushButton3 = Panel.AddItem(Button3) as PushButton;

            Uri UriPath3 = new Uri("pack://application:,,,/CADToRevit;component/PluginIcons/Floors.png");
            BitmapImage Image3 = new BitmapImage(UriPath3);
            pushButton3.LargeImage = Image3;
            #endregion 

            return Result.Succeeded;
        }
    }
}
