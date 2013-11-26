using Insight.Database;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Testy1.Models;

namespace Testy1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        string myConn;

        //private static string connectionString = ConfigurationManager.ConnectionStrings["Server = DIMITRIS-PC" + "; Database = School; Trusted_Connection = True;"].ConnectionString;
        private static ConnectionStringSettings myDatabase = ConfigurationManager.ConnectionStrings["School"];


        public MainWindow()
        {
            InitializeComponent();
            myConn = "Server = DIMITRIS-PC" + "; Database = School; Trusted_Connection = True;";

            //Database.SetInitializer<SchoolContext>(new SchoolInitializer());
            //SchoolContext context = new SchoolContext();
            //context.Database.CreateIfNotExists();
            
        }

        private void btn_GetData_Click(object sender, RoutedEventArgs e)
        {
            List<Person> beers = new List<Person>();

            using (var c = new SqlConnection(myConn).OpenConnection())
            {
                // do stuff...
                c.QuerySql("SELECT * FROM Person", Parameters.Empty);
            }

            try
            {
                using (SqlConnection myConnection = new SqlConnection(myConn))
                {
                    SqlDataReader myReader = null;
                    string sqlString = "SELECT * FROM Person";

                    myConnection.Open();
                    using (SqlCommand sqlComm = new SqlCommand(sqlString, myConnection))
                    {

                        myReader = sqlComm.ExecuteReader();

                        int i = 1;

                        while (myReader.Read())
                        {
                            Person dp = new Person();
                            dp.FirstName = myReader["FirstName"].ToString();
                            dp.LastName = myReader["LastName"].ToString();
                            //dp.HireDate = myReader["HireDate"].ToString();
                            //dp.EnrollmentDate = myReader["EnrollmentDate"].ToString();
                            beers.Add(dp);
                            //i++;
                        }

                        lst_Data.ItemsSource = beers;

                        myConnection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Connection error", MessageBoxButton.OK, MessageBoxImage.Error);
                //Application.Exit(); // finish the program  
            }
        }

        private void btn_GetData_Insight_Click(object sender, RoutedEventArgs e)
        {
            SqlConnectionStringBuilder database = new SqlConnectionStringBuilder(myConn);

            // run a query right off the connection (this performs an auto-open/close)
            database.Connection().QuerySql("SELECT * FROM Person", Parameters.Empty);

            IList<Person> beers = database.Connection().QuerySql<Person>("SELECT * FROM Person");

            //List<Person> beers = new List<Person>();
            lst_Data.ItemsSource = beers;   
        }
    }
}
