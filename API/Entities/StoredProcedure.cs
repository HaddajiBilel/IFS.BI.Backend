using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    public class StoredProcedure
    {
        [Key]
        public Guid StoredProcedureId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Parameter> Parameters { get; set; }
        public DateTime InsertDateTime { get; set; }
        public DateTime UpdateDateTime { get; set; }

    }
}
