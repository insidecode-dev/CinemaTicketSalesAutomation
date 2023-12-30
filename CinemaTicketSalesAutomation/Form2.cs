using CinemaTicketSalesAutomation.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace CinemaTicketSalesAutomation
{
    public partial class Form2 : Form
    {
        SqlConnection join = new SqlConnection("Data Source=DESKTOP-TOURGOO\\SQLEXPRESS;Initial Catalog=CinemaTicket;Integrated Security=True");
        
        public Form2()
        { }
        public Form2(List<Movie> _movies, Form1 _form1)
        {
            InitializeComponent();
            movies = _movies;
            form1 = _form1;
        }
        List<Movie> movies;
        Form1 form1;
        Movie selectedMovie;
        Session selectedSession;

        public void ListDetail(int movieIndex, string _time, string _date)
        {
            selectedMovie = movies[movieIndex];
            selectedSession = selectedMovie.Sessions.Find(session => session.Time == _time && session.Date == _date);
            label1_time.Text = $"{_date} - {_time}";
            label9_minute.Text = selectedMovie.Minute;
            label10_price.Text = selectedMovie.Price.ToString() + "$";
            pictureBox1.Image = Image.FromFile(selectedMovie.PicturePath);
            label9_category.Text = selectedMovie.Category[0].ToString();
            CheckChairsStatus();
        }

        private void CheckChairsStatus()
        {
            foreach (Control item in groupBox1_chairs.Controls)
            {
                if (item is Button)
                {
                    string row = item.Tag.ToString();
                    string number = item.Text;
                    item.Enabled = true;
                    foreach (Chair chair in selectedSession.Chairs)
                    {
                       
                            if (chair.Row == row && chair.Number == number)
                            {

                                if (chair.Status )
                                {
                                    item.BackColor = Color.DarkRed;
                                    item.Enabled = false;
                                }
                                else
                                {
                                    item.BackColor = Color.LightGreen;
                                }
                                break;
                            }
                        }
                    }
                }
            }
            List<Chair> chairs = new List<Chair>();
            private void button19_Click(object sender, EventArgs e)
            {
                Button button = sender as Button;
                string row = button.Tag.ToString();
                string number = button.Text;
                Chair chair = selectedSession.Chairs.Find(x => x.Number == number && x.Row == row);
                if (button.BackColor.Name != "Blue")
                {
                    chairs.Add(chair);
                    button.BackColor = Color.Blue;
                }
                else
                {
                    chairs.Remove(chair);
                    button.BackColor = Color.LightGreen;
                }
            }
            Sales sales1;
            private void button25_buy_Click(object sender, EventArgs e)
            {
                if (chairs.Count == 0)
                {
                    MessageBox.Show("Choose at least one chair");
                    return;
                }
                Sales sales = new Sales();
                sales1 = sales;
                sales.MovieName = selectedMovie.MovieName;
                sales.Count = chairs.Count;
                sales.SessionTime = $"{selectedSession.Date} - {selectedSession.Time}";
                sales.TotalPrice = CalculatePrice();
                foreach (Chair chair in chairs)
                {
                    chair.Status = true;
                    AddToTableChair(chair);
                }
                MessageBox.Show(sales.ToString());
                AddToTableFilm();
                ChangePage();
            }
        
        private void AddToTableFilm()
            {
                join.Open();
                SqlCommand sqlCommand = new SqlCommand("insert into BuyTable (ChairCount, SessionTime, MovieName, CreationDate, TotalPrice) values (@chaircount, @sessiontime, @moviename, @creationdate, @totalprice)", join);
                sqlCommand.Parameters.AddWithValue("@chaircount", sales1.Count);
                sqlCommand.Parameters.AddWithValue("@sessiontime", sales1.SessionTime);
                sqlCommand.Parameters.AddWithValue("@moviename", sales1.MovieName);
                sqlCommand.Parameters.AddWithValue("@creationdate", sales1.CreationDate);
                sqlCommand.Parameters.AddWithValue("@totalprice", sales1.TotalPrice);
                sqlCommand.ExecuteNonQuery();
                join.Close();
            }

            private void AddToTableChair(Chair chair)
            {
                join.Open();
                SqlCommand sqlCommand = new SqlCommand("insert into ChairStatus (Status, Row, Number) values (@status, @row, @number)", join);
                sqlCommand.Parameters.AddWithValue("@status", true);
                sqlCommand.Parameters.AddWithValue("@row", chair.Row);
                sqlCommand.Parameters.AddWithValue("@number", chair.Number);
                sqlCommand.ExecuteNonQuery();
                join.Close();
            }

            private void ChangePage()
            {
                radioButton1_small.Checked = radioButton2_medium.Checked = radioButton3_king.Checked = false;


                chairs.Clear();
                this.Hide();
                form1.Show();
            }
            private decimal CalculatePrice()
            {
                decimal price = selectedMovie.Price * chairs.Count;
                if (radioButton1_small.Checked)
                {
                    price += 3;
                }
                else if (radioButton2_medium.Checked)
                {
                    price += 6;
                }
                else if (radioButton3_king.Checked)
                {
                    price += 9;
                }
                return price;
            }

            private void button26_reject_Click(object sender, EventArgs e)
            {
                ChangePage();
            }
            //public int ReturnChairCount()
            //{
            //    int k = 0;
            //    if (selectedSession==null)
            //    {
            //        return k;
            //    }
            //    else
            //    {
            //        chairs = selectedSession.Chairs;

            //        foreach (Chair chair in chairs)
            //        {
            //            if (chair.Status == true)
            //            {
            //                k++;
            //            }
            //        }
            //        return k;
            //    }
            //    return k;
            //}
        }
    }
