using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inbox.Service.API.DAL.Interfaces
{
    public interface INoteRepository<T>
    {

        public Task<T> Create(T _object);

        public IEnumerable<T> GetAll();

        public T GetById(int Id);

        public void Delete(T _object);
    }

}
