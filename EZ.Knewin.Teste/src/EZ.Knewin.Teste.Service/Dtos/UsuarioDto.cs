using Newtonsoft.Json;

namespace EZ.Knewin.Teste.Service.Dtos
{
    public class UsuarioDto
    {
        public string Username { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
        [JsonProperty("Mensagem", NullValueHandling = NullValueHandling.Ignore)]
        public string Mensagem { get; set; }
    }
}
