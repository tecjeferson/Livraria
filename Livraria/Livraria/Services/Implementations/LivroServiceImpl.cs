using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Livraria.Model;
using Livraria.Model.Context;

namespace Livraria.Services.Implementations
{
    public class LivroServiceImpl : ILivroService
    {
        private MySQLContext _context;
        public LivroServiceImpl(MySQLContext context)
        {
            _context = context;
        }
    

        public Livro Create(Livro livro)
        {
            try
            {
                _context.Add(livro);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return livro;
        }

        public void Delete(long id)
        {
            var result = _context.Livros.SingleOrDefault(p => p.Id.Equals(id));
            try
            {
                if(result != null) _context.Livros.Remove(result);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Livro> FindAll()
        {
            return _context.Livros.ToList();
        }


        public Livro FindById(long id)
        {
            return _context.Livros.SingleOrDefault(p => p.Id.Equals(id));
        }

        public Livro Update(Livro livro)
        {
            if (!Exist(livro.Id)) return new Livro();

            var result = _context.Livros.SingleOrDefault(p => p.Id.Equals(livro.Id));
            try
            {
                _context.Entry(result).CurrentValues.SetValues(livro);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return livro;
        }

        private bool Exist(long? id)
        {
            return _context.Livros.Any(p => p.Id.Equals(id));
        }
    }
}
