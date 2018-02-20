namespace LogIn_Form
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen. Max was here Max was here again
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.buttonLogIn = new System.Windows.Forms.Button();
            this.pictureBoxMinimize = new System.Windows.Forms.PictureBox();
            this.pictureBoxClose = new System.Windows.Forms.PictureBox();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.pictureBoxPassword = new System.Windows.Forms.PictureBox();
            this.pictureBoxEmail = new System.Windows.Forms.PictureBox();
            this.labelNoName = new System.Windows.Forms.Label();
            this.panelNoName = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMinimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEmail)).BeginInit();
            this.panelNoName.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(23)))));
            this.textBoxEmail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxEmail.Font = new System.Drawing.Font("Open Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxEmail.ForeColor = System.Drawing.SystemColors.Window;
            this.textBoxEmail.Location = new System.Drawing.Point(25, 196);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(304, 18);
            this.textBoxEmail.TabIndex = 2;
            this.textBoxEmail.GotFocus += new System.EventHandler(this.textBoxEmail_GotFocus);
            this.textBoxEmail.LostFocus += new System.EventHandler(this.textBoxEmail_LostFocus);
            this.textBoxEmail.MouseEnter += new System.EventHandler(this.textBoxEmail_MouseEnter);
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(23)))));
            this.textBoxPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxPassword.Font = new System.Drawing.Font("Open Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPassword.ForeColor = System.Drawing.SystemColors.Window;
            this.textBoxPassword.Location = new System.Drawing.Point(25, 246);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(304, 18);
            this.textBoxPassword.TabIndex = 3;
            this.textBoxPassword.UseSystemPasswordChar = true;
            this.textBoxPassword.GotFocus += new System.EventHandler(this.textBoxPassword_GotFocus);
            this.textBoxPassword.LostFocus += new System.EventHandler(this.textBoxPassword_LostFocus);
            this.textBoxPassword.MouseEnter += new System.EventHandler(this.textBoxPassword_MouseEnter);
            // 
            // buttonLogIn
            // 
            this.buttonLogIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(136)))), ((int)(((byte)(43)))));
            this.buttonLogIn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonLogIn.Font = new System.Drawing.Font("Open Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLogIn.ForeColor = System.Drawing.Color.White;
            this.buttonLogIn.Location = new System.Drawing.Point(25, 335);
            this.buttonLogIn.Name = "buttonLogIn";
            this.buttonLogIn.Size = new System.Drawing.Size(304, 30);
            this.buttonLogIn.TabIndex = 4;
            this.buttonLogIn.Text = "Log In";
            this.buttonLogIn.UseVisualStyleBackColor = false;
            this.buttonLogIn.Click += new System.EventHandler(this.buttonLogIn_Click);
            // 
            // pictureBoxMinimize
            // 
            this.pictureBoxMinimize.Image = global::LogIn_Form.Properties.Resources.Minimize;
            this.pictureBoxMinimize.Location = new System.Drawing.Point(308, 12);
            this.pictureBoxMinimize.Name = "pictureBoxMinimize";
            this.pictureBoxMinimize.Size = new System.Drawing.Size(15, 15);
            this.pictureBoxMinimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxMinimize.TabIndex = 7;
            this.pictureBoxMinimize.TabStop = false;
            this.pictureBoxMinimize.Click += new System.EventHandler(this.pictureBoxMinimize_Click);
            this.pictureBoxMinimize.MouseEnter += new System.EventHandler(this.pictureBoxMinimize_MouseEnter);
            this.pictureBoxMinimize.MouseLeave += new System.EventHandler(this.pictureBoxMinimize_MouseLeave);
            // 
            // pictureBoxClose
            // 
            this.pictureBoxClose.Image = global::LogIn_Form.Properties.Resources.Close;
            this.pictureBoxClose.Location = new System.Drawing.Point(329, 12);
            this.pictureBoxClose.Name = "pictureBoxClose";
            this.pictureBoxClose.Size = new System.Drawing.Size(15, 15);
            this.pictureBoxClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxClose.TabIndex = 6;
            this.pictureBoxClose.TabStop = false;
            this.pictureBoxClose.Click += new System.EventHandler(this.pictureBoxClose_Click);
            this.pictureBoxClose.MouseEnter += new System.EventHandler(this.pictureBoxClose_MouseEnter);
            this.pictureBoxClose.MouseLeave += new System.EventHandler(this.pictureBoxClose_MouseLeave);
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Image = global::LogIn_Form.Properties.Resources.LogoLogInForm;
            this.pictureBoxLogo.Location = new System.Drawing.Point(2, 2);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(350, 174);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLogo.TabIndex = 5;
            this.pictureBoxLogo.TabStop = false;
            this.pictureBoxLogo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxLogo_MouseDown);
            this.pictureBoxLogo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxLogo_MouseMove);
            this.pictureBoxLogo.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBoxLogo_MouseUp);
            // 
            // pictureBoxPassword
            // 
            this.pictureBoxPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.pictureBoxPassword.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxPassword.Image")));
            this.pictureBoxPassword.Location = new System.Drawing.Point(20, 240);
            this.pictureBoxPassword.Name = "pictureBoxPassword";
            this.pictureBoxPassword.Size = new System.Drawing.Size(314, 30);
            this.pictureBoxPassword.TabIndex = 8;
            this.pictureBoxPassword.TabStop = false;
            this.pictureBoxPassword.Click += new System.EventHandler(this.pictureBoxPassword_Click);
            this.pictureBoxPassword.MouseEnter += new System.EventHandler(this.pictureBoxPassword_MouseEnter);
            this.pictureBoxPassword.MouseLeave += new System.EventHandler(this.pictureBoxPassword_MouseLeave);
            // 
            // pictureBoxEmail
            // 
            this.pictureBoxEmail.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.pictureBoxEmail.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxEmail.Image")));
            this.pictureBoxEmail.Location = new System.Drawing.Point(20, 190);
            this.pictureBoxEmail.Name = "pictureBoxEmail";
            this.pictureBoxEmail.Size = new System.Drawing.Size(314, 30);
            this.pictureBoxEmail.TabIndex = 9;
            this.pictureBoxEmail.TabStop = false;
            this.pictureBoxEmail.Click += new System.EventHandler(this.pictureBoxEmail_Click);
            this.pictureBoxEmail.MouseEnter += new System.EventHandler(this.pictureBoxEmail_MouseEnter);
            this.pictureBoxEmail.MouseLeave += new System.EventHandler(this.pictureBoxEmail_MouseLeave);
            // 
            // labelNoName
            // 
            this.labelNoName.AutoSize = true;
            this.labelNoName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelNoName.Font = new System.Drawing.Font("Open Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNoName.ForeColor = System.Drawing.SystemColors.Window;
            this.labelNoName.Location = new System.Drawing.Point(70, 5);
            this.labelNoName.Name = "labelNoName";
            this.labelNoName.Size = new System.Drawing.Size(148, 18);
            this.labelNoName.TabIndex = 10;
            this.labelNoName.Text = "Account name required";
            // 
            // panelNoName
            // 
            this.panelNoName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panelNoName.Controls.Add(this.labelNoName);
            this.panelNoName.Location = new System.Drawing.Point(20, 154);
            this.panelNoName.Name = "panelNoName";
            this.panelNoName.Size = new System.Drawing.Size(314, 30);
            this.panelNoName.TabIndex = 11;
            this.panelNoName.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::LogIn_Form.Properties.Resources.Background2;
            this.ClientSize = new System.Drawing.Size(355, 510);
            this.Controls.Add(this.panelNoName);
            this.Controls.Add(this.pictureBoxMinimize);
            this.Controls.Add(this.pictureBoxClose);
            this.Controls.Add(this.pictureBoxLogo);
            this.Controls.Add(this.buttonLogIn);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.textBoxEmail);
            this.Controls.Add(this.pictureBoxPassword);
            this.Controls.Add(this.pictureBoxEmail);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TerraByte";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMinimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEmail)).EndInit();
            this.panelNoName.ResumeLayout(false);
            this.panelNoName.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Button buttonLogIn;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.PictureBox pictureBoxClose;
        private System.Windows.Forms.PictureBox pictureBoxMinimize;
        private System.Windows.Forms.PictureBox pictureBoxPassword;
        private System.Windows.Forms.PictureBox pictureBoxEmail;
        private System.Windows.Forms.Label labelNoName;
        private System.Windows.Forms.Panel panelNoName;
    }
}

