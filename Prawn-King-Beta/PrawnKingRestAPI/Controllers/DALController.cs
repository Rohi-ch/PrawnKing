using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DAL;

namespace PrawnKingRestAPI.Controllers
{
    public class DALController : ApiController
    {
        public string Get(string function, int? id, string username, string password, string fname, string lname, string phone, string data)
        {

            string returnString;
            returnString = "";

            switch (function)
            {
                case "testConn":
                    if(DAL.DAL.testConnection())
                    {
                        returnString = "Connection Established";
                    }
                    else
                    {
                        returnString = "Connection Not Established";
                    }
                    break;
                case "tryLogin":
                    if(username != null && password != null)
                    {
                        if (DAL.DAL.tryLogin(username,password))
                        {
                            returnString = "Success";
                        }
                        else
                        {
                            returnString = "Fail";
                        }
                    }
                    else
                    {
                        returnString = "Please provide all credentials";
                    }
                    break;
                case "checkUsername":
                    if(username != null)
                    {
                        if(DAL.DAL.checkAvailability(username)) 
                        {
                            returnString = "Available";
                        }
                        else
                        {
                            returnString = "Unavailable";
                        }
                    }
                    else
                    {
                        returnString = "Please provide username";
                    }
                    break;
                case "getTankID":
                    if (id != null)
                    {
                        returnString = DAL.DAL.getTank(id.ToString()); ;             
                    }
                    else
                    {
                        returnString = "Please provide an ID";
                    }
                    break;
                case "getTankData":
                    if (id != null)
                    {
                        returnString = DAL.DAL.getData(id.ToString()); ;
                    }
                    else
                    {
                        returnString = "Please provide a Tank ID";
                    }
                    break;
                case "createAccount":
                    if (username != null && password != null && fname != null && lname != null)
                    {
                        if(DAL.DAL.createAcc(username, password, fname, lname, phone))
                        {
                            returnString = "Success";
                        }
                        else
                        {
                            returnString = "Fail";
                        }
                    }
                    else
                    {
                        returnString = "Please provide all details";
                    }
                    break;
                case "insertData":
                    if (id != null && data != null)
                    {
                        if (DAL.DAL.insertData(id.ToString(),data))
                        {
                            returnString = "Success";
                        }
                        else
                        {
                            returnString = "Fail";
                        }
                    }
                    else
                    {
                        returnString = "Please provide all details";
                    }
                    break;
                default:
                    returnString = "Invalid request";
                    break;
            }

            return returnString;
        }
    }
}