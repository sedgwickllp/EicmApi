using System.Collections.Generic;

namespace Eicm.BusinessLogic.DataObjects
{
    public class TypeCodes
    {
        public List<TypeCodeValue> CategoryTypes { get; set; }
        public List<TypeCodeValue> PriorityTypes { get; set; }
        public List<TypeCodeValue> OriginTypes { get; set; }
        public List<TypeCodeValue> CauseTypes { get; set; }
        public List<TypeCodeValue> StatusTypes { get; set; }
        public List<TypeCodeValue> SubCategoryTypes { get; set; }
        
    }
}
