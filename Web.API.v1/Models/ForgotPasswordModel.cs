using Newtonsoft.Json;

namespace Web_API_v1.Models
{
    public class ForgotPasswordModel
    {
        [JsonIgnore]
        public string Password { get; set; }
        [JsonIgnore]
        public string NewPassword { get; set; }
        [JsonIgnore]
        public string NewPasswordConfirm { get; set; }
    }
}
