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
using System.Text.RegularExpressions;

namespace PrawnKingWinForm
{
    public partial class MainForm : Form
    {
        private bool mouseDown;
        private Point lastLocation;
        private string response;

        public MainForm()
        {
            InitializeComponent();
            writeCSV();
            BindData("data.csv");
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
        private string testConn()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(@"https://prawnkingrestapi.azurewebsites.net/api/DAL?function=testConn&id=&username=&password=&fname=&lname=&phone=&data=");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string content = new StreamReader(response.GetResponseStream()).ReadToEnd();
            return content;
        }
        private string writeCSV()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(@"https://prawnkingrestapi.azurewebsites.net/api/DAL?function=getTankData&id=2&username=&password=&fname=&lname=&phone=&data=");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string content = new StreamReader(response.GetResponseStream()).ReadToEnd();

            List<string> contentList = new List<string>();

            

            contentList = content.Split(new[] { @"\r\n\" }, StringSplitOptions.None).ToList();

            StreamWriter sw = new StreamWriter("data.csv");
            foreach(string item in contentList)
            {
                sw.WriteLine(item);
            }
            sw.Close();
            return content;
        }

        private void closeBTN_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void closeBTN_MouseEnter(object sender, EventArgs e)
        {
            closeBTN.BackColor = Color.FromArgb(70, 70, 70);
        }

        private void closeBTN_MouseLeave(object sender, EventArgs e)
        {
            closeBTN.BackColor = Color.FromArgb(77, 77, 77);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
            label1.Text = "Overview";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
            label1.Text = "Data";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage3;
            label1.Text = "Settings";
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var sb = new StringBuilder();

            var headers = dataGridView1.Columns.Cast<DataGridViewColumn>();
            sb.AppendLine(string.Join(",", headers.Select(column => "\"" + column.HeaderText + "\"").ToArray()));

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                var cells = row.Cells.Cast<DataGridViewCell>();
                sb.AppendLine(string.Join(",", cells.Select(cell => "\"" + cell.Value + "\"").ToArray()));
            }

            string str1 = insertData("2", sb.ToString());

           if (str1 != "\"Success\"")
            {
                MessageBox.Show("Error Saving Data!");
            }
        }
        private string insertData(string id, string data)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://prawnkingrestapi.azurewebsites.net/api/DAL?function=insertData&id="+id+"&username=&password=&fname=&lname=&phone=&data=" + data);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string content = new StreamReader(response.GetResponseStream()).ReadToEnd();
            return content;
        }

        private void BindData(string filePath)
        {
            DataTable dt = new DataTable();
            string[] lines = System.IO.File.ReadAllLines(filePath);
            if (lines.Length > 0)
            {
                //first line to create header
                string firstLine = lines[0];
                string[] headerLabels = firstLine.Split(',');
                foreach (string headerWord in headerLabels)
                {
                    int currpos = Array.IndexOf(headerLabels, headerWord);
                    headerLabels[currpos] = Regex.Replace(headerWord, @"\\", "");
                    headerLabels[currpos] = Regex.Replace(headerLabels[currpos], "\"", "");
                    dt.Columns.Add(new DataColumn(headerLabels[currpos]));
                }
                //For Data
                for (int i = 1; i < lines.Length; i++)
                {
                    string[] dataWords = lines[i].Split(',');
                    DataRow dr = dt.NewRow();
                    int columnIndex = 0;
                    foreach (string headerWord in headerLabels)
                    {
                            string temp = dataWords[columnIndex++];
                            temp = Regex.Replace(temp, "[^0-9]", "");
                            dr[headerWord] = temp;
                       
                    }
                    dt.Rows.Add(dr);
                }
            }
            if (dt.Rows.Count > 0)
            {
                dataGridView1.DataSource = dt;
            }

        }
    }
}
        