using System.ComponentModel.DataAnnotations.Schema;

namespace Eicm.DataLayer.Entities
{
    public abstract class EnumEntityBase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
    }
}