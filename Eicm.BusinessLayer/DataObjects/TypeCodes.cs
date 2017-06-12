using System.Collections.Generic;

namespace Eicm.BusinessLogic.DataObjects
{
    public class TypeCodes
    {
        public List<TypeCodeValue> ItComponentTypes { get; set; }
        public List<TypeCodeValue> PriorityTypes { get; set; }
        public List<TypeCodeValue> RequestTypes { get; set; }
        public List<TypeCodeValue> SourceTypes { get; set; }
        public List<TypeCodeValue> StatusTypes { get; set; }
        public List<TypeCodeValue> SubComponentTypes { get; set; }
        
    }
}
