namespace LogIn_Form
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
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
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonMinimize = new System.Windows.Forms.Button();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.buttonLogIn = new System.Windows.Forms.Button();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.pictureBoxClose = new System.Windows.Forms.PictureBox();
            this.pictureBoxMinimize = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMinimize)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(0, 0);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 8;
            // 
            // buttonMinimize
            // 
            this.buttonMinimize.Location = new System.Drawing.Point(0, 0);
            this.buttonMinimize.Name = "buttonMinimize";
            this.buttonMinimize.Size = new System.Drawing.Size(75, 23);
            this.buttonMinimize.TabIndex = 9;
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxEmail.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxEmail.Location = new System.Drawing.Point(30, 191);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(304, 20);
            this.textBoxEmail.TabIndex = 2;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxPassword.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPassword.Location = new System.Drawing.Point(30, 245);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(304, 20);
            this.textBoxPassword.TabIndex = 3;
            // 
            // buttonLogIn
            // 
            this.buttonLogIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLogIn.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLogIn.ForeColor = System.Drawing.Color.White;
            this.buttonLogIn.Location = new System.Drawing.Point(30, 335);
            this.buttonLogIn.Name = "buttonLogIn";
            this.buttonLogIn.Size = new System.Drawing.Size(304, 39);
            this.buttonLogIn.TabIndex = 4;
            this.buttonLogIn.Text = "Log In";
            this.buttonLogIn.UseVisualStyleBackColor = true;
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxLogo.Image")));
            this.pictureBoxLogo.Location = new System.Drawing.Point(1, 1);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(362, 175);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLogo.TabIndex = 5;
            this.pictureBoxLogo.TabStop = false;
            this.pictureBoxLogo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxLogo_MouseDown);
            this.pictureBoxLogo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxLogo_MouseMove);
            this.pictureBoxLogo.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBoxLogo_MouseUp);
            // 
            // pictureBoxClose
            // 
            this.pictureBoxClose.Image = global::LogIn_Form.Properties.Resources.closeX;
            this.pictureBoxClose.Location = new System.Drawing.Point(337, 12);
            this.pictureBoxClose.Name = "pictureBoxClose";
            this.pictureBoxClose.Size = new System.Drawing.Size(15, 15);
            this.pictureBoxClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxClose.TabIndex = 6;
            this.pictureBoxClose.TabStop = false;
            this.pictureBoxClose.Click += new System.EventHandler(this.pictureBoxClose_Click);
            this.pictureBoxClose.MouseHover += new System.EventHandler(this.pictureBoxClose_MouseHover);
            // 
            // pictureBoxMinimize
            // 
            this.pictureBoxMinimize.Image = global::LogIn_Form.Properties.Resources.minimize_;
            this.pictureBoxMinimize.Location = new System.Drawing.Point(308, 12);
            this.pictureBoxMinimize.Name = "pictureBoxMinimize";
            this.pictureBoxMinimize.Size = new System.Drawing.Size(15, 15);
            this.pictureBoxMinimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxMinimize.TabIndex = 7;
            this.pictureBoxMinimize.TabStop = false;
            this.pictureBoxMinimize.Click += new System.EventHandler(this.pictureBoxMinimize_Click);
            this.pictureBoxMinimize.MouseHover += new System.EventHandler(this.pictureBoxMinimize_MouseHover);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 511);
            this.Controls.Add(this.pictureBoxMinimize);
            this.Controls.Add(this.pictureBoxClose);
            this.Controls.Add(this.pictureBoxLogo);
            this.Controls.Add(this.buttonLogIn);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.textBoxEmail);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "TerraByte";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMinimize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonMinimize;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Button buttonLogIn;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.PictureBox pictureBoxClose;
        private System.Windows.Forms.PictureBox pictureBoxMinimize;
    }
}

