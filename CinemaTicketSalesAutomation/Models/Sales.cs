using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTicketSalesAutomation.Models
{
    public class Sales:BaseClass
    {
        public Sales()
        {
            CreationDate = DateTime.Now.ToString();
        }
        public string CreationDate { get; set; }
        public decimal TotalPrice { get; set; }
        public int Count { get; set; }
        public string SessionTime { get; set; }
        public override string ToString()
        {
            return $"You bought {Count} ticket for {SessionTime} of {MovieName} at {CreationDate}. Total price is {TotalPrice}$";
        }
    }
}
