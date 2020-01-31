using API_Contatos2.Models;
using System.Collections.Generic;
using System.Linq;

namespace API_Contatos2.Repositories
{
    public class ContatoRepository  : IRepository<Contato>
    {
        private readonly Contexto _contexto;

        public ContatoRepository(Contexto contexto)
        {
            _contexto = contexto;
        }

        public IList<Contato> GetAll()
        {
            IList<Contato> resultado = Carga();
            //if (pageAndSize == null) return resultado.Take(10).ToList();
            //var page = pageAndSize.Page;
            //var size = pageAndSize.Size == 0 ? 10 : pageAndSize.Size;
            //return resultado.Skip((page - 1) * size).Take(pageAndSize.Size).ToList();
            return resultado;
        }

        public Contato Get(int id)
        {
            Contato resultado = Carga().FirstOrDefault(x => x.Id == id);
            return resultado;
        }

        public void Add(Contato contato)
        {
            _contexto.Contatos.Add(contato);
        }

        public void Update(Contato contato, int id)
        {
            var objeto = Get(id);

            if (objeto == null) return;
            objeto.Nome  = contato.Nome;
            objeto.Canal = contato.Canal;
            objeto.Valor = objeto.Valor;
            objeto.Obs   = objeto?.Obs;
            _contexto.SaveChanges();
        }

        public void Delete(int id)
        {
            var objeto = Get(id);
            if (objeto == null) return;
            _contexto.Contatos.Remove(objeto);
            _contexto.SaveChanges();
        }

        public List<Contato> Carga()
        {
            List<Contato> resultado = new List<Contato>();
            Contato item;
            for (int i = 1; i <= 10; i++)
            {
                item = new Contato();
                item.Id = i;
                item.Nome = "CONTATO " + i.ToString();
                item.Canal = "E-mail";
                item.Valor = "email@email.com.br";
                item.Obs = "Isto é só um teste - " + i.ToString() + ".";
                resultado.Add(item);
            }
            return resultado;
        }
    }
}