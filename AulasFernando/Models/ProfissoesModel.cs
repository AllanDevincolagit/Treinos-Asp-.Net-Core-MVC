using AulasFernando.Entidades;
using System.Collections.Generic;

namespace AulasFernando.Models
{
    public class ProfissoesModel : Profissoes
    {
        public List<Formacao> ListaFormacoes { get; set; }
    }
}
