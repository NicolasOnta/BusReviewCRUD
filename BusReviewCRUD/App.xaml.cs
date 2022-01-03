using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace BusReviewCRUD
{
    /// <summary>
    /// Lógica de interacción para App.xaml
    /// </summary>
    public partial class App : Application
    {
        // Connection string for using Windows Authentication.
        private string connectionString =
            @"Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        // This is an example connection string for using SQL Server Authentication.
        // private string connectionString =
        //     @"Data Source=YourServerName\YourInstanceName;Initial Catalog=DatabaseName; User Id=XXXXX; Password=XXXXX";

        public string ConnectionString { get => connectionString; set => connectionString = value; }

    
    }
}
