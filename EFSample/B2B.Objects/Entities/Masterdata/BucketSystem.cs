namespace B2B.Objects.Entities.Masterdata
{
    public class BucketSystem
    {
        public Guid BucketId { get; set; }

        public virtual Bucket Bucket { get; set; }

        public string SystemId { get; set; }

        public virtual System System { get; set; }
    }
}