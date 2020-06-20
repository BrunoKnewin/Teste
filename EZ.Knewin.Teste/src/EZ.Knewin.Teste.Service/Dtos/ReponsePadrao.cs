using System;
using System.Collections.Generic;
using System.Text;

namespace EZ.Knewin.Teste.Service.Dtos
{
    public class ReponsePadrao<TDto>
    {
        public int StatusCode { get; set; }
        public string Mensagem { get; set; }
        public TDto Data { get; set; }
    }
}
