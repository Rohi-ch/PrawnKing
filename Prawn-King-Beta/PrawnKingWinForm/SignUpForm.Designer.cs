namespace PrawnKingWinForm
{
    partial class SignUpForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SignUpForm));
            this.LoginBTN = new System.Windows.Forms.Panel();
            this.LoginLBL = new System.Windows.Forms.Label();
            this.newAccLBL = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.usrTB = new System.Windows.Forms.TextBox();
            this.passTB = new System.Windows.Forms.TextBox();
            this.Title = new System.Windows.Forms.Label();
            this.BetaLBL = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dragBar = new System.Windows.Forms.Panel();
            this.closeBTN = new System.Windows.Forms.Label();
            this.LoginBGWorker = new System.ComponentModel.BackgroundWorker();
            this.LastNameTB = new System.Windows.Forms.TextBox();
            this.FirstNameTB = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.LoginBTN.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.dragBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // LoginBTN
            // 
            this.LoginBTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(184)))), ((int)(((byte)(156)))));
            this.LoginBTN.Controls.Add(this.LoginLBL);
            this.LoginBTN.Location = new System.Drawing.Point(15, 418);
            this.LoginBTN.Name = "LoginBTN";
            this.LoginBTN.Size = new System.Drawing.Size(300, 50);
            this.LoginBTN.TabIndex = 1;
            this.LoginBTN.Click += new System.EventHandler(this.LoginBTN_Click);
            this.LoginBTN.Paint += new System.Windows.Forms.PaintEventHandler(this.LoginBTN_Paint);
            this.LoginBTN.MouseEnter += new System.EventHandler(this.LoginBTN_MouseEnter);
            this.LoginBTN.MouseLeave += new System.EventHandler(this.LoginBTN_MouseLeave);
            // 
            // LoginLBL
            // 
            this.LoginLBL.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.LoginLBL.Font = new System.Drawing.Font("Microsoft YaHei UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginLBL.ForeColor = System.Drawing.Color.White;
            this.LoginLBL.Location = new System.Drawing.Point(0, 0);
            this.LoginLBL.Name = "LoginLBL";
            this.LoginLBL.Size = new System.Drawing.Size(300, 50);
            this.LoginLBL.TabIndex = 0;
            this.LoginLBL.Text = "Sign Up";
            this.LoginLBL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LoginLBL.Click += new System.EventHandler(this.LoginBTN_Click);
            this.LoginLBL.MouseEnter += new System.EventHandler(this.LoginBTN_MouseEnter);
            this.LoginLBL.MouseLeave += new System.EventHandler(this.LoginBTN_MouseLeave);
            // 
            // newAccLBL
            // 
            this.newAccLBL.AutoSize = true;
            this.newAccLBL.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newAccLBL.ForeColor = System.Drawing.Color.White;
            this.newAccLBL.Location = new System.Drawing.Point(89, 481);
            this.newAccLBL.Name = "newAccLBL";
            this.newAccLBL.Size = new System.Drawing.Size(167, 19);
            this.newAccLBL.TabIndex = 2;
            this.newAccLBL.Text = "Already have an account?";
            this.newAccLBL.Click += new System.EventHandler(this.newAccLBL_Click);
            this.newAccLBL.MouseEnter += new System.EventHandler(this.newAccLBL_MouseEnter);
            this.newAccLBL.MouseLeave += new System.EventHandler(this.newAccLBL_MouseLeave);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(15, 278);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 1);
            this.panel1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Location = new System.Drawing.Point(15, 220);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(300, 1);
            this.panel2.TabIndex = 4;
            // 
            // usrTB
            // 
            this.usrTB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.usrTB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.usrTB.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usrTB.ForeColor = System.Drawing.Color.White;
            this.usrTB.Location = new System.Drawing.Point(17, 193);
            this.usrTB.Name = "usrTB";
            this.usrTB.Size = new System.Drawing.Size(298, 25);
            this.usrTB.TabIndex = 5;
            this.usrTB.Text = "Username";
            this.usrTB.Enter += new System.EventHandler(this.usrTB_Enter);
            this.usrTB.Leave += new System.EventHandler(this.usrTB_Leave);
            // 
            // passTB
            // 
            this.passTB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.passTB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.passTB.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passTB.ForeColor = System.Drawing.Color.White;
            this.passTB.Location = new System.Drawing.Point(17, 252);
            this.passTB.Name = "passTB";
            this.passTB.PasswordChar = '*';
            this.passTB.Size = new System.Drawing.Size(298, 25);
            this.passTB.TabIndex = 6;
            this.passTB.Text = "Password";
            this.passTB.Enter += new System.EventHandler(this.passTB_Enter);
            this.passTB.Leave += new System.EventHandler(this.passTB_Leave);
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.ForeColor = System.Drawing.Color.White;
            this.Title.Location = new System.Drawing.Point(108, 107);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(117, 28);
            this.Title.TabIndex = 7;
            this.Title.Text = "Prawn King";
            // 
            // BetaLBL
            // 
            this.BetaLBL.AutoSize = true;
            this.BetaLBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BetaLBL.ForeColor = System.Drawing.Color.White;
            this.BetaLBL.Location = new System.Drawing.Point(142, 136);
            this.BetaLBL.Name = "BetaLBL";
            this.BetaLBL.Size = new System.Drawing.Size(41, 15);
            this.BetaLBL.TabIndex = 8;
            this.BetaLBL.Text = "BETA";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PrawnKingWinForm.Properties.Resources.prawnico;
            this.pictureBox1.Location = new System.Drawing.Point(130, 43);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(60, 60);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // dragBar
            // 
            this.dragBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.dragBar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.dragBar.Controls.Add(this.closeBTN);
            this.dragBar.Location = new System.Drawing.Point(0, 0);
            this.dragBar.Name = "dragBar";
            this.dragBar.Size = new System.Drawing.Size(330, 25);
            this.dragBar.TabIndex = 10;
            this.dragBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DragBar_MouseDown);
            this.dragBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DragBar_MouseMove);
            this.dragBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DragBar_MouseUp);
            // 
            // closeBTN
            // 
            this.closeBTN.AutoSize = true;
            this.closeBTN.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeBTN.ForeColor = System.Drawing.Color.White;
            this.closeBTN.Location = new System.Drawing.Point(309, 3);
            this.closeBTN.Name = "closeBTN";
            this.closeBTN.Size = new System.Drawing.Size(18, 19);
            this.closeBTN.TabIndex = 0;
            this.closeBTN.Text = "X";
            this.closeBTN.Click += new System.EventHandler(this.closeBTN_Click);
            this.closeBTN.MouseEnter += new System.EventHandler(this.closeBTN_MouseEnter);
            this.closeBTN.MouseLeave += new System.EventHandler(this.closeBTN_MouseLeave);
            // 
            // LoginBGWorker
            // 
            this.LoginBGWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.LoginBGWorker_DoWork);
            this.LoginBGWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.LoginBGWorker_RunWorkerCompleted);
            // 
            // LastNameTB
            // 
            this.LastNameTB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.LastNameTB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LastNameTB.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LastNameTB.ForeColor = System.Drawing.Color.White;
            this.LastNameTB.Location = new System.Drawing.Point(17, 364);
            this.LastNameTB.Name = "LastNameTB";
            this.LastNameTB.Size = new System.Drawing.Size(298, 25);
            this.LastNameTB.TabIndex = 14;
            this.LastNameTB.Text = "Last Name";
            this.LastNameTB.Enter += new System.EventHandler(this.LastNameTB_Enter);
            this.LastNameTB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LastNameTB_KeyDown);
            this.LastNameTB.Leave += new System.EventHandler(this.LastNameTB_Leave);
            // 
            // FirstNameTB
            // 
            this.FirstNameTB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.FirstNameTB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.FirstNameTB.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FirstNameTB.ForeColor = System.Drawing.Color.White;
            this.FirstNameTB.Location = new System.Drawing.Point(17, 305);
            this.FirstNameTB.Name = "FirstNameTB";
            this.FirstNameTB.Size = new System.Drawing.Size(298, 25);
            this.FirstNameTB.TabIndex = 13;
            this.FirstNameTB.Text = "First Name";
            this.FirstNameTB.Enter += new System.EventHandler(this.FirstNameTB_Enter);
            this.FirstNameTB.Leave += new System.EventHandler(this.FirstNameTB_Leave);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Location = new System.Drawing.Point(15, 332);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(300, 1);
            this.panel3.TabIndex = 12;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Location = new System.Drawing.Point(15, 390);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(300, 1);
            this.panel4.TabIndex = 11;
            // 
            // SignUpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.ClientSize = new System.Drawing.Size(330, 530);
            this.Controls.Add(this.LastNameTB);
            this.Controls.Add(this.FirstNameTB);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.dragBar);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.BetaLBL);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.passTB);
            this.Controls.Add(this.usrTB);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.newAccLBL);
            this.Controls.Add(this.LoginBTN);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SignUpForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LoginForm";
            this.Load += new System.EventHandler(this.SignUpForm_Load);
            this.LoginBTN.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.dragBar.ResumeLayout(false);
            this.dragBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel LoginBTN;
        private System.Windows.Forms.Label LoginLBL;
        private System.Windows.Forms.Label newAccLBL;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox usrTB;
        private System.Windows.Forms.TextBox passTB;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Label BetaLBL;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel dragBar;
        private System.Windows.Forms.Label closeBTN;
        private System.ComponentModel.BackgroundWorker LoginBGWorker;
        private System.Windows.Forms.TextBox LastNameTB;
        private System.Windows.Forms.TextBox FirstNameTB;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
    }
}

