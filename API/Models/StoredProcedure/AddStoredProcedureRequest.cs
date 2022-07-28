namespace API.Models.StoredProcedure
{
    public class AddStoredProcedureRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<AddParameterRequest> Parameters { get; set; }
        public DateTime InsertDateTime { get; set; }
        public DateTime UpdateDateTime { get; set; }
    }
}
