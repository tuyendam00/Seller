namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Orders
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Orders()
        {
            OrderDetails = new HashSet<OrderDetails>();
        }

        public long ID { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(250)]
        [Display(Name = "Người mua")]
        public string ShipName { get; set; }

        [StringLength(50)]
        [Display(Name = "Số điện thoại")]
        public string ShipMobile { get; set; }

        [StringLength(50)]
        [Display(Name = "Địa chỉ")]
        public string ShipAddress { get; set; }

        [StringLength(50)]
        [Display(Name = "Email")]
        public string ShipEmail { get; set; }

        [StringLength(500)]
        [Display(Name = "Chú thích")]
        public string Description { get; set; }

        [Display(Name = "Trạng thái")]
        public bool Status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
