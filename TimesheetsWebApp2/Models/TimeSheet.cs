namespace TimesheetsWebApp2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TimeSheet
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ShopId { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "date")]
        public DateTime WeekStarting { get; set; }

        public int? PreparedBy { get; set; }

        public int? ApprovedBy { get; set; }

        public string Comments { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TimeSheetId { get; set; }

        public string TimesheetFileName { get; set; }

        public virtual ColorShop ColorShop { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual Employee Employee1 { get; set; }
    }
}
