using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;

namespace RevitAddInsWPFSample
{
    [Transaction(TransactionMode.Manual)]
    public class Class1:IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            // the current document
            Document document = commandData.Application.ActiveUIDocument.Document;

            // wpf viewer form
            Viewer viewer = new Viewer(document);
            viewer.ShowDialog();

            // return result
            return Result.Succeeded;
        }
    }
}
