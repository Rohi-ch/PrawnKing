using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace MySQLDAL
{
    class SQLDAL
    {
        static string username;
        static string password;
        static int userID;
        static MySqlConnection conn;
        static readonly string myConnectionString = "server=vlvlnl1grfzh34vj.chr7pe7iynqr.eu-west-1.rds.amazonaws.com;database=pdl23bwz2d3ujvr6;uid=y30bd17nh2p6vncj;pwd=kjiqz5ht51pm4i6h;";

        public static bool initInsecureConn()
        {
            conn = new MySqlConnection(myConnectionString);

            try
            {
                conn.Open();
                return true;
            }
            catch (Exception ex)
            {
                conn.Close();
                Console.Write(ex);
                return false;
            }

        }

        public static int initConn(string usr, string pwd)
        {
            conn = new MySqlConnection(myConnectionString);

            try
            {
                conn.Open();
                username = usr;
                password = pwd;
                userID = getIDSP();
                return userID;
            }
            catch (Exception ex)
            {
                conn.Close();
                Console.Write(ex);
                return 0;
            }

        }

        public static bool closeConn()
        {
            try
            {
                conn.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return false;
            }

        }

        public static int getIDSP()
        {
            int rtnVal = 0;

            MySqlCommand getID = new MySqlCommand();
            getID.Connection = conn;
            getID.CommandType = CommandType.StoredProcedure;
            getID.CommandText = "getid";

            MySqlParameter UserPara = new MySqlParameter("Usr", MySqlDbType.VarChar, 50);
            UserPara.Value = username;
            getID.Parameters.Add(UserPara);

            MySqlParameter PwdPara = new MySqlParameter("Pwd", MySqlDbType.VarChar, 50);
            PwdPara.Value = password;
            getID.Parameters.Add(PwdPara);

            MySqlParameter RtnPara = new MySqlParameter("Rtn", MySqlDbType.Int64);
            RtnPara.Value = 0;
            RtnPara.Direction = ParameterDirection.Output;
            getID.Parameters.Add(RtnPara);

            getID.ExecuteNonQuery();

            getID.Dispose();

            if (getID.Parameters["Rtn"].Value != null)
            {
                rtnVal = Convert.ToInt32(getID.Parameters["Rtn"].Value);
            }
            else
            {
                rtnVal = 0;
            }
            return rtnVal;
        }

        public static bool usrExistSP(string queryUser)
        {
            bool rtnVal = false;

            MySqlCommand usrExist = new MySqlCommand();
            usrExist.Connection = conn;
            usrExist.CommandType = CommandType.StoredProcedure;
            usrExist.CommandText = "userexists";

            MySqlParameter UserPara = new MySqlParameter("Usr", MySqlDbType.VarChar, 50);
            UserPara.Value = queryUser;
            usrExist.Parameters.Add(UserPara);

            MySqlParameter RtnPara = new MySqlParameter("Rtn", MySqlDbType.Bit);
            RtnPara.Value = false;
            RtnPara.Direction = ParameterDirection.Output;
            usrExist.Parameters.Add(RtnPara);

            usrExist.ExecuteNonQuery();

            if(usrExist.Parameters["Rtn"].Value.ToString() == "1")
            {
                rtnVal = true;
            }

            usrExist.Dispose();

            return rtnVal;
        }

        public static bool usrInfoSP(string fn, string ln, string pnum)
        {
            bool rtnVal = false;

            MySqlCommand usrInfo = new MySqlCommand();
            usrInfo.Connection = conn;
            usrInfo.CommandType = CommandType.StoredProcedure;
            usrInfo.CommandText = "uinfo";

            MySqlParameter UserPara = new MySqlParameter("Usr", MySqlDbType.VarChar, 50);
            UserPara.Value = username;
            usrInfo.Parameters.Add(UserPara);

            MySqlParameter PwdPara = new MySqlParameter("Pwd", MySqlDbType.VarChar, 50);
            PwdPara.Value = password;
            usrInfo.Parameters.Add(PwdPara);

            MySqlParameter fname = new MySqlParameter("fname", MySqlDbType.VarChar, 50);
            fname.Value = fn;
            usrInfo.Parameters.Add(fname);

            MySqlParameter lname = new MySqlParameter("lname", MySqlDbType.VarChar, 50);
            lname.Value = ln;
            usrInfo.Parameters.Add(lname);

            MySqlParameter pnumber = new MySqlParameter("pnumber", MySqlDbType.VarChar, 50);
            pnumber.Value = pnum;
            usrInfo.Parameters.Add(pnumber);

            MySqlParameter RtnPara = new MySqlParameter("Rtn", MySqlDbType.Bit);
            RtnPara.Value = false;
            RtnPara.Direction = ParameterDirection.Output;
            usrInfo.Parameters.Add(RtnPara);

            usrInfo.ExecuteNonQuery();

            if (usrInfo.Parameters["Rtn"].Value.ToString() == "1")
            {
                rtnVal = true;
            }

            usrInfo.Dispose();

            return rtnVal;
        }

        public static bool addTankSP()
        {
            bool rtnVal = false;

            MySqlCommand addTank = new MySqlCommand();
            addTank.Connection = conn;
            addTank.CommandType = CommandType.StoredProcedure;
            addTank.CommandText = "addtank";

            MySqlParameter UserIdPara = new MySqlParameter("UsrID", MySqlDbType.Int32);
            UserIdPara.Value = userID;
            addTank.Parameters.Add(UserIdPara);

            MySqlParameter RtnPara = new MySqlParameter("Rtn", MySqlDbType.Bit);
            RtnPara.Value = false;
            RtnPara.Direction = ParameterDirection.Output;
            addTank.Parameters.Add(RtnPara);

            addTank.ExecuteNonQuery();

            if (addTank.Parameters["Rtn"].Value.ToString() == "1")
            {
                rtnVal = true;
            }

            addTank.Dispose();

            return rtnVal;
        }

        public static bool addTankRefSP(int user2AddID, int tankID)
        {
            bool rtnVal = false;

            MySqlCommand addTid = new MySqlCommand();
            addTid.Connection = conn;
            addTid.CommandType = CommandType.StoredProcedure;
            addTid.CommandText = "addtref";

            MySqlParameter UserIDPara = new MySqlParameter("UsrID", MySqlDbType.Int32);
            UserIDPara.Value = userID;
            addTid.Parameters.Add(UserIDPara);

            MySqlParameter user2AddPra = new MySqlParameter("UsrAddID", MySqlDbType.Int32);
            user2AddPra.Value = user2AddID;
            addTid.Parameters.Add(user2AddPra);

            MySqlParameter TankIDPara = new MySqlParameter("tnkID", MySqlDbType.Int32);
            TankIDPara.Value = tankID;
            addTid.Parameters.Add(TankIDPara);

            MySqlParameter RtnPara = new MySqlParameter("Rtn", MySqlDbType.Bit);
            RtnPara.Value = false;
            RtnPara.Direction = ParameterDirection.Output;
            addTid.Parameters.Add(RtnPara);

            addTid.ExecuteNonQuery();

            if (addTid.Parameters["Rtn"].Value.ToString() == "1")
            {
                rtnVal = true;
            }

            addTid.Dispose();

            return rtnVal;
        }

        public static bool newUserSP(string User, string Passwd)
        {
            bool rtnVal = false;

            MySqlCommand AddUser = new MySqlCommand();
            AddUser.Connection = conn;
            AddUser.CommandType = CommandType.StoredProcedure;
            AddUser.CommandText = "adduser";

            MySqlParameter UserPara = new MySqlParameter("Usr", MySqlDbType.VarChar, 50);
            UserPara.Value = User;
            AddUser.Parameters.Add(UserPara);

            MySqlParameter PasswdPara = new MySqlParameter("Pwd", MySqlDbType.VarChar, 50);
            PasswdPara.Value = Passwd;
            AddUser.Parameters.Add(PasswdPara);

            MySqlParameter RtnPara = new MySqlParameter("Rtn", MySqlDbType.Bit);
            RtnPara.Value = false;
            RtnPara.Direction = ParameterDirection.Output;
            AddUser.Parameters.Add(RtnPara);

            AddUser.ExecuteNonQuery();

            if (AddUser.Parameters["Rtn"].Value.ToString() == "1")
            {
                rtnVal = true;
            }

            AddUser.Dispose();

            return rtnVal;
        }

        public static bool mkAdminSP(int userID)
        {
            bool rtnVal = false;

            MySqlCommand mkAdmin = new MySqlCommand();
            mkAdmin.Connection = conn;
            mkAdmin.CommandType = CommandType.StoredProcedure;
            mkAdmin.CommandText = "mkadmin";

            MySqlParameter UserPara = new MySqlParameter("Usr", MySqlDbType.VarChar, 50);
            UserPara.Value = username;
            mkAdmin.Parameters.Add(UserPara);

            MySqlParameter PwdPara = new MySqlParameter("Pwd", MySqlDbType.VarChar, 50);
            PwdPara.Value = password;
            mkAdmin.Parameters.Add(PwdPara);

            MySqlParameter UserIDPara = new MySqlParameter("UsrID", MySqlDbType.VarChar, 50);
            UserIDPara.Value = userID;
            mkAdmin.Parameters.Add(UserIDPara);

            MySqlParameter RtnPara = new MySqlParameter("Rtn", MySqlDbType.Int64);
            RtnPara.Value = 0;
            RtnPara.Direction = ParameterDirection.Output;
            mkAdmin.Parameters.Add(RtnPara);

            mkAdmin.ExecuteNonQuery();

            if (mkAdmin.Parameters["Rtn"].Value.ToString() == "1")
            {
                rtnVal = true;
            }

            mkAdmin.Dispose();

            return rtnVal;
        }


        public static string tAccessSP()
        {
            string rtnVal = "";

            MySqlCommand tAccess = new MySqlCommand();
            tAccess.Connection = conn;
            tAccess.CommandType = CommandType.StoredProcedure;
            tAccess.CommandText = "taccess";

            MySqlParameter UserPara = new MySqlParameter("UsrID", MySqlDbType.Int32);
            UserPara.Value = Convert.ToInt32(userID);
            tAccess.Parameters.Add(UserPara);

            MySqlParameter RtnPara = new MySqlParameter("Rtn", MySqlDbType.VarChar,255);
            RtnPara.Value = "";
            RtnPara.Direction = ParameterDirection.Output;
            tAccess.Parameters.Add(RtnPara);

            tAccess.ExecuteNonQuery();

            if (tAccess.Parameters["Rtn"].Value.ToString() != null)
            {
                rtnVal = tAccess.Parameters["Rtn"].Value.ToString();
            }

            tAccess.Dispose();

            return rtnVal;
        }

        ///////////////////
        ///
        public static string getPInfoSP()
        {
            string rtnVal = "";

            MySqlCommand getPInfo = new MySqlCommand();
            getPInfo.Connection = conn;
            getPInfo.CommandType = CommandType.StoredProcedure;
            getPInfo.CommandText = "getPInfo";

            MySqlParameter UserPara = new MySqlParameter("Usr", MySqlDbType.VarChar, 255);
            UserPara.Value = username;
            getPInfo.Parameters.Add(UserPara);

            MySqlParameter PwdPara = new MySqlParameter("Pwd", MySqlDbType.VarChar, 255);
            PwdPara.Value = password;
            getPInfo.Parameters.Add(PwdPara);

            MySqlParameter RtnPara = new MySqlParameter("Rtn", MySqlDbType.VarChar, 255);
            RtnPara.Value = "";
            RtnPara.Direction = ParameterDirection.Output;
            getPInfo.Parameters.Add(RtnPara);

            getPInfo.ExecuteNonQuery();

            if (getPInfo.Parameters["Rtn"].Value.ToString() != null)
            {
                rtnVal = getPInfo.Parameters["Rtn"].Value.ToString();
            }

            getPInfo.Dispose();

            return rtnVal;

        }

        public static string getTDataSP(int tid)
        {
            string rtnVal = "";

            MySqlCommand getTData = new MySqlCommand();
            getTData.Connection = conn;
            getTData.CommandType = CommandType.StoredProcedure;
            getTData.CommandText = "getTData";

            MySqlParameter TankID = new MySqlParameter("TID", MySqlDbType.VarChar, 255);
            TankID.Value = tid;
            getTData.Parameters.Add(TankID);

            MySqlParameter RtnPara = new MySqlParameter("Rtn", MySqlDbType.VarChar, 255);
            RtnPara.Value = "";
            RtnPara.Direction = ParameterDirection.Output;
            getTData.Parameters.Add(RtnPara);

            getTData.ExecuteNonQuery();

            if (getTData.Parameters["Rtn"].Value.ToString() != null)
            {
                rtnVal = getTData.Parameters["Rtn"].Value.ToString();
            }

            getTData.Dispose();

            return rtnVal;

        }

        public static bool updTDataSP(int tid, string data, string comments)
        {
            bool rtnVal = false;

            MySqlCommand updTData = new MySqlCommand();
            updTData.Connection = conn;
            updTData.CommandType = CommandType.StoredProcedure;
            updTData.CommandText = "updTData";

            MySqlParameter UserID = new MySqlParameter("UID", MySqlDbType.VarChar, 255);
            UserID.Value = userID;
            updTData.Parameters.Add(UserID);

            MySqlParameter TankID = new MySqlParameter("TID", MySqlDbType.VarChar, 255);
            TankID.Value = tid;
            updTData.Parameters.Add(TankID);

            MySqlParameter Data = new MySqlParameter("UData", MySqlDbType.VarChar, 255);
            Data.Value = data;
            updTData.Parameters.Add(Data);

            MySqlParameter Comments = new MySqlParameter("Comment", MySqlDbType.VarChar, 255);
            Comments.Value = comments;
            updTData.Parameters.Add(Comments);

            MySqlParameter RtnPara = new MySqlParameter("Rtn", MySqlDbType.VarChar, 255);
            RtnPara.Value = "";
            RtnPara.Direction = ParameterDirection.Output;
            updTData.Parameters.Add(RtnPara);

            updTData.ExecuteNonQuery();

            if (updTData.Parameters["Rtn"].Value.ToString() == "1")
            {
                rtnVal = true;
            }

            updTData.Dispose();

            return rtnVal;

        }

    }
}
