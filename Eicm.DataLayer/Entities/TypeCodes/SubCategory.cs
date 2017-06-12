using System.ComponentModel.DataAnnotations.Schema;

namespace Eicm.DataLayer.Entities.TypeCodes
{
    [Table("SubCategories", Schema = "TypeCodes")]
    public class SubCategory : EnumEntityBase
    {
        public int CategoryId { get; set; }
    }
}