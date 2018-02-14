using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogIn_Form
{
    public partial class Form1 : Form
    {

        ///Variables
        //int bgColor = 35;
        private bool mouseDown;
        private Point lastLocation;


        ///Create Stuff
        //bg Color
        Color bgColor = Color.FromArgb(35, 35, 35);
        //Button bg Color
        Color buttonLogInBgColor = Color.FromArgb(56, 136, 43);
        //Init CueBanner
        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);



        public Form1()
        {
            InitializeComponent();
            this.BackColor = bgColor;
            this.buttonLogIn.BackColor = buttonLogInBgColor;
            SendMessage(textBoxEmail.Handle, 0x1501, 1, "E-Mail");
            SendMessage(textBoxPassword.Handle, 0x1501, 1, "Password");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        /**
        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        **/

        //PictureBoxClose
        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBoxClose_MouseEnter(object sender, EventArgs e)
        {
            this.pictureBoxClose.Image = global::LogIn_Form.Properties.Resources.closeXhover;
        }

        private void pictureBoxClose_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBoxClose.Image = global::LogIn_Form.Properties.Resources.closeX;
        }



        //PictureBoxMinimize
        private void pictureBoxMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBoxMinimize_MouseEnter(object sender, EventArgs e)
        {
            this.pictureBoxMinimize.Image = global::LogIn_Form.Properties.Resources.minimize_hover;
        }

        private void pictureBoxMinimize_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBoxMinimize.Image = global::LogIn_Form.Properties.Resources.minimize_;
        }



        //Move Login Form
        private void pictureBoxLogo_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void pictureBoxLogo_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown) {
                this.Location = new Point((this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);
                this.Update();
            }
        }

        private void pictureBoxLogo_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
    }
}
