using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            var cs = "Host=vivify-db.postgres.database.azure.com;Username=azure_vivify_pg_admin@vivify-db;Password=zaq1ZAQ!@123;Database=PathwayResolver";

             var con = new NpgsqlConnection(cs);
            con.Open();

            var sql = "SELECT version()";

             var cmd = new NpgsqlCommand(sql, con);

            var version = cmd.ExecuteScalar().ToString();
            Console.WriteLine($"PostgreSQL version: {version}");

            cmd.CommandText = "select * from Pathways";
            cmd.ExecuteNonQuery();
            
            NpgsqlDataAdapter ad = new NpgsqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            ad.Fill(dt);

            int count = dt.Rows.Count;
        }
    }
}
