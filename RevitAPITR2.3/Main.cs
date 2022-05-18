using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitAPITR2._3
{
    [Transaction(TransactionMode.Manual)]
    public class Main : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document doc = uidoc.Document;

            IList<Reference> selectedElementRefList = uidoc.Selection.PickObjects(ObjectType.Element, new ColumnFilter(), "Выберите элементы");
            var columnList = new List<Wall>();

            string info = string.Empty;
            foreach (var selectedElement in selectedElementRefList)
            {
                Column oColumn = doc.GetElement(selectedElement) as Wall;
                columnList.Add(oColumn);
                var width = UnitUtils.ConvertFromInternalUnits(oColumn.Width, UnitTypeId.Millimeters);
                info += $"Name:{oColumn.Name}, width: {width}{Environment.NewLine}";

            }
            info += $"Количество: {columnList.Count}";

            TaskDialog.Show("Selection", info);

            return Result.Succeeded;
        }
    }
}