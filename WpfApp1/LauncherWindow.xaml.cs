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
using WpfApp1.LocalAuth;

namespace WpfApp1
{
    /// <summary>
    /// Interaktionslogik für LauncherWindow.xaml
    /// </summary>
    public partial class LauncherWindow : Window
    {

        public LauncherWindow()
        {
            InitializeComponent();
            SwitchActiveTab(1);
            LoadAccounts();
        }

        //
        //Move Login Form
        //
        private void ImageTopBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        //
        //Close Button
        //
        private void ImageClose_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.Close();
            }
        }
        private void ImageClose_MouseEnter(object sender, MouseEventArgs e)
        {
            this.imageClose.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/CloseHover.png"));
        }
        private void ImageClose_MouseLeave(object sender, MouseEventArgs e)
        {
            this.imageClose.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/Close.png"));
        }

        //
        //Minimize Button
        //
        private void ImageMinimize_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.WindowState = WindowState.Minimized;
            }
        }
        private void ImageMinimize_MouseEnter(object sender, MouseEventArgs e)
        {
            this.imageMinimize.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/MinimizeHover.png"));
        }
        private void ImageMinimize_MouseLeave(object sender, MouseEventArgs e)
        {
            this.imageMinimize.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/Minimize.png"));

        }

        //
        //TAB GAMES
        //
        private void LabelGAMES_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.LauncherFrame.Content = new GamesPage();
                SwitchActiveTab(1);
            }
        }

        //
        //TAB CHATS
        //
        private void LabelCHATS_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                SwitchActiveTab(2);
            }
        }

        //
        //TAB ACCOUNTS
        //
        private void LabelACCOUNTS_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                SwitchActiveTab(3);
            }
        }

        //
        //Check active tab
        //
        private void SwitchActiveTab(int Case)
        {
            switch(Case)
            {
                case 1: //Games
                    this.LauncherFrame.Content = new GamesPage();
                    this.labelGAMES.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Resources/TopbarItemBackgroundActivated.png")));
                    this.labelCHATS.ClearValue(BackgroundProperty);
                    this.labelACCOUNTS.ClearValue(BackgroundProperty);
                    this.labelGAMES.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                    this.labelCHATS.ClearValue(ForegroundProperty);
                    this.labelACCOUNTS.ClearValue(ForegroundProperty);
                    Console.WriteLine("Games tab active");
                    break;

                case 2: //Chats
                    this.LauncherFrame.Content = new ChatsPage();
                    this.labelGAMES.ClearValue(BackgroundProperty);
                    this.labelCHATS.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Resources/TopbarItemBackgroundActivated.png")));
                    this.labelACCOUNTS.ClearValue(BackgroundProperty);
                    this.labelGAMES.ClearValue(ForegroundProperty);
                    this.labelCHATS.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                    this.labelACCOUNTS.ClearValue(ForegroundProperty);
                    Console.WriteLine("Chats tab active");
                    break;

                case 3: //Accounts
                    this.LauncherFrame.Content = new AccountsPage();
                    this.labelGAMES.ClearValue(BackgroundProperty);
                    this.labelCHATS.ClearValue(BackgroundProperty);
                    this.labelACCOUNTS.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Resources/TopbarItemBackgroundActivated.png")));
                    this.labelGAMES.ClearValue(ForegroundProperty);
                    this.labelCHATS.ClearValue(ForegroundProperty);
                    this.labelACCOUNTS.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                    Console.WriteLine("Accounts tab active");
                    break;

                default: //Welcomepage?
                    this.labelGAMES.ClearValue(BackgroundProperty);
                    this.labelCHATS.ClearValue(BackgroundProperty);
                    this.labelACCOUNTS.ClearValue(BackgroundProperty);
                    this.labelGAMES.ClearValue(ForegroundProperty);
                    this.labelCHATS.ClearValue(ForegroundProperty);
                    this.labelACCOUNTS.ClearValue(ForegroundProperty);
                    Console.WriteLine("Something is wrong");
                    break;
            }
        }

        //
        //Load Accounts
        //
        private void LoadAccounts()
        {
            new LauncherCredentials("Accounts.xml");
        }
    }
}
