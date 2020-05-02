using System;
using System.Data.SqlClient;
using System.Configuration;

namespace DAL
{
    public class DAL
    {
        static SqlConnection DBconn = new SqlConnection(ConfigurationManager.ConnectionStrings["connString"].ConnectionString); //Retrieve connection string from config file

        public static bool testConnection() //Function to test for successfull DB connection, returns true for success, false for fail
        {
            bool finalDecision; //Data to return

            try
            {
                DBconn.Open();  //Open connection
                finalDecision = true;    //return true
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);  //Log exception
                finalDecision = false;   //Return false - failed connection
            }
            finally //After either...
            {
                DBconn.Close(); //...close connection
            }

            return finalDecision;   //Return
        }

        public static string tryLogin(string usr, string pwd)   //Function to try login with given credentials, returns assigned user ID or "Error"
        {
            string finalDecision; //Data to return

            try
            {
                if (testConn()) //Test server connection
                {
                    string? ReturnID; //ID to return

                    SqlCommand checkLoginComm = new SqlCommand("checkLogin", DBconn);   //Stored procedure to call
                    checkLoginComm.CommandType = System.Data.CommandType.StoredProcedure;   //Type of procedure
                    checkLoginComm.Parameters.Add(new SqlParameter("@USR", usr));    //Input parameter
                    checkLoginComm.Parameters.Add(new SqlParameter("@PWD", pwd));   //Input parameter
                    SqlParameter ID = new SqlParameter("@ID", System.Data.SqlDbType.VarChar, 6);   //Output parameter
                    ID.Direction = System.Data.ParameterDirection.Output;  //Set the parameter as an output
                    checkLoginComm.Parameters.Add(ID); //Add parameter to request

                    DBconn.Open();  //Open connection
                    checkLoginComm.ExecuteNonQuery();   //Execute query

                    ReturnID = (string)checkLoginComm.Parameters["@ID"].Value; //Save response

                    if (ReturnID != null)   //If some ID is returned...
                    {
                        finalDecision = ReturnID;    //...return it as it is the corresponding User ID to the given credentials
                    }
                    else   //If no ID is returned...
                    {
                        finalDecision = "Error"; //...return "Error" as credentials are incorrect
                    }
                }
                else
                {
                    finalDecision = "Error"; //...return "Error" as connection failed
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);  //Log exception
                finalDecision = "Error";  //...return "Error" as some exception was raised

            }
            finally //After either...
            {
                DBconn.Close(); //...close connection
            }

            return finalDecision;   //Return
        }
        public static bool checkAvailability(string usr)    //Function to check availability of a username (for UA creation)
        {
            bool finalDecision;
            try
            {
                if (testConn()) //Test server connection
                {
                    string? RequestStatus;  //User ID gets saved here if user exists

                    SqlCommand checkLoginComm = new SqlCommand("checkAvailability", DBconn);   //Stored procedure to call
                    checkLoginComm.CommandType = System.Data.CommandType.StoredProcedure;   //Type of procedure
                    checkLoginComm.Parameters.Add(new SqlParameter("@USR", usr));    //Parameter
                    SqlParameter ReturnValue = new SqlParameter("@RequestStatus", System.Data.SqlDbType.VarChar, 6);   //Output parameter
                    ReturnValue.Direction = System.Data.ParameterDirection.Output;  //Set the parameter as an output
                    checkLoginComm.Parameters.Add(ReturnValue); //Add parameter to request

                    DBconn.Open();  //Open connection
                    checkLoginComm.ExecuteNonQuery();   //Execute query
                    RequestStatus = (string)checkLoginComm.Parameters["@RequestStatus"].Value; //Save response

                    if (RequestStatus != null)  //This means a user ID was returned and so a user exists with such username
                    {
                        finalDecision = false;    //Return false - the username is unavailable
                    }
                    else
                    {
                        finalDecision = true;    //Return true - the username is available
                    }
                }
                else
                {
                    finalDecision = false;   //Return false - some error during connection
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);  //Log exception
                finalDecision = false;  //...return false - as some exception was raised

            }
            finally //After either...
            {
                DBconn.Close(); //...close connection
            }
            return finalDecision; //Return
        }

    }
}
