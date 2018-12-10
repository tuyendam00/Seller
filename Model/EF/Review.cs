namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Review")]
    public partial class Review
    {
        public long ID { get; set; }

        public long? Product_id { get; set; }

        [StringLength(250)]
        public string NickName { get; set; }

        public string Comment { get; set; }
    }
}
