using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static MySQLDAL.SQLDAL;

namespace MySQLDAL
{

    class Program
    {
        static void Main()
        {
            Console.WriteLine("Opening Connection to SQL Server, Enter User Credentials. Enter 'x' to create a new user.");
            Console.Write("Username: ");
            string password = "";
            string username = Console.ReadLine();

            if (username == "x")
            {
                Console.Write("Username: ");
                string user = Console.ReadLine();
                Console.Write("Password: ");
                string pwd = Console.ReadLine();
                initInsecureConn();
                if (newUserSP(user, pwd))
                {
                    Console.WriteLine("User Created");
                    username = user;
                    password = pwd;
                }
                else
                {
                    Console.WriteLine("Fail");

                }
                closeConn();
            }
            else
            {
                Console.Write("Password: ");
                password = Console.ReadLine();
            }

            int userID = initConn(username,password);
            //Console.Clear();

            if (userID != 0)
            {
                Console.WriteLine("Connection Opened, User Credetials Correct");
                Console.WriteLine("User ID is " + userID);
            }
            else
            {
                Console.WriteLine("USER DOES NOT EXIST");
                //Environment.Exit(0);
            }    
            while (true)
            {
                Console.WriteLine("Enter a choice");
                Console.WriteLine("1 - Exit");
                Console.WriteLine("2 - UserExists?");
                Console.WriteLine("3 - Add User Info?");
                Console.WriteLine("4 - Create Tank");
                Console.WriteLine("5 - Add Tank Reference");
                Console.WriteLine("6 - Make Another User an Admin");
                Console.WriteLine("7 - Check what tanks you have access to");
                Console.WriteLine("8 - Check your info");
                Console.WriteLine("9 - Check data in a tank");
                string userInput = Console.ReadLine();
                if(userInput == "1")
                {
                    break;
                }
                else if(userInput == "2")
                {
                    Console.Write("Enter username to check: ");
                    if(usrExistSP(Console.ReadLine()))
                    {
                        Console.WriteLine("User Exists");
                    }
                    else
                    {
                        Console.WriteLine("No User Found");

                    }
                }
                else if(userInput == "3")
                {
                    Console.Write("Enter First Name:");
                    string fname = Console.ReadLine();
                    Console.Write("Enter Last Name:");
                    string lname = Console.ReadLine();
                    Console.Write("Enter Phone Number:");
                    string pnumber = Console.ReadLine();
                    if (usrInfoSP(fname,lname,pnumber))
                    {
                        Console.WriteLine("User Details Added Successfully");
                    }
                    else
                    {
                        Console.WriteLine("Error");

                    }
                }
                else if(userInput == "4")
                {
                    if (addTankSP())
                    {
                        Console.WriteLine("New Tank Created and User Relation added");
                    }
                    else
                    {
                        Console.WriteLine("Error");

                    }
                }
                else if (userInput == "5")
                {
                    Console.Write("Enter User Id of User to Add: ");
                    int u2add = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter Tank Id to give access to: ");
                    int tid = Convert.ToInt32(Console.ReadLine());
                    if (addTankRefSP(u2add,tid))
                    {
                        Console.WriteLine("New User Relation added");
                    }
                    else
                    {
                        Console.WriteLine("Error");

                    }
                }
                else if (userInput == "6")
                {
                    Console.Write("Enter user id of user to promote to admin: ");
                    if (mkAdminSP(Convert.ToInt32(Console.ReadLine())))
                    {
                        Console.WriteLine("User Promoted");
                    }
                    else
                    {
                        Console.WriteLine("Failed");

                    }
                }
                else if (userInput == "7")
                {
                    string access = tAccessSP();
                    if (access != "")
                    {
                        Console.WriteLine("You have access to tanks: " + access);
                    }
                    else
                    {
                        Console.WriteLine("You have access to no tanks, or fail.");

                    }
                }
                else if (userInput == "8")
                {
                    string result = getPInfoSP();
                    if(result == "")
                    {
                        Console.WriteLine("Error");
                    }
                    else
                    {
                        Console.WriteLine(result);
                    }
                }
                else if(userInput == "9")
                {
                    Console.WriteLine("Enter Tank ID to retrieve data");
                    int tid = Convert.ToInt32(Console.ReadLine());
                    string result = getTDataSP(tid);
                    if (result == "")
                    {
                        Console.WriteLine("Error");
                    }
                    else
                    {
                        Console.WriteLine(result);
                    }
                }
                else if(userInput == "10")
                {
                    Console.WriteLine("Enter Tank ID to update data");
                    int tid = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter Data");
                    string data = Console.ReadLine();
                    Console.WriteLine("Enter Comment");
                    string comments = Console.ReadLine();
                    if(updTDataSP(tid,data,comments))
                    {
                        Console.WriteLine("Success");
                    }
                    else
                    {
                        Console.WriteLine("Error");
                    }
                }


            Thread.Sleep(500);
                Console.Clear();
            }



            if (closeConn())
            {
                Console.WriteLine("Connection Closed Succesfully");
            }
            Thread.Sleep(500);
        }
    }
}
