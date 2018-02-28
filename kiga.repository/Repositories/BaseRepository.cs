using System;
using System.Collections.Generic;
using System.Linq;
using kiga.domain.Contracts;
using kiga.repository.Context;
using Microsoft.EntityFrameworkCore;

namespace kiga.repository.Repositories{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly kigaContexto _dbContext;

        public int Atualizar(T dados)
        {
            try{
                _dbContext.Set<T>().Update(dados);
                return _dbContext.SaveChanges();
            }
            catch(System.Exception ex){
                throw new Exception (ex.Message);
            }
        }

        public T BuscaPorId(int id)
        {
            try{
                var chamePrimaria = _dbContext.Model.FindEntityType(typeof(T)).FindPrimaryKey().Properties[0];
                return _dbContext.Set<T>().FirstOrDefault(e => EF.Property <int> (e,chamePrimaria.Name) == id);
            }
            catch(System.Exception ex){
                throw new Exception (ex.Message);
            }
        }

        public int Deletar(T dados)
        {
            try{
                _dbContext.Set<T>().Remove(dados);
                return _dbContext.SaveChanges();
            }
            catch(System.Exception ex){
                throw new Exception (ex.Message);
            }
        }

        public int Inserir(T dados)
        {
            try{
                _dbContext.Set<T>().Add(dados);
                return _dbContext.SaveChanges();
            }
            catch(System.Exception ex){
                throw new Exception (ex.Message);
            }
        }

        public IEnumerable<T> Listar()
        {
            try{
                return _dbContext.Set<T>().ToList();
            }
            catch(System.Exception ex){
                throw new Exception (ex.Message);
            }
        }
    }
}