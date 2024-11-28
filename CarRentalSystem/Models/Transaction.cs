namespace CarRentalSystem.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        //put ,post ,delete
        public string Action { get; set; }
        public DateTime TimeStamp { get; set; }
        public Car car { get; set; }
    }
}
