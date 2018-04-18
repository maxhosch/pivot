using MySql.Data.MySqlClient;
using System;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Xml;
using WpfApp1.LocalAuth;
using WpfApp1.OnlineAuth;

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
            this.MainFrame.Content = new LogInPage();
        }

        //
        //Move Login Form
        //
        private void ImageTopBar_MouseDown(object sender, MouseButtonEventArgs e)
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
    }

    namespace OnlineAuth
    {
        public class TerraDB
        {
            public const string Host = "mahoserv.ddns.net", DBName = "TerraLauncherBeta", Username = "root", Password = "SHMS.1981319";
            public static string GetConnectionString()
            {
                return String.Format("server={0};database={1};user={2};password={3}", Host, DBName, Username, Password);
            }
        }

        public class BetaKey
        {
            static string InsertBetaKeySQL = "INSERT INTO BetaKeys (BetaKey) VALUES (\"{0}\")",
                ValidateBetaKeyUniqueSQL = "SELECT COUNT(id) FROM BetaKeys WHERE BetaKey=\"{0}\"",
                ValidateBetaKeySQL = "SELECT * FROM BetaKeys WHERE BetaKey=\"{0}\" AND Username IS NULL",
                SetBetaKeyUsedSQL = "UPDATE BetaKeys SET Username=\"{0}\" WHERE id={1}";

            public int ID { get; private set; }
            public string Key { get; private set; }
            public string Username { get; private set; }

            private BetaKey(int id, string betakey)
            {
                ID = id;
                Key = betakey;
                Username = "";
            }

            private BetaKey(int id, string betakey, string username)
            {
                ID = id;
                Key = betakey;
                Username = username;
            }

            public static BetaKey GenerateBetaKey()
            {
                string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                string betakey;
                int id = -1;
                while (true)
                {
                    Random random = new Random();
                    betakey = new string(Enumerable.Repeat(chars, 20).Select(s => s[random.Next(s.Length)]).ToArray());

                    try
                    {
                        MySqlConnection conn = new MySqlConnection(TerraDB.GetConnectionString());
                        MySqlCommand cmd;
                        Console.WriteLine("Connecting to TerraDB...");
                        conn.Open();
                        cmd = new MySqlCommand(String.Format(ValidateBetaKeyUniqueSQL, betakey), conn);
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            if (Convert.ToInt32(result) == 0)
                            {
                                conn.Close();
                                break;
                            }
                        }
                        else
                        {
                            conn.Close();
                            throw new TerraDBReadException("ValidateBetaKeyUniqueSQL returned null");
                        }
                    }
                    catch (Exception e)
                    {
                        throw new TerraDBReadException("Exception occurred: " + e.ToString());
                    }
                }
                try
                {
                    MySqlConnection conn = new MySqlConnection(TerraDB.GetConnectionString());
                    MySqlCommand cmd;
                    Console.WriteLine("Connecting to TerraDB...");
                    conn.Open();
                    cmd = new MySqlCommand(String.Format(InsertBetaKeySQL, betakey), conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                catch(Exception e)
                {
                    throw new TerraDBInsertionException("BetaKey insertion caused exception: " + e.ToString());
                }
                try
                {
                    MySqlConnection conn = new MySqlConnection(TerraDB.GetConnectionString());
                    MySqlCommand cmd;
                    Console.WriteLine("Connecting to TerraDB...");
                    conn.Open();
                    cmd = new MySqlCommand(String.Format(ValidateBetaKeySQL, betakey), conn);
                    MySqlDataReader result = cmd.ExecuteReader();
                    while (result.Read())
                    {
                        id = result.GetInt32(0);
                    }
                    conn.Close();
                }
                catch(Exception e)
                {
                    throw new TerraDBReadException("Retrieving the BetaKey ID raised an exception: " + e.ToString());
                }

                if (id == -1)
                {
                    throw new TerraDBReadException("BetaKey ID could not be retrieved");
                }

                return new BetaKey(id, betakey);
            }

            public static BetaKey ValidateBetaKey(string betakey)
            {
                BetaKey key = null;
                try
                {
                    MySqlConnection conn = new MySqlConnection(TerraDB.GetConnectionString());
                    MySqlCommand cmd;
                    Console.WriteLine("Connecting to TerraDB...");
                    conn.Open();
                    cmd = new MySqlCommand(String.Format(ValidateBetaKeySQL, betakey), conn);
                    MySqlDataReader result = cmd.ExecuteReader();
                    while (result.Read())
                    {
                        key = new BetaKey(result.GetInt32(0), result.GetString(1));
                    }
                    conn.Close();
                }
                catch (Exception e)
                {
                    throw new TerraDBReadException("Retrieving the BetaKey information raised an exception: " + e.ToString());
                }
                return key;
            }

            public void UseBetaKey(string username)
            {
                try
                {
                    MySqlConnection conn = new MySqlConnection(TerraDB.GetConnectionString());
                    MySqlCommand cmd;
                    Console.WriteLine("Connecting to TerraDB...");
                    conn.Open();
                    cmd = new MySqlCommand(String.Format(SetBetaKeyUsedSQL, username, this.ID.ToString()), conn);
                    cmd.ExecuteNonQuery();
                    this.Username = username;
                    conn.Close();
                }
                catch (Exception e)
                {
                    throw new TerraDBReadException("Updating the BetaKey Username raised an exception: " + e.ToString());
                }
            }
        }

        public class User
        {
            public int ID { get; private set; }
            public string Username { get; private set; }
            public string Password { get; private set; }
            public string Email { get; private set; }

            const string CheckEmailUniqueSQL = "SELECT COUNT(id) FROM Users WHERE Email=\"{0}\"",
                CreateUserSQL = "INSERT INTO Users (Username, Password, Email) VALUES (\"{0}\", \"{1}\", \"{2}\")",
                CheckUsernameSQL = "SELECT COUNT(id) FROM Users WHERE Username=\"{0}\"",
                CheckPasswordLoginSQL = "SELECT * FROM Users WHERE Username=\"{0}\" AND Password=\"{1}\"",
                DeleteUserSQL = "DELETE FROM Users WHERE id={0}";

            public User(string username, string password)
            {
                ID = -1;
                Username = username;
                Password = password;
                Email = "";
            }

            public User(string username, string password, string email)
            {
                ID = -1;
                Username = username;
                Password = password;
                Email = email;
            }

            // Deprecated

            private User(int id, string username, string password, string email)
            {
                ID = id;
                Username = username;
                Password = password;
                Email = email;
            }

            public void GenerateUser()
            {
                if (this.ID == -1)
                {
                    try
                    {
                        MySqlConnection conn = new MySqlConnection(TerraDB.GetConnectionString());
                        MySqlCommand cmd;
                        Console.WriteLine("Connecting to TerraDB...");
                        conn.Open();
                        cmd = new MySqlCommand(String.Format(CreateUserSQL, this.Username, this.Password, this.Email), conn);
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                    catch (Exception e)
                    {
                        throw new TerraDBInsertionException("User creation caused exception: " + e.ToString());
                    }
                    try
                    {
                        MySqlConnection conn = new MySqlConnection(TerraDB.GetConnectionString());
                        MySqlCommand cmd;
                        Console.WriteLine("Connecting to TerraDB...");
                        conn.Open();
                        cmd = new MySqlCommand(String.Format(CheckPasswordLoginSQL, this.Username, this.Password), conn);
                        MySqlDataReader result = cmd.ExecuteReader();
                        while (result.Read())
                        {
                            this.ID = result.GetInt32(0);
                        }
                        conn.Close();
                    }
                    catch (Exception e)
                    {
                        throw new TerraDBReadException("Retrieving the User ID raised an exception: " + e.ToString());
                    }

                    if (this.ID == -1)
                    {
                        throw new TerraDBReadException("User ID could not be retrieved");
                    }
                }
            }

            public bool ValidateUsername()
            {
                try
                {
                    MySqlConnection conn = new MySqlConnection(TerraDB.GetConnectionString());
                    MySqlCommand cmd;
                    Console.WriteLine("Connecting to TerraDB...");
                    conn.Open();
                    cmd = new MySqlCommand(String.Format(CheckUsernameSQL, this.Username), conn);
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        if (Convert.ToInt32(result) == 0)
                        {
                            conn.Close();
                            return true;
                        }
                    }
                    else
                    {
                        throw new TerraDBReadException("Username could not be validated");
                    }
                    conn.Close();
                    return false;
                }
                catch (Exception e)
                {
                    throw new TerraDBReadException("Validating the Username raised an exception: " + e.ToString());
                }
            }

            public bool ValidatePassword()
            {
                if (this.Password.Length > 8)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public bool ValidateEmail()
            {
                try
                {
                    MySqlConnection conn = new MySqlConnection(TerraDB.GetConnectionString());
                    MySqlCommand cmd;
                    Console.WriteLine("Connecting to TerraDB...");
                    conn.Open();
                    cmd = new MySqlCommand(String.Format(CheckEmailUniqueSQL, this.Email), conn);
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        if (Convert.ToInt32(result) == 0)
                        {
                            conn.Close();
                            return true;
                        }
                    }
                    else
                    {
                        throw new TerraDBReadException("Email could not be validated");
                    }
                    conn.Close();
                    return false;
                }
                catch (Exception e)
                {
                    throw new TerraDBReadException("Validating the Email raised an exception: " + e.ToString());
                }
            }

            public bool Login()
            {
                Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                if (this.ID == -1)
                {
                    try
                    {
                        MySqlConnection conn = new MySqlConnection(TerraDB.GetConnectionString());
                        MySqlCommand cmd;
                        Console.WriteLine("Connecting to TerraDB...");
                        conn.Open();
                        cmd = new MySqlCommand(String.Format(CheckPasswordLoginSQL, this.Username, this.Password), conn);
                        MySqlDataReader rdr = cmd.ExecuteReader();
                        while (rdr.Read())
                        {
                            this.ID = rdr.GetInt32(0);
                            this.Email = rdr.GetString(3);
                        }
                        conn.Close();
                    }
                    catch (Exception e)
                    {
                        throw new TerraDBReadException("Validating the Login raised an exception: " + e.ToString());
                    }
                    if (this.ID == -1)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                else
                {
                    return true;
                }
            }
        }

        [Serializable()]
        public class TerraDBReadException : System.Exception
        {
            public TerraDBReadException() : base() { }
            public TerraDBReadException(string message) : base(message) { }
            public TerraDBReadException(string message, System.Exception inner) : base(message, inner) { }

            protected TerraDBReadException(System.Runtime.Serialization.SerializationInfo info,
                System.Runtime.Serialization.StreamingContext context)
            { }
        }

        [Serializable()]
        public class TerraDBInsertionException : System.Exception
        {
            public TerraDBInsertionException() : base() { }
            public TerraDBInsertionException(string message) : base(message) { }
            public TerraDBInsertionException(string message, System.Exception inner) : base(message, inner) { }

            protected TerraDBInsertionException(System.Runtime.Serialization.SerializationInfo info,
                System.Runtime.Serialization.StreamingContext context)
            { }
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
                    XmlElement root = this.DocumentElement;
                    this.InsertAfter(xmlDeclaration, root);
                    XmlElement Users = this.CreateElement("Users");
                    this.AppendChild(Users);
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
            public string Name { get; private set; }
            public string Password { get; private set; }
            public int App { get; private set; }

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
