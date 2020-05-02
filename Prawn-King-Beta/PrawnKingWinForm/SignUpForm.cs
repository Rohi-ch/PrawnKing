using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace PrawnKingWinForm
{
    public partial class SignUpForm : Form
    {
        private bool mouseDown;
        private Point lastLocation;
        private string response;

        public SignUpForm()
        {
            InitializeComponent();
        }

        private void LoginBTN_MouseEnter(object sender, EventArgs e)
        {
            LoginBTN.BackColor = Color.FromArgb(30, 170, 140);
        }

        private void LoginBTN_MouseLeave(object sender, EventArgs e)
        {
            LoginBTN.BackColor = Color.FromArgb(41, 184, 156);
        }

        private void closeBTN_MouseEnter(object sender, EventArgs e)
        {
            closeBTN.BackColor = Color.FromArgb(70,70,70);
        }

        private void closeBTN_MouseLeave(object sender, EventArgs e)
        {
            closeBTN.BackColor = Color.FromArgb(77, 77, 77);
        }

        private void closeBTN_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void newAccLBL_MouseEnter(object sender, EventArgs e)
        {
            newAccLBL.BackColor = Color.FromArgb(70, 70, 70);
        }

        private void newAccLBL_MouseLeave(object sender, EventArgs e)
        {
            newAccLBL.BackColor = Color.FromArgb(77, 77, 77);
        }

        private void DragBar_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void DragBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void DragBar_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void usrTB_Enter(object sender, EventArgs e)
        {
            if (usrTB.Text == "Username")
            {
                usrTB.Text = "";
            }
        }

        private void usrTB_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(usrTB.Text))
                usrTB.Text = "Username";
        }

        private void passTB_Enter(object sender, EventArgs e)
        {
            if (passTB.Text == "Password")
            {
                passTB.Text = "";
            }
        }

        private void passTB_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(passTB.Text))
                passTB.Text = "Password";
        }

        private void LoginBTN_Click(object sender, EventArgs e)
        {
            LoginBTN.Enabled = false;
            LoginBGWorker.RunWorkerAsync();
        }


        private void LoginBGWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show(response);
            LoginBTN.Enabled = true;
        }

        private void FirstNameTB_Enter(object sender, EventArgs e)
        {
            if (FirstNameTB.Text == "First Name")
            {
                FirstNameTB.Text = "";
            }
        }

        private void FirstNameTB_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(FirstNameTB.Text))
                FirstNameTB.Text = "First Name";
        }

        private void LastNameTB_Enter(object sender, EventArgs e)
        {
            if (LastNameTB.Text == "Last Name")
            {
                LastNameTB.Text = "";
            }
        }

        private void LastNameTB_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(LastNameTB.Text))
                LastNameTB.Text = "Last Name";
        }

        private string testConn()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(@"https://prawnkingrestapi.azurewebsites.net/api/DAL?function=testConn&id=&username=&password=&fname=&lname=&phone=&data=");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string content = new StreamReader(response.GetResponseStream()).ReadToEnd();
            return content;
        }
        private string createAcc(string usr, string pass, string fname, string lname)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://prawnkingrestapi.azurewebsites.net/api/DAL?function=createAccount&id=&username=" + usr.ToString() + "&password=" + pass.ToString() + "&fname=" + fname.ToString()+ "&lname=" + lname.ToString()+ "&phone=0000&data=");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string content = new StreamReader(response.GetResponseStream()).ReadToEnd();
            return content;
        }
        private string checkAvail(string usr)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://prawnkingrestapi.azurewebsites.net/api/DAL?function=checkUsername&id=&username=" + usr.ToString() + "&password=&fname=&lname=&phone=&data=");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string content = new StreamReader(response.GetResponseStream()).ReadToEnd();
            return content;
        }

        private void LoginBGWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if(testConn() == "\"Connection Established\"")
            {
                if (checkAvail(usrTB.Text) == "\"Available\"")
                {
                    string LoginResponse = createAcc(usrTB.Text, hasher(hasher(passTB.Text)), FirstNameTB.Text, LastNameTB.Text);
                    if (LoginResponse == "\"Success\"")
                    {
                        response = "Account Created!";
                    }
                    else if (LoginResponse == "\"Please provide all credentials\"")
                    {
                        response = "Please Provide Username and Password!";
                    }
                    else
                    {
                        response = "Error!";
                    }
                }
                else
                {
                    response = "Username not available!";
                }
            }
        }

        private string hasher(string hash)
        {
            string hashResponse;

            SHA1CryptoServiceProvider sh = new SHA1CryptoServiceProvider();
            sh.ComputeHash(ASCIIEncoding.ASCII.GetBytes(hash));
            byte[] re = sh.Hash;
            StringBuilder sb = new StringBuilder();
            foreach(byte b in re)
            {
                sb.Append(b.ToString("x2"));
            }
            hashResponse = sb.ToString();

            return hashResponse;
        }

        private void newAccLBL_Click(object sender, EventArgs e)
        {
            Form SU = new LoginForm();
            SU.Show();
            this.Hide();
        }

        private void LoginBTN_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SignUpForm_Load(object sender, EventArgs e)
        {

        }

        private void LastNameTB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoginBTN_Click(null, System.EventArgs.Empty);
            }
        }
    }
}
