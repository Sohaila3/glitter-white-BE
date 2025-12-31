using System.Collections.Generic;

namespace gLiter.Core.Models;

public class TransportRequest : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public bool IsHandled { get; set; } = false;
    public ICollection<TransportRequestImage> Images { get; set; } = new List<TransportRequestImage>();
}
