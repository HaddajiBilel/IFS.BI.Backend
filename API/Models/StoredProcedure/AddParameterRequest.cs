using API.Entities;

namespace API.Models.StoredProcedure
{
    public class AddParameterRequest
    {
        public ParameterSide ParameterSide { get; set; }
        public string Name { get; set; }
        public ParameterType ParameterType { get; set; }
        public bool Required { get; set; }
    }
}
