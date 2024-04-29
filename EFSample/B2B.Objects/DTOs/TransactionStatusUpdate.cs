using System.ComponentModel.DataAnnotations;

namespace B2B.Api.Controllers.Funding;

public class TransactionStatusUpdate
{
    [Required]
    public string Reference { get; set; }
    public string Comment { get; set; }
    public string ExternalStateString { get; set; }

    [Required]
    public int NewState { get; set; }
}