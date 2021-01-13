using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace CoronaApp
{
    class OldDataRepository : Repository
    {
        protected SqlConnection connection = null;
        public void Search()
        {
            try
            {
                SqlCommand command = new SqlCommand("SELECT * FROM dbo.Cumulative_incidents", connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error in OldDataRepository " + ex.Message);
            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open) connection.Close();
            }
        }
    }
}
