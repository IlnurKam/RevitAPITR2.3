using Autodesk.Revit.DB;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitAPITR2._3
{
    internal class ColumnsFilter : ISelectionFilter
    {

        public bool AllowElement(Element elem)
        {
            return elem is Сolumn;
        }

        public bool AllowReference(Reference reference, XYZ position)
        {
            return false;
        }
    }
}
