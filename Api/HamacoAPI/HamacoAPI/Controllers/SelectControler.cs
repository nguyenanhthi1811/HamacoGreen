using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HamacoAPI.Filters;
using Newtonsoft.Json;

namespace HamacoAPI.Controllers
{
    [BasicAuthentication]
    public class SelectController : ApiController
    {

        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

      
        public string Get(string id)
        {

            try
            {
                using (var newConnection = new SqlConnection(p.constring))
                using (var da = new SqlDataAdapter("exec "+id.Trim(), newConnection))
                {
                    da.SelectCommand.CommandTimeout = 0;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return DataTableToJsonWithJsonNet(dt);
                }
             
            }
            catch (Exception)
            {

                return "No data";
            }

         
        }

        public void Post([FromBody]string value)
        {
        }

        public string DataTableToJsonWithJsonNet(DataTable table)
        {
            string jsonString = string.Empty;
            jsonString = JsonConvert.SerializeObject(table);
            return jsonString;
        }

    }
}
