using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace Exercise2
{
    class Program
    {
        static string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;"+
            " Data Source=Example2.mdb";
        static void Main(string[] args)
        {
            using (OleDbConnection dbConnect = new OleDbConnection(connectionString))
            {
                dbConnect.Open();
                string command = @"
SELECT ProductId, COUNT(*) FROM 
(
    SELECT Sales.ProductId, Sales.CustomerId, Sales.DateCreated FROM 
    (
        (SELECT CustomerId, MIN(DateCreated) AS FirstDate FROM Sales GROUP BY CustomerID) AS FirstSales 
        INNER JOIN Sales ON Sales.CustomerId=FirstSales.CustomerId AND Sales.DateCreated=FirstSales.FirstDate
    )
)
GROUP BY ProductId ORDER BY COUNT(*) DESC";
                OleDbCommand cmd = new OleDbCommand(command,dbConnect);
                OleDbDataReader reader = cmd.ExecuteReader();
                Console.WriteLine("+---------+-----+");
                Console.WriteLine("|ProductId|Count|");
                while (reader.Read())
                {
                    Console.WriteLine("+---------+-----+");
                    Console.WriteLine("|{0,9}|{1,5}|", (int)reader[0], (int)reader[1]);

                }
                Console.WriteLine("+---------+-----+");
                dbConnect.Close();
            }
            Console.ReadKey();
        }
    }
}
