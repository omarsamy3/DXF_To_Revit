using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using netDxf;
using System;
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

namespace CADToRevit
{
    [TransactionAttribute(TransactionMode.Manual)]
    class CreateWalls : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            try
            {
                #region UIDocument and Document     
                //Determine the UIDocument and the Document in revit to draw our elements.
                UIDocument uidoc = commandData.Application.ActiveUIDocument;
                Document doc = uidoc.Document;
                #endregion

                #region Loading Layers From dxf file
                //Load the dxf file from its path.
                 DxfDocument DxfFile = DxfDocument.Load(GlobalVariable.file);

                //Get the Walls layer from cad.
                IEnumerable<netDxf.Entities.Line> WallsCad = DxfFile.Lines.Where(ins => ins.Layer.Name == "Walls");
                #endregion

                #region Create Walls from CAD Walls layer
                //Create a list to include all lines for drawing the walls.
                List<Curve> WallLines = new List<Curve>();

                //Loop for all CAD wall to get its verteces and draw a line from them.
                for (int j = 0; j < WallsCad.Count(); j++)
                {

                    netDxf.Entities.Line wall = WallsCad.ElementAt(j);

                    //First vertex of the MLine wall
                    double FirstPointX = wall.StartPoint.X; //The X coordinate of the first line coordiante.
                    double FirstPointY = wall.StartPoint.Y; //The Y coordinate of the first line coordiante.
                    XYZ WallFirstPoint = new XYZ(FirstPointX, FirstPointY, 0); //Target first point of the wall line.

                    //Last vertex of the MLine wall																			  
                    double SecondPointX = wall.EndPoint.X; //The X coordinate of the second line coordinate.
                    double SecondPointY = wall.EndPoint.Y; //The Y coordinate of the second line coordinate.
                    XYZ WallSecondPoint = new XYZ(SecondPointX, SecondPointY, 0); //Target second point of the wall line.

                    //Create Line from the two points
                    Autodesk.Revit.DB.Line WallLine = Autodesk.Revit.DB.Line.CreateBound(WallFirstPoint, WallSecondPoint);
                    //Apend the line to the wall lines list
                    WallLines.Add(WallLine);
                }

                //Determine the level in which we draw the walls.
                Level FirstLevel = new FilteredElementCollector(doc)
                                   .OfCategory(BuiltInCategory.OST_Levels)
                                   .WhereElementIsNotElementType()
                                   .Cast<Level>().First(e => e.Name == "Level 1");


                using (Transaction t = new Transaction(doc, "Draw Walls from dxf file"))
                {
                    t.Start();
                    foreach (Curve curve in WallLines)
                    {
                        Wall.Create(doc, curve, FirstLevel.Id, false);
                    }
                    t.Commit();
                }

                #endregion

                return Result.Succeeded;
            }
            catch (Exception e)
            {
                return Result.Failed;
            }
        }
    }
}
