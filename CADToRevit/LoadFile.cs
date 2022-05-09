using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CADToRevit
{
    [TransactionAttribute(TransactionMode.Manual)]
    class LoadFile : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            //Determine the UIDocument and the Document in revit to draw our elements.
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;

            LoadFilePath loadfilepath = new LoadFilePath(doc);

            loadfilepath.ShowDialog();

            return Result.Succeeded;
        }
    }
}
