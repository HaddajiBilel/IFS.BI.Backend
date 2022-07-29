namespace API.Models.Data
{
    public class GetDataRequest
    {
        public string Name { get; set; }
        public List<InputParameter> ParamList { get; set; }
    }

    public class InputParameter
    {
        public string Name { get; set; }
        public dynamic Value { get; set; }
    }
}
