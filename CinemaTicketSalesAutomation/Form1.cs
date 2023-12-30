using CinemaTicketSalesAutomation.Helpers;
using CinemaTicketSalesAutomation.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CinemaTicketSalesAutomation
{
    public partial class Form1 : Form
    {
        SqlConnection join = new SqlConnection("Data Source=DESKTOP-TOURGOO\\SQLEXPRESS;Initial Catalog=CinemaTicket;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
        }        

        List<Movie> movies;
        DateTime currentDate = DateTime.Now;
        DateTime useDate;
        Form2 form2;
        private void RemoveFromTable()
        {
            join.Open();
            SqlCommand sqlCommand = new SqlCommand("DELETE FROM BuyTable;DELETE FROM ChairStatus;", join);
            sqlCommand.ExecuteNonQuery();
            join.Close();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            RemoveFromTable();
            useDate = currentDate;
            label1_date.Text = useDate.ToShortDateString();
            movies = Helper.CreateMovies();
            ListControls();
            form2 = new Form2(movies, this);            
        }

        private void ListControls()
        {
            Size pictureSize = new Size(300, 180);
            Size buttonSize = new Size(90, 40);
            int x = 50, y = 100,
                xIncrement = 400,
                yIncrement = 300;
            for (int i = 0; i < movies.Count; i++)
            {
                PictureBox picture = new PictureBox();
                picture.Location = new Point(x, y);
                picture.Size = pictureSize;
                picture.Image = Image.FromFile(movies[i].PicturePath);
                picture.SizeMode = PictureBoxSizeMode.StretchImage;
                this.Controls.Add(picture);
                int buttonX = x;
                int buttonY = picture.Bottom + 10;
                for (int k = 0; k < 3; k++)
                {
                    Button button = new Button();
                    button.Text = movies[i].Sessions[k].Time;
                    button.Location = new Point(buttonX, buttonY);
                    button.Size = buttonSize;
                    button.Tag = i;
                    button.Click += new EventHandler(button_Click);
                    this.Controls.Add(button);
                    buttonX += buttonSize.Width + 10;

                }
                if (1200 > x + xIncrement + picture.Width)
                {
                    x += xIncrement;
                }
                else
                {
                    x = 50;
                    y += yIncrement;
                }
            }
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            int movieIndex = Convert.ToInt32(button.Tag);
            string sessionTime = button.Text;
            string sessionDate = label1_date.Text;
            if (DateTime.Parse($"{sessionDate} {sessionTime}") < DateTime.Now)
            {
                MessageBox.Show("This session has expired !", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            this.Hide();
            form2.Show();
            form2.ListDetail(movieIndex, sessionTime, sessionDate);
        }

        private void button1_next_Click(object sender, EventArgs e)
        {
            useDate = useDate.AddDays(1);
            label1_date.Text = useDate.ToShortDateString();
            button2_previous.Enabled = true;
            if (currentDate.AddDays(2) == useDate)
            {
                button1_next.Enabled = false;
            }
        }

        private void button2_previous_Click(object sender, EventArgs e)
        {
            useDate = useDate.AddDays(-1);
            label1_date.Text = useDate.ToShortDateString();
            button1_next.Enabled = true;
            if (currentDate == useDate)
            {
                button2_previous.Enabled = false;
            }
        }
    }
}
