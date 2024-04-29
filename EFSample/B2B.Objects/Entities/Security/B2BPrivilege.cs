using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace B2B.Objects.Entities.Security
{
    [Table("Privileges", Schema = "Security")]
    public class B2BPrivilege
    {
        [Key]
        [StringLength(200)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Type { get; set; }

        [Required]
        [StringLength(50)]
        public string Operation { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        public bool PortalAdminsOnly { get; set; }
        public bool RootAdminPriv { get; set; }
        public bool BuyerAdminPriv { get; set; }
        public bool BuyerPriv { get; set; }
        public bool SupplierPriv { get; set; }
        public bool FunderPriv { get; set; }
    }
}