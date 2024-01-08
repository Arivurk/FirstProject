using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Xml.Linq;
using FirstProject.Models;

namespace FirstProject.Repository
{
    public class UserRepository

    {
        public readonly UserRepository _context = null;

        public UserRepository(){

            }
        protected SqlConnection sqlConnect;

        protected void Connection()
        {
            string Connection = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString.ToString();
            sqlConnect = new SqlConnection(Connection);
        }
        public List<BranchModel> GetBranchDatas()
        {
            try
            {
                List<BranchModel> Branchdata = new List<BranchModel>();
                Connection();
                sqlConnect.Open();
                string query = "select * from tbl_Branch_table";
                SqlCommand cmd = new SqlCommand(query, sqlConnect);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    Branchdata.Add(new BranchModel
                    {
                        Branch_Id = Convert.ToInt32(dr["Branch_id"]),
                        Branchname = Convert.ToString(dr["Branchname"]),
                        Address = Convert.ToString(dr["Branch_Address"]),
                        
                    });
                }
                sqlConnect.Close();
                return Branchdata;
            }
            catch (Exception ex)
            {
                throw new Exception(" "+ ex.Message);
            }
        }
        public List<UserModel> GetSelecteddetails(int id)
        {
            try
            {
                List<UserModel> Listuser = new List<UserModel>();
                Connection();
                sqlConnect.Open();
                string query = "select * from userAccountDatas u inner join tbl_Branch_Table b on u.Branch_id=b.Branch_id where b.Branch_id=@branchname";

                SqlCommand cmd = new SqlCommand(query, sqlConnect);
                cmd.Parameters.AddWithValue("@branchname", id);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                foreach (DataRow dr in dataTable.Rows)
                {
                    Listuser.Add(new UserModel
                    {
                        Firstname = Convert.ToString(dr["Firstname"]),
                        Lastname = Convert.ToString(dr["Lastname"]),
                        Branchname = Convert.ToString(dr["Branchname"]),
                        Gender = Convert.ToString(dr["Gender"])
                    });
                }
                sqlConnect.Close();
                return Listuser;
            }
            catch (Exception ex)
            {
                throw new Exception(" " + ex.Message);
            }
        }
        public List<UserModel> GetSelecteddetail()
        {
            try
            {
                List<UserModel> Listuser = new List<UserModel>();
                Connection();
                sqlConnect.Open();
                string query = "select * from userAccountDatas";
                SqlCommand cmd = new SqlCommand(query, sqlConnect);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                foreach (DataRow dr in dataTable.Rows)
                {
                    Listuser.Add(new UserModel
                    {
                        Firstname = Convert.ToString(dr["Firstname"]),
                        Lastname = Convert.ToString(dr["Lastname"]),
                        Branch_Id = Convert.ToInt32(dr["Branch_id"]),
                        Gender = Convert.ToString(dr["Gender"]),
                        Mobile = Convert.ToString(dr["Mobile"]),
                        City = Convert.ToString(dr["City"]),
                        State = Convert.ToString(dr["State"]),
                        Email = Convert.ToString(dr["Email"]),
                        Username = Convert.ToString(dr["Username"])
                    });
                }
                sqlConnect.Close();
                return Listuser;
            }
            catch (Exception ex)
            {
                throw new Exception(" " + ex.Message);
            }
        }
        public List<UserModel> SelectGender(string id, string name)
        {
            try
            {
                List<UserModel> listdatas = new List<UserModel>();
                Connection();
                sqlConnect.Open();
                string quer = "select * from userAccountDatas u inner join tbl_Branch_Table b on u.Branch_id=b.Branch_id where b.Branchname=@Branchname AND u.Gender=@gender";
                SqlCommand cmd = new SqlCommand(quer, sqlConnect);
                cmd.Parameters.AddWithValue("@gender", id);
                cmd.Parameters.AddWithValue("@Branchname", name);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                foreach (DataRow dr in dataTable.Rows)
                    listdatas.Add(new UserModel
                    {
                        Firstname = Convert.ToString(dr["Firstname"]),
                        Lastname = Convert.ToString(dr["Lastname"]),
                        Branchname = Convert.ToString(dr["Branchname"]),
                        Gender = Convert.ToString(dr["Gender"])

                    });
                sqlConnect.Close();
                return listdatas;
            }
            catch (Exception ex)
            {
                throw new Exception(" " + ex.Message);
            }
        }
        public SqlDataAdapter getColumns(string id,string name)
        {
            try
            {
                Connection();
                sqlConnect.Open();
                SqlCommand cmd = new SqlCommand("SelectTablescolums", sqlConnect);
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                }
                cmd.Parameters.AddWithValue("@column", id);
                cmd.Parameters.AddWithValue ("@tablename", name);
                SqlDataAdapter reader = new SqlDataAdapter(cmd);
                return reader;
            }
            catch
            {
                throw new Exception();
            }
        }
        public SqlDataAdapter getColumnsNames(string id)
        {
            try
            {
                Connection();
                sqlConnect.Open();
                SqlCommand cmd = new SqlCommand("GetTableNames", sqlConnect);
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                }
                cmd.Parameters.AddWithValue("@tablename", id);
                SqlDataAdapter reader = new SqlDataAdapter(cmd);           
                return reader;
            }
            catch
            {
                throw new Exception();
            }
        }
        public List<listTables> getTableNames()
        {
            try
            {
                List<listTables> list=new List<listTables> ();
                Connection();
                sqlConnect.Open();
                string query = "SELECT name FROM sys.tables";
                SqlCommand cmd = new SqlCommand(query, sqlConnect);
                SqlDataAdapter reader = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                reader.Fill(dataTable);
                foreach(DataRow dataRow in dataTable.Rows)
                {
                    list.Add(new listTables
                    {
                        data = Convert.ToString(dataRow["name"]),
                    });
                }
                return list;
            }
            catch
            {
                throw new Exception();
            }
            
        }
        public List<listTables> GetColumnDetails(string id,string name)
        {
            try
            {
                List<listTables> list = new List<listTables>();
                Connection();
                sqlConnect.Open();
                SqlCommand cmd = new SqlCommand("selectcolumn", sqlConnect);
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                }
                cmd.Parameters.AddWithValue("@column", id);
                cmd.Parameters.AddWithValue("@tname", name);
                SqlDataAdapter reader = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                reader.Fill(dataTable);
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    list.Add(new listTables
                    {
                        data = Convert.ToString(dataRow[0]),
                    });
                }
                sqlConnect.Close();
                return list;
            }
            catch
            {
                throw new Exception();
            }
        }
        public List<listTables> GetSelecteddetailscolumn()
        {
            try
            {
                List<listTables> Listuser = new List<listTables>();
                Connection();
                sqlConnect.Open();
                string query = "select distinct Gender from userAccountDatas";
                SqlCommand cmd = new SqlCommand(query, sqlConnect);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                foreach (DataRow dr in dataTable.Rows)
                {
                    Listuser.Add(new listTables
                    {
                        //Firstname = Convert.ToString(dr["Firstname"]),
                        //Lastname = Convert.ToString(dr["Lastname"]),
                        //Branch_Id = Convert.ToInt32(dr["Branch_id"]),
                        data = Convert.ToString(dr["Gender"]),
                        //Mobile = Convert.ToString(dr["Mobile"]),
                        //City = Convert.ToString(dr["City"]),
                        //State = Convert.ToString(dr["State"]),
                        //Email = Convert.ToString(dr["Email"]),
                        //Username = Convert.ToString(dr["Username"])
                    });
                }
                sqlConnect.Close();
                return Listuser;
            }
            catch { throw new Exception(); }
            }

    }
}