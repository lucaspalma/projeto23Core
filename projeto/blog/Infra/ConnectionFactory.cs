using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace blog.Infra
{
    public class ConnectionFactory
    {
        
        public static SqlConnection CriaConexaoAberta()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();
            IConfiguration configuration = builder.Build();
            string stringConexao = configuration.GetConnectionString("Blog");
            SqlConnection conexao = new SqlConnection(stringConexao);
            conexao.Open();
            return conexao;
        }
    }
}