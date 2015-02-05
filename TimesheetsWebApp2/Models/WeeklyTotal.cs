namespace TimesheetsWebApp2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class WeeklyTotal
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TimeSheetId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EmployeeId { get; set; }

        public int RegularMinutesTotal { get; set; }

        public int OvertimeMinutesTotal { get; set; }

        public int AnnualLeaveMinutes { get; set; }

        public int SickLeaveMinutes { get; set; }

        public int OtherLeaveMinutes { get; set; }

        public double RegularHoursTotal { get { return (int)(RegularMinutesTotal / 60) + (double)(RegularMinutesTotal % 60)/60; } }

        public double OvertimeHoursTotal { get { return (int)(OvertimeMinutesTotal / 60) + (double)(OvertimeMinutesTotal % 60) / 60; } }

        public double AnnualLeaveHours { get { return (int)(AnnualLeaveMinutes / 60) + (double)(AnnualLeaveMinutes % 60) / 60; } }

        public double SickLeaveHours { get { return (int)(SickLeaveMinutes / 60) + (double)(SickLeaveMinutes % 60) / 60; } }

        public double OtherLeaveHours { get { return (int)(OtherLeaveMinutes / 60) + (double)(OtherLeaveMinutes % 60) / 60; } }

        [Column(TypeName = "date")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? WeekStarting { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public int? ShopId { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
