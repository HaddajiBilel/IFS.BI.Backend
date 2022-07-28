using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    public class Parameter
    {
        [Key]
        public Guid ParameterId { get; set; }
        [Required]
        public ParameterSide ParameterSide { get; set; }
        [Required]
        public string Name { get; set; }
        public ParameterType ParameterType { get; set; }
        public bool Required { get; set; }
        public DateTime InsertDateTime { get; set; }
        public DateTime UpdateDateTime { get; set; }
        public StoredProcedure StoredProcedure { get; set; }

    }

    public enum ParameterSide
    {
        Input, Output
    }

    public enum ParameterType
    {
        CustomerList, AccountList, AccountOwnCategory, DateTimePicker, CheckBox
    }
}
