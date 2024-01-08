using FirstProject.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FirstProject.Repository
{
    public class UserDetails
    {
        protected SqlConnection sqlConnect;

        protected void Connection()
        {
            string Connection = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString.ToString();
            sqlConnect = new SqlConnection(Connection);
        }
        public List<Login> UserLoginDetails()
        {
            try
            {
                List<Login> list = new List<Login>();
                Connection();
                sqlConnect.Open();              
                SqlCommand cmd = new SqlCommand("UserLogin", sqlConnect);
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                }
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                foreach (DataRow row in dataTable.Rows)
                {
                    list.Add(new Login
                    {
                        Username = Convert.ToString(row["Username"]),
                        Password = Convert.ToString(row["Password"])
                    });
                }
                sqlConnect.Close();
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
      
    }
}