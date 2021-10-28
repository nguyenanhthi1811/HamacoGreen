using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HamacoAPI.Controllers
{
    public class ExecuteNonQueryController : ApiController
    {
        // GET api/values
      
        // POST api/values
        public void Post([FromBody]string query)
        {
            p._ExecuteSQL(query);
        }
        
    }
}
