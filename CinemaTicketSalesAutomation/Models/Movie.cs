using CinemaTicketSalesAutomation.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTicketSalesAutomation.Models
{
    public class Movie:BaseClass
    {
        public Movie()
        {
            SetDefaultSessions();
        }
        public string PicturePath { get; set; }
        public string Minute { get; set; }
        public decimal Price { get; set; }
        public List<string> Category { get; set; }
        public List<Session> Sessions { get; set; }

        private void SetDefaultSessions() {
            Sessions = new List<Session>();
            DateTime currentDate = DateTime.Now;
            TimeSpan ts = new TimeSpan(10, 30, 0);
            for (int i = 0; i < 3; i++)
            {
                currentDate = currentDate.Date + ts;
                for (int k = 0; k < 3; k++)
                {
                    Session session = new Session();
                    session.Date = currentDate.ToShortDateString();
                    session.Time = currentDate.ToShortTimeString();
                    Sessions.Add(session);
                    currentDate = currentDate.AddHours(3);
                }
                currentDate = currentDate.AddDays(1);    
            }
        }
    }
}
