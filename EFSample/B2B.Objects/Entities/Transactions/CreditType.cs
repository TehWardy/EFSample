namespace B2B.Objects.Entities.Transactions
{
    public class CreditType
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Credit> Credits { get; set; }
    }
}