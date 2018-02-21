using System;
using System.Windows.Forms;
using DotNetOpenAuth.OpenId.RelyingParty;

namespace LogIn_Form
{
    public partial class Form2 : Form
    {
        //OpenId auth 
        private static OpenIdRelyingParty relyingParty;

        static Form2()
        {
            relyingParty = new OpenIdRelyingParty();
        }

        public Form2()
        {
            InitializeComponent();
        }

        private void button1_ClickAsync(object sender, EventArgs e)
        {
            var response = relyingParty.GetResponse();
            if (response == null)
            {
                Console.WriteLine("Response is Null");
            }
            else
            {
                switch (response.Status)
                {
                    case AuthenticationStatus.Canceled:
                        Console.WriteLine("AuthenticationStatus.Canceled");
                        break;
                    case AuthenticationStatus.Failed:
                        Console.WriteLine("AuthenticationStatus.Canceled");
                        Console.WriteLine(response.Exception.Message);
                        break;
                    case AuthenticationStatus.Authenticated:
                        Console.WriteLine("AuthenticationStatus.Authenticated");
                        Console.WriteLine(response.FriendlyIdentifierForDisplay);
                        break;
                    default:
                        Console.WriteLine("default");
                        break;
                }
            }
        }
    }
}
