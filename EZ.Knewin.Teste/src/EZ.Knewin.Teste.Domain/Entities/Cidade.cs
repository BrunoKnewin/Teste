using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EZ.Knewin.Teste.Domain.Entities
{
    public class Cidade : Entity<int>
    {
        [Required(ErrorMessage = "Nome é obrigatório!")]
        [MaxLength(150, ErrorMessage = "Deve conter no máximo 150 caracteres!")]
        [MinLength(3, ErrorMessage = "Deve conter no mínimo 3 caracteres!")]
        public string Nome { get; private set; }

        public string FronteirasIds { get; private set; }
        //public virtual ICollection<Cidade> Fronteiras { get; set; } = new List<Cidade>();
        
        [Required(ErrorMessage = "Quantidade de Habitantes é obrigatório!")]
        public int QuantidadeDeHabitantes { get; private set; }
        
        [Required(ErrorMessage = "Estado é obrigatório!")]
        public int EstadoId { get; private set; }
        public virtual Estado Estado { get; set; }
        
        public DateTime DataDeCadastro { get; private set; }
        public DateTime? DateDeAtualizacao { get; private set; }

        protected Cidade() { }

        public Cidade(string nome, int quantidadeDeHabitantes, string fronteirasIds)
        {
            Nome = nome;
            FronteirasIds = fronteirasIds;
            QuantidadeDeHabitantes = quantidadeDeHabitantes;
        }

        public void AlterarEstadoId(int estadoId)
        {
            this.EstadoId = estadoId;
        }

        public void AlterarEstado(Estado estado)
        {
            this.Estado = estado;
        }

        public void AlterarQuantidadeDeHabitantes(int quantidadeDeHabitantes)
        {
            this.QuantidadeDeHabitantes = quantidadeDeHabitantes;
        }

        public void AlterarFronteiras(string fronteirasIds)
        {
            this.FronteirasIds = fronteirasIds;
        }


    }
}
