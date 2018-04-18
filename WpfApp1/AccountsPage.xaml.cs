﻿using System;
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
using System.Xml.Linq;
using WpfApp1.LocalAuth;

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
            string AppString = "pack://application:,,,/Resources/IconSteam.png";

            foreach (User User in LauncherCredentials.GetAllUsers())
            {
                switch (User.App)
                {
                    case 0: //Steam
                        AppString = "pack://application:,,,/Resources/IconSteam.png";
                        break;
                    case 1: //Origin
                        AppString = "pack://application:,,,/Resources/IconOrigin.png";
                        break;
                    case 2: //Uplay
                        AppString = "pack://application:,,,/Resources/IconSteam.png";
                        break;
                    case 3: //Lol
                        AppString = "pack://application:,,,/Resources/IconSteam.png";
                        break;
                }
               accounts.Add(new Account { App = AppString, Username = User.Name, Password = User.Password, Email = User.Password, Fav = User.Fav });

            }

            ListViewAccounts.ItemsSource = accounts;

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(ListViewAccounts.ItemsSource);
            view.SortDescriptions.Add(new SortDescription("Username", ListSortDirection.Ascending));
        }

        private void ItemApp_Click(object sender, RoutedEventArgs e)
        {
            SortListView("App");
        }

        private void ItemUsername_Click(object sender, RoutedEventArgs e)
        {
            SortListView("Username");
        }

        private void ItemEmail_Click(object sender, RoutedEventArgs e)
        {
           SortListView("Email");
        }

        public void SortListView(String SortBy)
        {
            ICollectionView view = CollectionViewSource.GetDefaultView(ListViewAccounts.ItemsSource);
            view.SortDescriptions.Clear();
            view.SortDescriptions.Add(new SortDescription(SortBy, ListSortDirection.Ascending));
            view.Refresh();
            Console.WriteLine("Sort by " + SortBy);
        }

        public void UpdateListView()
        {
            accounts.Clear();
            LoadListViewAccounts();
            Console.WriteLine("ListView refreshed");
        }

        //
        //Button Delete
        //
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            Popup.Visibility = Visibility.Visible;
        }

        //
        //Image Delete
        //
        private void ImageDelete_MouseDown(object sender, MouseButtonEventArgs e)
        {
            object clicked = (e.OriginalSource as FrameworkElement).DataContext;
            //ListViewItem lbi = ListViewAccounts.ItemContainerGenerator.ContainerFromItem(clicked) as ListViewItem;
            ListViewAccounts.SelectedItem = clicked;
            ListViewAccounts.ScrollIntoView(clicked);
            ListViewAccounts.Focus();
            accounts.Remove(ListViewAccounts.SelectedItem as Account);
        }

        private void ButtonCreate_Click(object sender, RoutedEventArgs e)
        {
            LauncherCredentials.CreateUser(textboxUsername.Text, textboxEmail.Text, textboxEmail.Text, (int)LauncherCredentials.Apps.Steam, 0);
            Popup.Visibility = Visibility.Hidden;
            UpdateListView();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

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
        private string password;
        private string email;
        private int fav;

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
        public string Password
        {
            get { return this.password; }
            set
            {
                if (this.password != value)
                {
                    this.password = value;
                    this.NotifyPropertyChanged("Password");
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
        public int Fav
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
