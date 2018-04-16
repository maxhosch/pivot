using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// Interaktionslogik für AccountsPage.xaml
    /// </summary>
    public partial class AccountsPage : Page
    {

        public AccountsPage()
        {

            InitializeComponent();
            LoadListViewAccounts();
        }

        //
        //Close Button
        //
        private void ImageClose_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                Popup.Visibility = Visibility.Hidden;
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

        //
        //ContextMenu Image MouseDown
        //
        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                Image image = sender as Image;
                ContextMenu contextMenu = image.ContextMenu;
                contextMenu.PlacementTarget = image;
                contextMenu.Placement = PlacementMode.RelativePoint;
                contextMenu.VerticalOffset = 35;
                contextMenu.IsOpen = true;
                e.Handled = true;
            }
        }

        //
        //ListView
        //
        private void ListView_ItemClick(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
            }
        }

        private ObservableCollection<Account> accounts = new ObservableCollection<Account>();
        public void LoadListViewAccounts()
        {
            //var accounts = new List<Account>();

            accounts.Add(new Account { App = "pack://application:,,,/Resources/IconSteam.png", Username = "xxspiderdoenerxx", Email = "justus@istcool.com", Fav = true });
            accounts.Add(new Account { App = "pack://application:,,,/Resources/IconSteam.png", Username = "1nside", Email = "max@stinkt.com", Fav = false });
            accounts.Add(new Account { App = "pack://application:,,,/Resources/IconOrigin.png", Username = "BotLouLou", Email = "Smurfing@RealLife.com", Fav = true });
            accounts.Add(new Account { App = "pack://application:,,,/Resources/IconSteam.png", Username = "test", Email = "test@gmail.com", Fav = true });
            accounts.Add(new Account { App = "pack://application:,,,/Resources/IconOrigin.png", Username = "iowiionaf", Email = "jiojij3@gmail.com", Fav = true });

            ListViewAccounts.ItemsSource = accounts;

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(ListViewAccounts.ItemsSource);
            view.SortDescriptions.Add(new SortDescription("Email", ListSortDirection.Ascending));
        }

        private void ItemApp_Click(object sender, RoutedEventArgs e)
        {
            UpdateListView("App");
        }

        private void ItemUsername_Click(object sender, RoutedEventArgs e)
        {
            UpdateListView("Username");
        }

        private void ItemEmail_Click(object sender, RoutedEventArgs e)
        {
            UpdateListView("Email");
        }

        public void UpdateListView(String SortBy)
        {
            ICollectionView view = CollectionViewSource.GetDefaultView(ListViewAccounts.ItemsSource);
            view.SortDescriptions.Clear();
            view.SortDescriptions.Add(new SortDescription(SortBy, ListSortDirection.Ascending));
            view.Refresh();
            Console.WriteLine("Sort by " + SortBy);
        }

        //
        //Button Delete
        //
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            //new LauncherWindow().VarPopupBackground = Visibility.Visible;
            //MainWindow win = (MainWindow)Application.Current.MainWindow;
            //win.PopupBlackground.Text = "";
            Popup.Visibility = Visibility.Visible;
        }

        //
        //Image Delete
        //
        private void ImageDelete_MouseDown(object sender, MouseButtonEventArgs e)
        {
            object clicked = (e.OriginalSource as FrameworkElement).DataContext;
            var lbi = ListViewAccounts.ItemContainerGenerator.ContainerFromItem(clicked) as ListViewItem;
            lbi.IsSelected = true;
            accounts.Remove(ListViewAccounts.SelectedItem as Account);
        }
    }

    /**
    public class Account
    {
        public string App { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public bool Fav { get; set; }
    }
    **/

    public class Account : INotifyPropertyChanged
    {
        private string app;
        private string username;
        private string email;
        private bool fav;
        public string App
        {
            get { return this.app; }
            set
            {
                if (this.app != value)
                {
                    this.app = value;
                    this.NotifyPropertyChanged("App");
                }
            }
        }
        public string Username
        {
            get { return this.username; }
            set
            {
                if (this.username != value)
                {
                    this.username = value;
                    this.NotifyPropertyChanged("Username");
                }
            }
        }
        public string Email
        {
            get { return this.email; }
            set
            {
                if (this.email != value)
                {
                    this.email = value;
                    this.NotifyPropertyChanged("Email");
                }
            }
        }
        public bool Fav
        {
            get { return this.fav; }
            set
            {
                if (this.fav != value)
                {
                    this.fav = value;
                    this.NotifyPropertyChanged("Fav");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }

}
