namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Slides
    {
        public int ID { get; set; }

        [StringLength(250)]
        public string Image { get; set; }

        public int? DisplayOrder { get; set; }

        [StringLength(10)]
        public string CreatedDate { get; set; }

        [StringLength(250)]
        public string Link { get; set; }

        public bool? Status { get; set; }
    }
}
