using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TimesheetsWebApp2
{
    public class EmployeeWeek
    {
        public string name { get; set; }
        public int EmployeeId { get; set; }
        public int ShopId { get; set; }
        public List<HoursWorked> Hours = new List<HoursWorked>();
        public DateTime WeekStarting { get; set; }
        private Model1 db = new Model1();

        public EmployeeWeek(int EmployeeId, DateTime WeekStarting, int ShopId)
        {
            this.WeekStarting = WeekStarting;
            this.name = db.Employees.Find(EmployeeId).EmployeeName;
            this.EmployeeId = EmployeeId;
            this.ShopId = ShopId;
            for (int i = 0; i < 7; i++)
            {
                HoursWorked hw = db.HoursWorkeds.Find(WeekStarting.AddDays(i), EmployeeId, ShopId);
                if (hw == null)
                {
                    Hours.Add(new HoursWorked() { DateWorked = WeekStarting.AddDays(i), EmployeeId = EmployeeId, ShopId = ShopId, TotalHoursWorked = 0});
                }
                else
                {
                    Hours.Add(hw);
                }
            }
        }
    }
}