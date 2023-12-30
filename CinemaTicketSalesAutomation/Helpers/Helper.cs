using CinemaTicketSalesAutomation.Enum;
using CinemaTicketSalesAutomation.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CinemaTicketSalesAutomation.Helpers
{
    public class Helper
    {
        static List<Movie> dataList = new List<Movie>();
        string connectionString = "Data Source=DESKTOP-TOURGOO\\SQLEXPRESS;Initial Catalog=CinemaTicket;Integrated Security=True";
        public static List<Movie> CreateMovies()
        {
            string basePath = "C:/Users/Admino/source/repos/CinemaTicketSalesAutomation/CinemaTicketSalesAutomation/Pictures/";
            using (SqlConnection connection = new SqlConnection(new Helper().connectionString))
            {
                connection.Open();
                string selectSql = "SELECT * FROM MovieData";
                SqlCommand selectCommand = new SqlCommand(selectSql, connection);
                using (SqlDataReader reader = selectCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Movie dataObject = new Movie();
                        dataObject.MovieName = reader.GetString(1);
                        string dt = reader.GetString(2);
                        dataObject.Category = new List<string>();
                        dataObject.Category.Add(dt);
                        dataObject.Minute = reader.GetString(3);
                        dataObject.Price = reader.GetInt32(4);
                        dataObject.PicturePath = basePath + reader.GetString(5);
                        dataList.Add(dataObject);
                    }
                }
                connection.Close();
            }
            return dataList;
        }
    }
}
