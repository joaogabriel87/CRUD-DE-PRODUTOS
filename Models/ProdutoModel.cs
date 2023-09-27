using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dev.Models
{
    public class ProdutoModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public string Tipo { get; set; }

        public string Preco { get; set; }

        public DateTime dataCadastro { get; set; } = DateTime.Now;

    }
}