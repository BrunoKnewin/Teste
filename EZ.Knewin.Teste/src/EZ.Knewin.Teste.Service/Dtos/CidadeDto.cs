using Newtonsoft.Json;
using System.Collections.Generic;

namespace EZ.Knewin.Teste.Service.Dtos
{
    public class CidadeDto
    {
        [JsonProperty("Id", NullValueHandling = NullValueHandling.Ignore)]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string QuantidadeDeHabitantes { get; set; }
        public int EstadoId { get; set; }
        public int[] FronteirasIds { get; set; }
    }
}
