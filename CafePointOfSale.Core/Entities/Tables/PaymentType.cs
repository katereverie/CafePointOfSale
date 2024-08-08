namespace CafePointOfSale.Core.Entities.Tables
{
    public class PaymentType
    {
        public int? PaymentTypeID { get; set; }
        public string PaymentTypeName { get; set; }

        public List<CafeOrder> CafeOrders { get; set; }
    }
}
