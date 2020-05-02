using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DALTester
{
    class Program
    {
        static void Main(string[] args)
        {
            DAL dal = new DAL();
            while (true)
            {
                Console.WriteLine("PK DAL Testing");
                Console.WriteLine("1 Test Connection");
                Console.WriteLine("2 Get ID");
                Console.WriteLine("3 User Exists");
                Console.WriteLine("4 Add User");
                Console.WriteLine("5 MK Admin");
                Console.WriteLine("6 User Info");
                Console.WriteLine("Else Quit");
                 
                int input = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("-------------------");         

                if (input == 1)
                {
                    if(dal.TestConnection())
                    {
                        Console.WriteLine("Successful Connection");
                    }
                    else
                    {
                        Console.Write("Failure");
                    }
                }
                else if (input == 2)
                {
                    Console.WriteLine("Enter Username");
                    string usrIn = Console.ReadLine();
                    Console.WriteLine("Enter Password");
                    string passIn = Console.ReadLine();
                    string result = dal.GetID(usrIn,passIn);
                    if(result != "")
                    {
                        Console.WriteLine("User ID: " + result);
                    }
                    else
                    {
                        Console.WriteLine("Failed to get ID with Creds");
                    }
                }
                else if (input == 3)
                {
                    Console.WriteLine("Enter Username");
                    string usrIn = Console.ReadLine();
                    int result = dal.UserExists(usrIn);
                    if (result != 0)
                    {
                        Console.WriteLine("User Exists");
                    }
                    else
                    {
                        Console.WriteLine("Username not found");
                    }
                }
                else if (input == 4)
                {
                    Console.WriteLine("Enter Username");
                    string usrIn = Console.ReadLine();
                    Console.WriteLine("Enter Password");
                    string passIn = Console.ReadLine();

                    int usrCheck = dal.UserExists(usrIn);
                    if (usrCheck == 0)
                    {
                        int Rtn = dal.AddUser(usrIn,passIn);
                        if(Rtn == 1)
                        {
                            Console.WriteLine("Successfully added user");
                        }
                        else
                        {
                            Console.WriteLine("Failed");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Failed! Username Conflict");
                    }

                }
                else if (input == 5)
                {
                    Console.WriteLine("Enter Admin Username");
                    string usrIn = Console.ReadLine();
                    Console.WriteLine("Enter Admin Password");
                    string passIn = Console.ReadLine();
                    Console.WriteLine("Enter userID to make admin");
                    int id = Convert.ToInt32(Console.ReadLine());

                    int rtn = dal.mkAdmin(usrIn, passIn, id);
                    if(rtn != 0)
                    {
                        Console.WriteLine("Success");
                    }
                    else
                    {
                        Console.WriteLine("Failiure");
                    }                   
                }
                else if (input == 6)
                {

                }
                else
                {
                    break;
                }
                Console.WriteLine("-------------------");
                Thread.Sleep(1000);
                Console.Clear();
            }
        }
    }
}
