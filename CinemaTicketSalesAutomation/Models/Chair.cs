using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTicketSalesAutomation.Models
{
    public class Chair
    {
        public Chair(string _row, string _number)
        {
            Row = _row;
            Number = _number;
        }

        public string Row { get; set; }
        public string Number { get; set; }
        public bool Status { get; set; }
    }
}
