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
using System.IO;
using static System.Net.WebRequestMethods;
//using CADToRevit.LoadFilePath;

namespace CADToRevit
{
    [TransactionAttribute(TransactionMode.Manual)]
    static public class GlobalVariable
    {
        //Load the dxf file from its path.
        public static string file = null;
    }
    [TransactionAttribute(TransactionMode.Manual)]
    public class CreateGrids : IExternalCommand
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
                //Get Crids layer form the dxf file.
                DxfDocument DxfFile = DxfDocument.Load(GlobalVariable.file);
                IEnumerable<netDxf.Entities.Line> AxixCad = DxfFile.Lines.Where(ins => ins.Layer.Name == "Axix");
                #endregion

                #region Create Grids from CAD Axix
                //Create the start and end grid point for each grid
                XYZ GridStartPoint, GridEndPoint;

                //Create a list to include all lines which represent the grids.
                List<Curve> GridLines = new List<Curve>();

                //Loop for all lines in the axix layer to draw a line and add to the GridLines list. 
                for (int i = 0; i < AxixCad.Count(); i++)
                {
                    //Get the lines from the Axix layer
                    netDxf.Entities.Line line = AxixCad.ElementAt(i);
                    //The start point of the axix layer line.
                    GridStartPoint = new XYZ(line.StartPoint.X, line.StartPoint.Y, line.StartPoint.Z);

                    //The end point of the axix layer line.
                    GridEndPoint = new XYZ(line.EndPoint.X, line.EndPoint.Y, line.EndPoint.Z);

                    //Create a line from the two point to represent the grid.
                    Autodesk.Revit.DB.Line GridLine = Autodesk.Revit.DB.Line.CreateBound(GridStartPoint, GridEndPoint);
                    GridLines.Add(GridLine); //Add the line to the GridLines list.
                }




                //Creating the Revit Grids.

                using (Transaction t = new Transaction(doc, "Draw Grids from dxf file"))
                {
                    t.Start();
                    foreach (Autodesk.Revit.DB.Line line in GridLines)
                    {
                        Grid.Create(doc, line);
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
