using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TimesheetsWebApp2.Models
{
    public class NewTimesheetModel
    {
        public int ShopId { get; set; }
        public DateTime WeekStarting { get; set; }
        public int PreparedBy { get; set; }
        public string Comments { get; set; }

        public List<WeeklyTotal> weeklyTotals = new List<WeeklyTotal>();
        public List<HoursWorked> hoursWorked = new List<HoursWorked>();

        public override string ToString()
        {
            return ShopId + " " + WeekStarting.ToShortDateString() + " " + Comments;
        }
    }
}