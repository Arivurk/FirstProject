using Book.bl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.SqlServer.Server;
using System.Data.SqlClient;
using System.Data;

namespace Book.BLL
{
    public class ConClass
    {
        public Branchs interdat;
        public ConClass()
        {
            interdat = new Branchs();
        }
        protected SqlConnection sqlConnect;

        public object ConfigurationManager { get; private set; }

        //protected void Connection()
        //{
        //    string Connection = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString.ToString();
        //    sqlConnect = new SqlConnection(Connection);
        //}
        //public List<Branchs> branchsas()
        //{
        //    try {
        //        List<Branchs> list=new List<Branchs>();
           
        //        Connection();
        //        sqlConnect.Open();
        //        string query = "select * from tbl_Branch_table";
        //        SqlCommand cmd = new SqlCommand(query, sqlConnect);
        //        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        //        DataTable dt = new DataTable();
        //        adapter.Fill(dt);
        //        foreach (DataRow dr in dt.Rows)
        //        {
        //        list.Add(new Branchs
        //            {
        //                Branch_Id = Convert.ToInt32(dr["Branch_id"]),
        //                Branchname = Convert.ToString(dr["Branchname"]),
        //                Address = Convert.ToString(dr["Branch_Address"]),

        //            });
        //        }
        //        sqlConnect.Close();
        //        return list;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(" " + ex.Message);
        //    }
        //}
    }
}
