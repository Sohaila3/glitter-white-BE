namespace gLiter.Core.Models;

public class TransportRequestImage : BaseEntity
{
    public string ImageUrl { get; set; } = string.Empty;
    public int TransportRequestId { get; set; }
    public TransportRequest TransportRequest { get; set; } = null!;
}
