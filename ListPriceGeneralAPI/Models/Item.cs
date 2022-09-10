using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ListPriceGeneralAPI.Models
{
    public class Item
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required(ErrorMessage = "This field is required.")]
        [DisplayName("Item Name")]
        [Column(TypeName = "nvarchar(50)")]
        public string ItemName { get; set; }

        [Precision(18, 2)]
        public decimal ItemPrice { get; set; }
    }
}
