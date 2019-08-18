﻿using Livraria.Model;
using System.Collections.Generic;


namespace Livraria.Services
{
    public interface ILivroService
    {
        Livro Create(Livro livros);
        Livro FindById(long id);
        List<Livro> FindAll();
        Livro Update(Livro livros);
        void Delete(long id);

    }
}
