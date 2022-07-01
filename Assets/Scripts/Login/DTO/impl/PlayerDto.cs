using System;
using Newtonsoft.Json;

namespace Login.DTO.impl
{
    [Serializable]
    public class PlayerDto : IPlayerDto
    {
        [JsonProperty("id", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string ID { get; set; }
        [JsonProperty("name", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }
        [JsonProperty("wins", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int Wins { get; set; }
        
        public PlayerDto() { }

        public PlayerDto(string id, string name, int wins)
        {
            ID = id;
            Name = name;
            Wins = wins;
        }

        public string GetNamePlayerDto()
        {
            return Name;
        }
    }
}