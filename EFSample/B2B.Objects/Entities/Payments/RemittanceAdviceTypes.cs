namespace B2B.Objects.Entities.Payments
{
    public class RemittanceAdviceType
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<RemittanceAdvice> RemittanceAdvices { get; set; }
    }
}