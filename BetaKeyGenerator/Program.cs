using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BetaKeyGenerator.OnlineAuth;

namespace BetaKeyGenerator
{
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
                ValidateBetaKeySQL = "SELECT * FROM BetaKeys WHERE BetaKey=\"{0}\" AND Username IS NULL";

            public int ID { get; private set; }
            public string Key { get; private set; }
            public string Username { get; private set; }

            private BetaKey(int id, string betakey)
            {
                ID = id;
                Key = betakey;
                Username = "";
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
                        Console.WriteLine(String.Format(ValidateBetaKeyUniqueSQL, betakey));
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
                catch (Exception e)
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
                catch (Exception e)
                {
                    throw new TerraDBReadException("Retrieving the BetaKey ID raised an exception: " + e.ToString());
                }

                if (id == -1)
                {
                    throw new TerraDBReadException("BetaKey ID could not be retrieved");
                }

                return new BetaKey(id, betakey);
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

    class Program
    {
        static void Main(string[] args)
        {
            BetaKey key = BetaKey.GenerateBetaKey();
            Console.WriteLine("BetaKey: \r\n ID: " + Convert.ToString(key.ID) + "\r\nKey: " + key.Key);
            Console.ReadKey();
        }
    }
}
