namespace Ebanx.Domain
{
    public class Account
    {
        public string Id { get; set; }
        public double Balance { get; set; }

        public Account(string id)
        {
            this.Id = id;
            this.Balance = 0;
        }
    }
}
