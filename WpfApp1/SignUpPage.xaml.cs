using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.OnlineAuth;

namespace WpfApp1
{
    /// <summary>
    /// Interaktionslogik für SignUpPage.xaml
    /// </summary>
    public partial class SignUpPage : Page
    {
        public SignUpPage()
        {
            InitializeComponent();
        }

        //Init variables
        String username;
        String password;
        String email;
        String betakey;
        User userdata;

        //
        //SignUp Button
        //
        private void ButtonSignUp_Click(object sender, RoutedEventArgs e)
        {
            userdata = new User(textboxUsername.Text, passwordboxPassword.Password, textboxEmail.Text);
            betakey = textboxBetaKey.Text;
            bool usernameAvailable = false;
            bool emailAvailable = false;
            bool passwordAvailable = false;
            bool betakeyAvailable = false;

            if (!SignUpValidation.CheckUsername(userdata))
            {
                textboxUsername.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Resources/TextBoxFailed.png")));
            }
            else
            {
                textboxUsername.ClearValue(BackgroundProperty);
                Console.WriteLine("Username available");
                usernameAvailable = true;
            }

            if (!SignUpValidation.CheckEmail(userdata))
            {
                textboxEmail.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Resources/TextBoxFailed.png")));
            }
            else
            {
                textboxEmail.ClearValue(BackgroundProperty);
                Console.WriteLine("Email available");
                emailAvailable = true;
            }

            if (!SignUpValidation.CheckPassword(userdata))
            {
                passwordboxPassword.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Resources/TextBoxFailed.png")));
            }
            else
            {
                passwordboxPassword.ClearValue(BackgroundProperty);
                Console.WriteLine("Password available");
                passwordAvailable = true;
            }

            BetaKey key = SignUpValidation.CheckBetaKey(betakey);
            if (key == null)
            {
                textboxBetaKey.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Resources/TextBoxFailed.png")));
            }
            else
            {
                textboxBetaKey.ClearValue(BackgroundProperty);
                Console.WriteLine("Betakey available");
                betakeyAvailable = true;
            }

            //Create User
            if (usernameAvailable && emailAvailable && passwordAvailable && betakeyAvailable)
            {
                try
                {
                    key.UseBetaKey(userdata.Username);
                    userdata.GenerateUser();
                    NavigationService.Navigate(new LogInPage());
                }
                catch(Exception exception)
                {
                    Console.WriteLine(exception.ToString());
                }
            }
        }

        //
        //Login Label Button
        //
        private void LabelLogIn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                NavigationService.Navigate(new LogInPage());
            }
        }

        //
        //Cuebanner Label Button
        //
        private void LabelCuebanner_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 1) //Note that this is a lie, this does not check for a "real" click
            {
                var label = (Label)sender;
                Keyboard.Focus(label.Target);
            }
        }

        //
        //Check Passwordbox changed
        //
        private void OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordBox pb = sender as PasswordBox;
            pb.Tag = (!string.IsNullOrEmpty(pb.Password)).ToString();
        }
    }

    public class SignUpValidation
    {

        public static bool CheckUsername(User user)
        {
            bool check = false;
            
            if (!String.IsNullOrEmpty(user.Username) && user.Username.Length > 1)
            {
                check = user.ValidateUsername();
                //check = true;
            }

            return check;
        }
        
        public static bool CheckEmail(User user)
        {
            bool check = false;
            if (!String.IsNullOrEmpty(user.Email))
            {
                try
                {
                    var addr = new System.Net.Mail.MailAddress(user.Email);
                }
                catch
                {
                    return check;
                }
                check = user.ValidateEmail();
                //check = true;
            }

            return check;
        }

        public static bool CheckPassword(User user)
        {
            bool check = false;
            if (!String.IsNullOrEmpty(user.Password) && user.Password.Length >= 8)
            {
                check = true;
            }

            return check;
        }

        public static BetaKey CheckBetaKey(string betakey)
        {
            BetaKey key = null;
            if (!String.IsNullOrEmpty(betakey) && betakey.Length == 20)
            {
                key = BetaKey.ValidateBetaKey(betakey);
            }
            return key;
        }
    }
}
