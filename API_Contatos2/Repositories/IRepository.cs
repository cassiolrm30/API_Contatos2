using API_Contatos2.Models;
using System.Collections.Generic;

namespace API_Contatos2.Repositories
{
    public interface IRepository<T> where T : class
    {
        IList<T> GetAll(int page, int size);
        T Get(int id);
        void Add(T objeto);
        void Update(T objeto, int id);
        void Delete(int Id);
    }
}
