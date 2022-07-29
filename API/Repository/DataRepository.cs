using API.Models.Data;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using System.Data;

namespace API.Repository
{
    public class DataRepository: IDataRepository
    {

        private readonly IConfiguration _configuration;
        public DataRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        private SqlCommand InitializeConnection(string _name, List<InputParameter> _parameters)
        {
            var sqlConnection = new SqlConnection(_configuration.GetConnectionString("ReportingBI"));
            sqlConnection.Open();
            var _sqlCommand = new SqlCommand(_name, sqlConnection);
            foreach (var item in _parameters)
            {
                _sqlCommand.Parameters.Add(new SqlParameter($"@{item.Name}", GetParamType(item.Value)) { Direction = ParameterDirection.Input, Value = ConvertValue(item.Value) });
            }

            _sqlCommand.CommandType = CommandType.StoredProcedure;
            return _sqlCommand;
        }

        private object ConvertValue(dynamic value)
        {
            return value.ToString();
        }

        public string GetJsonData(string _name, List<InputParameter> _parameters)
        {
            DataTable _data = new DataTable();
            var sqlCommand = InitializeConnection(_name, _parameters);

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sqlCommand;

            da.Fill(_data);
            string JSONString = JsonConvert.SerializeObject(_data);
            return JSONString;
        }


        private SqlDbType GetParamType(dynamic value)
        {
            if (value is int)
            {
                return SqlDbType.Int;

            }
            if (value is DateTime)
            {
                return SqlDbType.DateTime;
            }
            if (value is bool)
            {
                return SqlDbType.Bit;
            }
            if (value is decimal)
            {
                return SqlDbType.Decimal;
            }
            if (value is float)
            {
                return SqlDbType.Float;
            }
            return SqlDbType.VarChar;

        }

    }
}
