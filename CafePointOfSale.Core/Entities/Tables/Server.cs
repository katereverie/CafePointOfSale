namespace CafePointOfSale.Core.Entities.Tables
{
    public class Server
    {
        public int ServerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime? TermDate { get; set; }
        public DateTime DoB { get; set; }

        public List<CafeOrder> CafeOrders { get; set; }
    }
}
