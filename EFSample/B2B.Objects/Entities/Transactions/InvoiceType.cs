namespace B2B.Objects.Entities.Transactions
{
    public class InvoiceType
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}