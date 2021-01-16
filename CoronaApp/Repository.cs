using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;

namespace CoronaApp
{
    public class Repository
    {
        public Repository()
        {
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringDelta"].ConnectionString);
            }
            catch (Exception ex)
            {
                throw new Exception("Error in Repository: " + ex.Message);
            }
        }
    }
}
