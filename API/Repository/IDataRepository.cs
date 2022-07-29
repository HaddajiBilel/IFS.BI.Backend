using API.Models.Data;

namespace API.Repository
{
    public interface IDataRepository
    {
        public string GetJsonData(string _name, List<InputParameter> _parameters);
    }
}
