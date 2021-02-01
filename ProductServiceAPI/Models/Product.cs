using System.ComponentModel.DataAnnotations;

namespace ProductServiceAPI.Models
{
    public enum InventoryStatus
    {
        Stocked,
        Low,
        Critical,
        Back_Order
    }

    public class Product
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string CatalogNumber { get; set; }
        public string Description { get; set; }
        public decimal UnitCost { get; set; }
        public int QuantityInStock { get; set; }
        public InventoryStatus InventoryStatus { get; set; }
    }
}
