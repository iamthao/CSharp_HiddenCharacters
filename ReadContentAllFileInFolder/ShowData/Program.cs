using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Repository;

namespace ShowData
{
    class Program
    {
        static void Main(string[] args)
        {
            //var folder = System.IO.Directory.GetCurrentDirectory() +@"\Thao\";
            //var file = Directory.GetFiles(folder, "*.txt");

            //Console.WriteLine(folder);

            string cs = @"server=localhost;port=3306;database=libris;uid=root;password=root";

            MySqlConnection conn = null;
            MySqlDataReader rdr = null;

            try
            {
                conn = new MySqlConnection(cs);
                conn.Open();

                string stm = "SELECT * FROM Action";
                MySqlCommand cmd = new MySqlCommand(stm, conn);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Console.WriteLine(rdr.GetInt32(0) + ": "
                        + rdr.GetString(1));
                }

            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: {0}", ex.ToString());

            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }

            Console.ReadLine();
        }
    }
}
