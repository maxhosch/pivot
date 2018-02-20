using IdentityModel.OidcClient;
using IdentityModel.OidcClient.Browser;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogIn_Form
{
    public partial class Form1 : Form
    {

        //Variables
        private bool mouseDown;
        private Point lastLocation;
        private bool textBoxEmailFocused;
        private bool textBoxPasswordFocused;
        String Email;
        String Password;


        ///Create Stuff
        //bg Color
        Color bgColor = Color.FromArgb(35, 35, 35);
        //Button bg Color
        Color buttonLogInBgColor = Color.FromArgb(56, 136, 43);
        //Init CueBanner
        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);

        //
        //Form Start
        //
        public Form1()
        {
            InitializeComponent();
            this.BackColor = bgColor;
            //this.buttonLogIn.BackColor = buttonLogInBgColor;
            SendMessage(textBoxEmail.Handle, 0x1501, 1, "E-Mail");
            SendMessage(textBoxPassword.Handle, 0x1501, 1, "Password");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //
        //Move Login Form
        //
        private void pictureBoxLogo_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }
        private void pictureBoxLogo_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point((this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);
                this.Update();
            }
        }
        private void pictureBoxLogo_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
        //
        //PictureBoxClose
        //
        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void pictureBoxClose_MouseEnter(object sender, EventArgs e)
        {
            this.pictureBoxClose.Image = global::LogIn_Form.Properties.Resources.CloseHover;
        }
        private void pictureBoxClose_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBoxClose.Image = global::LogIn_Form.Properties.Resources.Close;
        }
        //
        //PictureBoxMinimize
        //
        private void pictureBoxMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void pictureBoxMinimize_MouseEnter(object sender, EventArgs e)
        {
            this.pictureBoxMinimize.Image = global::LogIn_Form.Properties.Resources.MinimizeHover;
        }
        private void pictureBoxMinimize_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBoxMinimize.Image = global::LogIn_Form.Properties.Resources.Minimize;
        }
        //
        //PictureBoxEmail
        //
        private void pictureBoxEmail_Click(object sender, EventArgs e)
        {
            this.textBoxEmail.Select();
        }
        private void pictureBoxEmail_MouseEnter(object sender, EventArgs e)
        {
            if (!textBoxEmailFocused)
            {
                this.pictureBoxEmail.Image = global::LogIn_Form.Properties.Resources.TextBoxHover;
            }
        }
        private void pictureBoxEmail_MouseLeave(object sender, EventArgs e)
        {
            if (!textBoxEmailFocused)
            {
                this.pictureBoxEmail.Image = global::LogIn_Form.Properties.Resources.TextBox;
            }
        }
        //
        //PictureBoxPassword
        //
        private void pictureBoxPassword_Click(object sender, EventArgs e)
        {
            this.textBoxPassword.Select();
        }
        private void pictureBoxPassword_MouseEnter(object sender, EventArgs e)
        {
            if (!textBoxPasswordFocused)
            {
                this.pictureBoxPassword.Image = global::LogIn_Form.Properties.Resources.TextBoxHover;
            }
        }
        private void pictureBoxPassword_MouseLeave(object sender, EventArgs e)
        {
            if (!textBoxPasswordFocused)
            {
                this.pictureBoxPassword.Image = global::LogIn_Form.Properties.Resources.TextBox;
            }
        }
        //
        //textBoxEmail
        //
        private void textBoxEmail_GotFocus(object sender, EventArgs e)
        {
            this.pictureBoxEmail.Image = global::LogIn_Form.Properties.Resources.TextBoxActivated;
            textBoxEmailFocused = true;
        }
        private void textBoxEmail_LostFocus(object sender, EventArgs e)
        {
            textBoxEmailFocused = false;
            this.pictureBoxEmail.Image = global::LogIn_Form.Properties.Resources.TextBox;
        }
        private void textBoxEmail_MouseEnter(object sender, EventArgs e)
        {
            if (!textBoxEmailFocused)
            {
                this.pictureBoxEmail.Image = global::LogIn_Form.Properties.Resources.TextBoxHover;
            }
        }
        //
        //textBoxPassword
        //
        private void textBoxPassword_GotFocus(object sender, EventArgs e)
        {
            this.pictureBoxPassword.Image = global::LogIn_Form.Properties.Resources.TextBoxActivated;
            textBoxPasswordFocused = true;
        }
        private void textBoxPassword_LostFocus(object sender, EventArgs e)
        {
            textBoxPasswordFocused = false;
            this.pictureBoxPassword.Image = global::LogIn_Form.Properties.Resources.TextBox;
        }
        private void textBoxPassword_MouseEnter(object sender, EventArgs e)
        {
            if (!textBoxPasswordFocused)
            {
                this.pictureBoxPassword.Image = global::LogIn_Form.Properties.Resources.TextBoxHover;
            }
        }
        //
        //buttonLogIn
        //
        private void buttonLogIn_Click(object sender, EventArgs e)
        {
            String Email = this.textBoxEmail.Text;
            String Password = this.textBoxPassword.Text;
            if (String.IsNullOrEmpty(Email) || String.IsNullOrEmpty(Password))
            {
                Console.WriteLine("Account name required");
                this.panelNoName.Visible = true;
            }
            else
            {
                Form form2 = new Form2();
                form2.Show();
            }
        }
    }
}