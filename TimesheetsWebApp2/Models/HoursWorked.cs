namespace TimesheetsWebApp2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HoursWorked")]
    public partial class HoursWorked
    {
        [Key]
        [Column(Order = 0, TypeName = "date")]
        public DateTime DateWorked { get; set; }

        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }

        public int Breaks { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EmployeeId { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ShopId { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public int? TotalMinutesWorked { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public int? TotalRegularMinutesWorked { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public int? TotalOvertimeMinutesWorked { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public double? TotalHoursWorked { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public double? TotalRegularWorked { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public double? TotalOvertimeWorked { get; set; }

        public virtual ColorShop ColorShop { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
