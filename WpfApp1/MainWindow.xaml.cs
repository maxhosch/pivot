using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Xml;
using WpfApp1.LocalAuth;

namespace WpfApp1
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        public MainWindow()
        {
            InitializeComponent();
        }

        //
        //Move Login Form
        //
        private void ImageLogo_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        //
        //Log In Button
        //
        private void ButtonLogIn_Click(object sender, RoutedEventArgs e)
        {

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
        //Sign Up Button
        //
        private void LabelSignUp_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {         
                Window signUp = new SignUpWindow();
                signUp.Show();
            }
        }
    }

    namespace LocalAuth
    {
        public class LauncherCredentials : XmlDocument
        {
            enum Apps { Steam, Origin, Uplay, Lol };

            public LauncherCredentials()
            {
                XmlDeclaration xmlDeclaration = this.CreateXmlDeclaration("1.0", "UTF-8", null);
                XmlElement root = this.CreateElement("Users");
                this.InsertAfter(xmlDeclaration, root);
            }

            public LauncherCredentials(string fileName)
            {
                if (File.Exists(fileName))
                {
                    this.Load(fileName);
                }
                else
                {
                    XmlDeclaration xmlDeclaration = this.CreateXmlDeclaration("1.0", "UTF-8", null);
                    XmlElement root = this.CreateElement("Users");
                    this.InsertAfter(xmlDeclaration, root);
                    this.Save(fileName);
                }
            }

            public User[] GetAllUsers()
            {
                User[] Users;

                XmlNodeList XmlUsers = this.GetElementsByTagName("User");
                int UserCount = XmlUsers.Count;
                Users = new User[UserCount];
                int Counter = 0;
                foreach (XmlNode XmlUser in XmlUsers)
                {
                    int.TryParse(XmlUser.Attributes.GetNamedItem("App").InnerText, out int UserApp);
                    Users[Counter] = new User(XmlUser.FirstChild.InnerText, XmlUser.LastChild.InnerText, UserApp);
                    Counter++;
                }

                return Users;
            }

            public User[] GetAllUsers(int app)
            {
                User[] Users;

                XmlNodeList XmlUsers = this.GetElementsByTagName("User");
                int Counter = 0;
                int UserCounter = 0;
                foreach (XmlNode XmlUser in XmlUsers)
                {
                    if (XmlUser.Attributes.GetNamedItem("App").InnerText == app.ToString())
                    {
                        UserCounter++;
                    }
                    Counter++;
                }

                Users = new User[UserCounter];
                Counter = 0;
                foreach (XmlNode XmlUser in XmlUsers)
                {
                    if (XmlUser.Attributes.GetNamedItem("App").InnerText == app.ToString())
                    {
                        int.TryParse(XmlUser.Attributes.GetNamedItem("App").InnerText, out int UserApp);
                        Users[Counter] = new User(XmlUser.FirstChild.InnerText, XmlUser.LastChild.InnerText, UserApp);
                        Counter++;
                    }
                }

                return Users;
            }

            public User[] GetAllUsers(string name)
            {
                User[] Users;

                XmlNodeList XmlUsers = this.GetElementsByTagName("User");
                int Counter = 0;
                int UserCounter = 0;
                foreach (XmlNode XmlUser in XmlUsers)
                {
                    if (XmlUser.FirstChild.InnerText == name)
                    {
                        UserCounter++;
                    }
                    Counter++;
                }

                Users = new User[UserCounter];
                Counter = 0;
                foreach (XmlNode XmlUser in XmlUsers)
                {
                    if (XmlUser.FirstChild.InnerText == name)
                    {
                        int.TryParse(XmlUser.Attributes.GetNamedItem("App").InnerText, out int UserApp);
                        Users[Counter] = new User(XmlUser.FirstChild.InnerText, XmlUser.LastChild.InnerText, UserApp);
                        Counter++;
                    }
                }

                return Users;
            }

            public void CreateUser(string username, string password, int app)
            {
                XmlElement NewUser = this.CreateElement("User");
                NewUser.SetAttribute("App", app.ToString());
                XmlElement Name = this.CreateElement("Name");
                Name.InnerText = username;
                NewUser.AppendChild(Name);
                XmlElement Password = this.CreateElement("Password");
                Password.InnerText = password;
                NewUser.AppendChild(Password);
            }

            public User GetFirstUser(string name)
            {
                foreach (XmlNode XmlUser in this.GetElementsByTagName("User"))
                {
                    if (XmlUser.FirstChild.InnerText == name)
                    {
                        int.TryParse(XmlUser.Attributes.GetNamedItem("App").InnerText, out int UserApp);
                        return new User(XmlUser.FirstChild.InnerText, XmlUser.LastChild.InnerText, UserApp);
                    }
                }
                throw new UnknownUserException(String.Format("A User with name {0} could not be found.", name));
            }

            public User GetFirstUser(int app)
            {
                foreach (XmlNode XmlUser in this.GetElementsByTagName("User"))
                {
                    if (XmlUser.Attributes.GetNamedItem("App").InnerText == app.ToString())
                    {
                        int.TryParse(XmlUser.Attributes.GetNamedItem("App").InnerText, out int UserApp);
                        return new User(XmlUser.FirstChild.InnerText, XmlUser.LastChild.InnerText, UserApp);
                    }
                }
                throw new UnknownUserException(String.Format("A User with app {0} could not be found.", app.ToString()));
            }
        }

        public class User
        {
            string Name { get; set; }
            string Password { get; set; }
            int App { get; set; }

            public User()
            {

            }

            public User(string name, string password, int app)
            {
                Name = name;
                Password = password;
                App = app;
            }
        }

        [Serializable()]
        public class UnknownUserException : System.Exception
        {
            public UnknownUserException() : base() { }
            public UnknownUserException(string message) : base(message) { }
            public UnknownUserException(string message, System.Exception inner) : base(message, inner) { }

            protected UnknownUserException(System.Runtime.Serialization.SerializationInfo info,
                System.Runtime.Serialization.StreamingContext context)
            { }
        }
    }
}
