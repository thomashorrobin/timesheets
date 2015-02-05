namespace TimesheetsWebApp2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ColorShop
    {
        public ColorShop()
        {
            HoursWorkeds = new HashSet<HoursWorked>();
            Managers = new HashSet<Manager>();
            TimeSheets = new HashSet<TimeSheet>();
            WagedEmployees = new HashSet<WagedEmployee>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ShopId { get; set; }

        [Required]
        [StringLength(50)]
        public string ShopName { get; set; }

        public virtual ICollection<HoursWorked> HoursWorkeds { get; set; }

        public virtual ICollection<Manager> Managers { get; set; }

        public virtual ICollection<TimeSheet> TimeSheets { get; set; }

        public virtual ICollection<WagedEmployee> WagedEmployees { get; set; }
    }
}
