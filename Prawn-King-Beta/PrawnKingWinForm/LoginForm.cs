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
    public partial class LoginForm : Form
    {
        private bool mouseDown;
        private Point lastLocation;
        private string response;

        public LoginForm()
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
            LoginLBL.Text = "Logging In";
            LoginBGWorker.RunWorkerAsync();
        }

        private string testConn()
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(@"https://prawnkingrestapi.azurewebsites.net/api/DAL?function=testConn&id=&username=&password=&fname=&lname=&phone=&data=");
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                string content = new StreamReader(response.GetResponseStream()).ReadToEnd();
                return content;
            }
            catch
            {
                return "Conn Error";
            }
        }
        private string checkLogin(string usr, string pass)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://prawnkingrestapi.azurewebsites.net/api/DAL?function=tryLogin&id=&username=" + usr.ToString() + "&password=" + pass.ToString() + "&fname=&lname=&phone=&data=");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string content = new StreamReader(response.GetResponseStream()).ReadToEnd();
            return content;
        }

        private void LoginBGWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if(testConn() == "\"Connection Established\"")
            {
                string LoginResponse = checkLogin(usrTB.Text,hasher(hasher(passTB.Text)));
                if(LoginResponse == "\"Success\"")
                {
                    response = "yes";
                }
                else if(LoginResponse == "\"Please provide all credentials\"")
                {
                    response = "Please Provide Username and Password!";
                }
                else
                {
                    response = "Incorrect Credentials!";
                }
            }
            else
            {
                response = "Connection Failure!";
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

        private void LoginBGWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (response == "yes")
                {
                Form MF = new MainForm();
                MF.Show();
                this.Hide();
            }
            else {
                MessageBox.Show(response);
            }
            LoginBTN.Enabled = true;
            LoginLBL.Text = "Log In";
        }

        private void newAccLBL_Click(object sender, EventArgs e)
        {
            Form SU = new SignUpForm();
            SU.Show();
            this.Hide();
        }

        private void LoginBTN_Paint(object sender, PaintEventArgs e)
        {

        }

        private void passTB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoginBTN_Click(null, System.EventArgs.Empty);
            }
        }
    }
}
