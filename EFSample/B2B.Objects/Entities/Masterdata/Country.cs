namespace B2B.Objects.Entities.Masterdata
{
    public class Country
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public bool InEuropeanUnion { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
    }
}