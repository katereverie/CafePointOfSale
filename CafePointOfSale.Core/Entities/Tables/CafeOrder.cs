using System.ComponentModel.DataAnnotations;

namespace CafePointOfSale.Core.Entities.Tables
{
    public class CafeOrder
    {
        [Key]
        public int OrderID { get; set; }
        public required int ServerID { get; set; }
        public int? PaymentTypeID { get; set; }
        public DateTime? OrderDate { get; set; }
        public decimal? SubTotal { get; set; }
        public decimal? Tax { get; set; }
        public decimal? Tip { get; set; }
        public decimal? AmountDue { get; set; }

        public required Server Server { get; set; }
        public required List<OrderItem> OrderItems { get; set; }
    }
}
