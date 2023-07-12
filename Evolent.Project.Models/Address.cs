
using System.Text.Json.Serialization;

namespace Evolent.Project.Models
{
    public class Address : ModelBase
    {
        public string Line1 { get; set; } = default!;
        public string Line2 { get; set; } = default!;
        public string City { get; set; } = default!;
        public string State { get; set; } = default!;
        public string PostalCode { get; set; } = default!;

        [JsonIgnore]
        public Employee Employee { get; set; } = default!;
    }
}
