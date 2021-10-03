using System.Text.Json.Serialization;

namespace Core.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        
        public string Role { get; set; }
        
        public string Token { get; set; }

        [JsonIgnore]
        public string Password { get; set; }
    }
}