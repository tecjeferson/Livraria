using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Livraria.Model
{
    public class Livro
    {
        public long? Id { get; set; }
        public long Isbn { get; set; }
        public string Autor { get; set; }
        public string Nome { get; set; }
        public Decimal Preco { get; set; }
        public DateTime DataPublicacao { get; set; }
        public string ImagemUrl { get; set; }
        public string ImgThumbnailUrl { get; set; }


    }
}
