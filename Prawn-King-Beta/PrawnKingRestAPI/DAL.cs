using System;
using System.Data.SqlClient;
using System.Configuration;

#nullable enable

namespace DAL
{
    public class DAL
    {
        static SqlConnection DBconn = new SqlConnection("Server=tcp:rohico.database.windows.net,1433;Initial Catalog=prawnking;Persist Security Info=False;User ID=rohi;Password=rt500rrt500r$$;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"); //Retrieve connection string from config file

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

        public static bool createAcc(string usr, string pwd, string fname, string lname, string phone)   //Function to try account creation with given credentials, returns bool
        {
            bool data; //Data to return

            try
            {
                if (testConnection()) //Test server connection
                {
                    string? ReturnID; //ID to return

                    SqlCommand checkLoginComm = new SqlCommand("createAccount", DBconn);   //Stored procedure to call
                    checkLoginComm.CommandType = System.Data.CommandType.StoredProcedure;   //Type of procedure
                    checkLoginComm.Parameters.Add(new SqlParameter("@userName", usr));    //Input parameter
                    checkLoginComm.Parameters.Add(new SqlParameter("@userPass", pwd));    //Input parameter
                    checkLoginComm.Parameters.Add(new SqlParameter("@fName", fname));    //Input parameter
                    checkLoginComm.Parameters.Add(new SqlParameter("@lName", lname)) ;    //Input parameter
                    checkLoginComm.Parameters.Add(new SqlParameter("@phoneNo", phone));    //Input parameter
                    SqlParameter ID = new SqlParameter("@userID", System.Data.SqlDbType.VarChar, 20);   //Output parameter
                    ID.Direction = System.Data.ParameterDirection.Output;  //Set the parameter as an output
                    checkLoginComm.Parameters.Add(ID); //Add parameter to request

                    DBconn.Open();  //Open connection
                    checkLoginComm.ExecuteNonQuery();   //Execute query

                    ReturnID = checkLoginComm.Parameters["@userID"].Value.ToString(); //Save response

                    if (ReturnID != "")   //If some ID is returned...
                    {
                        data = true;    //...return it as it is the corresponding User ID to the given credentials
                    }
                    else   //If no ID is returned...
                    {
                        data = false; //...return false as credentials are incorrect
                    }
                }
                else
                {
                    data = false; //...return false as connection failed
                }
            }
            catch (Exception ex)
             {
                Console.WriteLine(ex);  //Log exception
                data = false;  //...return false as some exception was raised
            }
            finally //After either...
            {
                DBconn.Close(); //...close connection
            }

            return data;   //Return
        }

        public static bool insertData(string id, string datapass)   //Function to try account creation with given credentials, returns bool
        {
           try
            {
                if (testConnection()) //Test server connection
                { 
                    SqlCommand checkLoginComm = new SqlCommand("insertData", DBconn);   //Stored procedure to call
                    checkLoginComm.CommandType = System.Data.CommandType.StoredProcedure;   //Type of procedure
                    checkLoginComm.Parameters.Add(new SqlParameter("@tankID", id));    //Input parameter
                    checkLoginComm.Parameters.Add(new SqlParameter("@data", datapass));    //Input parameter

                    DBconn.Open();  //Open connection
                    checkLoginComm.ExecuteNonQuery();   //Execute query
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);  //Log exception
            }
            finally //After either...
            {
                DBconn.Close(); //...close connection
            }
            return true;
        }

        public static string getData(string tankID)   //Function to get TankID returns string
        {
            string data; //Data to return

            try
            {
                if (testConnection()) //Test server connection
                {
                    string? ReturnID; //ID to return

                    SqlCommand checkLoginComm = new SqlCommand("getData", DBconn);   //Stored procedure to call
                    checkLoginComm.CommandType = System.Data.CommandType.StoredProcedure;   //Type of procedure
                    checkLoginComm.Parameters.Add(new SqlParameter("@tankID", tankID));    //Input parameter
                    SqlParameter ID = new SqlParameter("@data", System.Data.SqlDbType.VarChar, 500000000);   //Output parameter
                    ID.Direction = System.Data.ParameterDirection.Output;  //Set the parameter as an output
                    checkLoginComm.Parameters.Add(ID); //Add parameter to request

                    DBconn.Open();  //Open connection
                    checkLoginComm.ExecuteNonQuery();   //Execute query

                    ReturnID = checkLoginComm.Parameters["@data"].Value.ToString(); //Save response

                    if (ReturnID != "")   //If some ID is returned...
                    {
                        data = ReturnID;    //...return it as it is the corresponding User ID to the given credentials
                    }
                    else   //If no ID is returned...
                    {
                        data = "None"; //...return false as credentials are incorrect
                    }
                }
                else
                {
                    data = "None"; //...return false as connection failed
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);  //Log exception
                data = "None";  //...return false as some exception was raised
            }
            finally //After either...
            {
                DBconn.Close(); //...close connection
            }

            return data;   //Return
        }

        public static string getTank(string id)   //Function to get TankID returns string
        {
            string tankID; //Data to return

            try
            {
                if (testConnection()) //Test server connection
                {
                    string? ReturnID; //ID to return

                    SqlCommand checkLoginComm = new SqlCommand("getTank", DBconn);   //Stored procedure to call
                    checkLoginComm.CommandType = System.Data.CommandType.StoredProcedure;   //Type of procedure
                    checkLoginComm.Parameters.Add(new SqlParameter("@userID", id));    //Input parameter
                    SqlParameter ID = new SqlParameter("@tankID", System.Data.SqlDbType.VarChar, 20);   //Output parameter
                    ID.Direction = System.Data.ParameterDirection.Output;  //Set the parameter as an output
                    checkLoginComm.Parameters.Add(ID); //Add parameter to request

                    DBconn.Open();  //Open connection
                    checkLoginComm.ExecuteNonQuery();   //Execute query

                    ReturnID = checkLoginComm.Parameters["@tankID"].Value.ToString(); //Save response

                    if (ReturnID != "")   //If some ID is returned...
                    {
                        tankID = ReturnID;    //...return it as it is the corresponding User ID to the given credentials
                    }
                    else   //If no ID is returned...
                    {
                        tankID = "None"; //...return false as credentials are incorrect
                    }
                }
                else
                {
                    tankID = "None"; //...return false as connection failed
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);  //Log exception
                tankID = "None";  //...return false as some exception was raised
            }
            finally //After either...
            {
                DBconn.Close(); //...close connection
            }

            return tankID;   //Return
        }

        public static bool tryLogin(string usr, string pwd)   //Function to try login with given credentials, returns bool
        {
            bool finalDecision; //Data to return

            try
            {
                if (testConnection()) //Test server connection
                {
                    string? ReturnID; //ID to return

                    SqlCommand checkLoginComm = new SqlCommand("checkLogin", DBconn);   //Stored procedure to call
                    checkLoginComm.CommandType = System.Data.CommandType.StoredProcedure;   //Type of procedure
                    checkLoginComm.Parameters.Add(new SqlParameter("@userName", usr));    //Input parameter
                    checkLoginComm.Parameters.Add(new SqlParameter("@userPass", pwd));   //Input parameter
                    SqlParameter ID = new SqlParameter("@userID", System.Data.SqlDbType.VarChar, 20);   //Output parameter
                    ID.Direction = System.Data.ParameterDirection.Output;  //Set the parameter as an output
                    checkLoginComm.Parameters.Add(ID); //Add parameter to request

                    DBconn.Open();  //Open connection
                    checkLoginComm.ExecuteNonQuery();   //Execute query

                    ReturnID = checkLoginComm.Parameters["@userID"].Value.ToString(); //Save response

                    if (ReturnID != "")   //If some ID is returned...
                    {
                        finalDecision = true;    //...return it as it is the corresponding User ID to the given credentials
                    }
                    else   //If no ID is returned...
                    {
                        finalDecision = false ; //...return false as credentials are incorrect
                    }
                }
                else
                {
                    finalDecision = false; //...return false as connection failed
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);  //Log exception
                finalDecision = false;  //...return false as some exception was raised
            }
            finally //After either...
            {
                DBconn.Close(); //...close connection
            }

            return finalDecision;   //Return
        }

        public static bool checkAvailability(string usr)    //Function to check availability of a username (for UA creation) returns bool
        {
            bool finalDecision;
            try
            {
                if (testConnection()) //Test server connection
                {
                    string? RequestStatus;  //User ID gets saved here if user exists

                    SqlCommand checkLoginComm = new SqlCommand("checkAvailability", DBconn);   //Stored procedure to call
                    checkLoginComm.CommandType = System.Data.CommandType.StoredProcedure;   //Type of procedure
                    checkLoginComm.Parameters.Add(new SqlParameter("@userName", usr));    //Parameter
                    SqlParameter ReturnValue = new SqlParameter("@UserID", System.Data.SqlDbType.VarChar, 20);   //Output parameter
                    ReturnValue.Direction = System.Data.ParameterDirection.Output;  //Set the parameter as an output
                    checkLoginComm.Parameters.Add(ReturnValue); //Add parameter to request

                    DBconn.Open();  //Open connection
                    checkLoginComm.ExecuteNonQuery();   //Execute query
                    RequestStatus = checkLoginComm.Parameters["@UserID"].Value.ToString(); //Save response

                    if (RequestStatus == "")  //This means no user ID was returned and so a user does not exist with such username
                    {
                        finalDecision = true;    //Return true - the username is available.
                    }
                    else
                    {
                        finalDecision = false;    //Return false - the username is unavailable
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
