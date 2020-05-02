using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Data.Sql;
using System.Data.SqlTypes;
using System.Configuration;
using System.Threading.Tasks;

namespace DALTester
{
    class DAL
    {

        SqlConnection DBconn = new SqlConnection(@"Server=localhost\SQLEXPRESS;Database=pkdb;Trusted_Connection=True;");
        public bool TestConnection()
        {
            try
            {
                DBconn.Open();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                DBconn.Close();
            }
        }
        public string GetID(string username, string passhash)
        {
            string id = "";
            try
            {
                DBconn.Open();
                SqlCommand GetIDComm = new SqlCommand();
                GetIDComm.Connection = DBconn;
                GetIDComm.CommandText = "[dbo].[GETID]";
                GetIDComm.CommandType = CommandType.StoredProcedure;   //Type of procedure
                GetIDComm.Parameters.Add(new SqlParameter("@Usr", SqlDbType.VarChar, 12));    //Input parameter
                GetIDComm.Parameters["@Usr"].Value = username;
                GetIDComm.Parameters.Add(new SqlParameter("@Hash", SqlDbType.VarChar, 120));   //Input parameter
                GetIDComm.Parameters["@Hash"].Value = passhash;

                SqlParameter rtnPara = new SqlParameter();
                rtnPara.ParameterName = "@Rtn";   
                rtnPara.SqlDbType = SqlDbType.Int;
                rtnPara.Direction = System.Data.ParameterDirection.Output;

                GetIDComm.Parameters.Add(rtnPara);   //Output parameter

                GetIDComm.ExecuteNonQuery();
                id = GetIDComm.Parameters["@Rtn"].Value.ToString();
                return id;
            }
            catch(Exception e)
            {
                Console.WriteLine("An error occured" + e.ToString());
                return id;
            }
            finally
            {
                DBconn.Close();
            }
        }

        public int UserExists(string username)
        {
            int id = 0;
            try
            {
                DBconn.Open();
                SqlCommand GetIDComm = new SqlCommand();
                GetIDComm.Connection = DBconn;
                GetIDComm.CommandText = "[dbo].[USEREXISTS]";
                GetIDComm.CommandType = CommandType.StoredProcedure;   //Type of procedure
                GetIDComm.Parameters.Add(new SqlParameter("@Usr", SqlDbType.VarChar, 12));    //Input parameter
                GetIDComm.Parameters["@Usr"].Value = username;

                SqlParameter rtnPara = new SqlParameter();
                rtnPara.ParameterName = "@Rtn";
                rtnPara.SqlDbType = SqlDbType.Bit;
                rtnPara.Direction = ParameterDirection.Output;

                GetIDComm.Parameters.Add(rtnPara);   //Output parameter

                GetIDComm.ExecuteNonQuery();
                id = Convert.ToInt32(GetIDComm.Parameters["@Rtn"].Value);
                return id;
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occured" + e.ToString());
                return id;
            }
            finally
            {
                DBconn.Close();
            }
        }

        public int AddUser(string username, string password)
        {
            int id = 0;
            try
            {
                DBconn.Open();
                SqlCommand GetIDComm = new SqlCommand();
                GetIDComm.Connection = DBconn;
                GetIDComm.CommandText = "[dbo].[ADDUSER]";
                GetIDComm.CommandType = CommandType.StoredProcedure;   //Type of procedure
                GetIDComm.Parameters.Add(new SqlParameter("@Usr", SqlDbType.VarChar, 12));    //Input parameter
                GetIDComm.Parameters["@Usr"].Value = username;
                GetIDComm.Parameters.Add(new SqlParameter("@Pwd", SqlDbType.VarChar, 120));    //Input parameter
                GetIDComm.Parameters["@Pwd"].Value = password;

                SqlParameter rtnPara = new SqlParameter();
                rtnPara.ParameterName = "@Rtn";
                rtnPara.SqlDbType = SqlDbType.Bit;
                rtnPara.Direction = ParameterDirection.Output;

                GetIDComm.Parameters.Add(rtnPara);   //Output parameter

                GetIDComm.ExecuteNonQuery();
                id = Convert.ToInt32(GetIDComm.Parameters["@Rtn"].Value);
                return id;
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occured" + e.ToString());
                return id;
            }
            finally
            {
                DBconn.Close();
            }
        }

        public int mkAdmin(string username, string password, int usrId)
        {
            int id = 0;
            try
            {
                DBconn.Open();
                SqlCommand GetIDComm = new SqlCommand();
                GetIDComm.Connection = DBconn;
                GetIDComm.CommandText = "[dbo].[MKADMIN]";
                GetIDComm.CommandType = CommandType.StoredProcedure;   //Type of procedure
                GetIDComm.Parameters.Add(new SqlParameter("@Usr", SqlDbType.VarChar, 12));    //Input parameter
                GetIDComm.Parameters["@Usr"].Value = username;
                GetIDComm.Parameters.Add(new SqlParameter("@Pwd", SqlDbType.VarChar, 120));    //Input parameter
                GetIDComm.Parameters["@Pwd"].Value = password;
                GetIDComm.Parameters.Add(new SqlParameter("@UsrID", SqlDbType.Int));    //Input parameter
                GetIDComm.Parameters["@UsrID"].Value = usrId;

                SqlParameter rtnPara = new SqlParameter();
                rtnPara.ParameterName = "@Rtn";
                rtnPara.SqlDbType = SqlDbType.Bit;
                rtnPara.Direction = ParameterDirection.Output;

                GetIDComm.Parameters.Add(rtnPara);   //Output parameter

                GetIDComm.ExecuteNonQuery();
                id = Convert.ToInt32(GetIDComm.Parameters["@Rtn"].Value);
                return id;
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occured" + e.ToString());
                return id;
            }
            finally
            {
                DBconn.Close();
            }
        }
    }
}
