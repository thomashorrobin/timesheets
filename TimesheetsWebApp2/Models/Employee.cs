namespace TimesheetsWebApp2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Employee
    {
        public Employee()
        {
            WeeklyTotals = new HashSet<WeeklyTotal>();
            HoursWorkeds = new HashSet<HoursWorked>();
            Managers = new HashSet<Manager>();
            TimeSheets = new HashSet<TimeSheet>();
            TimeSheets1 = new HashSet<TimeSheet>();
            WagedEmployees = new HashSet<WagedEmployee>();
        }

        [Required]
        [StringLength(100)]
        public string EmployeeName { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EmployeeId { get; set; }

        [StringLength(100)]
        public string UserName { get; set; }

        public virtual ICollection<WeeklyTotal> WeeklyTotals { get; set; }

        public virtual ICollection<HoursWorked> HoursWorkeds { get; set; }

        public virtual ICollection<Manager> Managers { get; set; }

        public virtual ICollection<TimeSheet> TimeSheets { get; set; }

        public virtual ICollection<TimeSheet> TimeSheets1 { get; set; }

        public virtual ICollection<WagedEmployee> WagedEmployees { get; set; }

        [NotMapped]
        public string ShopsWorkedAt { get; set; }
    }
}
