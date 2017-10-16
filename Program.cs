using Npgsql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;

namespace Companies
{
    public class Program
    {
        public static void Main(string[] args)
        {
            /*var connString = "server=localhost;user id=postgres;database=diamondedge";
            var conn =  new NpgsqlConnection(connString);
            conn.Open();
            NpgsqlCommand command = new NpgsqlCommand("SELECT * From agenttype",conn);
            NpgsqlDataReader dr = command.ExecuteReader();
            while(dr.Read())
            {
                Console.WriteLine("{0}\t{1} \n", dr[0],dr[1]);   
            }
            conn.Dispose();*/
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}
