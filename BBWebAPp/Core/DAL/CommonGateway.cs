using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace BBWebAPp.Core.DAL
{
    public class CommonGateway
    {
        protected string connectionString =
            WebConfigurationManager.ConnectionStrings["myConectionString"].ConnectionString;
        protected SqlConnection conn;
        protected SqlCommand command;
        public CommonGateway()
        {
            conn = new SqlConnection(connectionString);
        }
    }
}