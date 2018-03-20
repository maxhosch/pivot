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
    /// Interaktionslogik für LogInPage.xaml
    /// </summary>
    public partial class LogInPage : Page
    {
        public LogInPage()
        {
            InitializeComponent();
        }

        //Init variables
        User loginData;

        //
        //Log In Button
        //
        private void ButtonLogIn_Click(object sender, RoutedEventArgs e)
        {
            loginData = new User(textboxUsername.Text, passwordboxPassword.Password);

            if (loginData.ValidateUsername() || String.IsNullOrEmpty(loginData.Username))
            {
                textboxUsername.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Resources/TextBoxFailed.png")));
                Console.WriteLine("Username not available");
            }
            else
            {
                textboxUsername.ClearValue(BackgroundProperty);
                Console.WriteLine("Username available");

                if (!loginData.Login())
                {
                    passwordboxPassword.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Resources/TextBoxFailed.png")));
                    Console.WriteLine("Wrong password");
                } 
                else
                {
                    //NavigationService.Navigate(new LogInPage());
                    LauncherWindow launcher = new LauncherWindow();
                    launcher.Show();
                    launcher.labelUsername.Content = loginData.Username; //Forward Username

                    var loginWindow = Window.GetWindow(this);
                    loginWindow.Close();
                }
            }

        }

        //
        //Sign Up Button
        //
        private void LabelSignUp_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                NavigationService.Navigate(new SignUpPage());
            }
        }

        //
        //Cuebanner Label click focuses textbox
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
}
