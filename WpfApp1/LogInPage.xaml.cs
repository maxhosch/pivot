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

        //
        //Log In Button
        //
        private void ButtonLogIn_Click(object sender, RoutedEventArgs e)
        {

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
    }
}
