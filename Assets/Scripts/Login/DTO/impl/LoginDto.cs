using Newtonsoft.Json;

namespace Login.DTO.impl
{
    public class LoginDto : ILoginDto
    {
        [JsonProperty("nickname", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string nickname { get; set; }
        [JsonProperty("id", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        private string id;
        [JsonProperty("wins", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        private string wins;
    }
}