namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Comments
    {
        [Key]
        public int Comment_id { get; set; }

        [StringLength(50)]
        public string Customer_name { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [Column(TypeName = "text")]
        public string Content { get; set; }
    }
}
