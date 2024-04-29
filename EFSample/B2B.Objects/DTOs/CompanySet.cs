using B2B.Objects.Entities.Masterdata;

namespace B2B.Objects.DTOs
{
    public class CompanySet
    {
        public IEnumerable<Company> Buyers { get; set; }
        public IEnumerable<Company> Suppliers { get; set; }
        public IEnumerable<Company> Funders { get; set; }

        public Guid BuyerGroupBucketId { get; set; }
        public Guid SupplierGroupBucketId { get; set; }
        public Guid FunderGroupBucketId { get; set; }

        public string[] Files { get; set; }

        public Guid TransformInstance { get; set; }
        public Guid ImportInstance { get; set; }

        public string ReportApi { get; set; }
        public string ReportDMSPath { get; set; }
    }
}
