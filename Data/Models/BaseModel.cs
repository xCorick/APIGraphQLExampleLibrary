using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Data.Models
{
    public class BaseModel
    {
        [JsonPropertyName("id")]
        public virtual Guid Id { get; set; }
        [JsonPropertyName("created_at")]
        public DateTime? Created_At { get; set; }
        [JsonPropertyName ("updated_at")]
        public DateTime? Updated_At { get; set; }
        [JsonPropertyName("is_active")]
        public bool Is_Active { get; set; }
    }
}
