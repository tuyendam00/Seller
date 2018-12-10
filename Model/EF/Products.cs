namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Products
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Products()
        {
            OrderDetails = new HashSet<OrderDetails>();
        }

        public long ID { get; set; }

        public long? Category_id { get; set; }

        public int? Size_id { get; set; }

        public int? Color_id { get; set; }

        public int? Contry_id { get; set; }

        public int? Material_id { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(250)]
        public string MetaTitle { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? Quantity { get; set; }

        public decimal? Price { get; set; }

        [StringLength(250)]
        public string Image { get; set; }

        public int? Warranty { get; set; }

        [Column(TypeName = "ntext")]
        public string Description { get; set; }

        public DateTime? TopHot { get; set; }

        public bool? Status { get; set; }

        public virtual Categories Categories { get; set; }

        public virtual Colors Colors { get; set; }

        public virtual Contries Contries { get; set; }

        public virtual Materials Materials { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }

        public virtual Sizes Sizes { get; set; }
    }
}
