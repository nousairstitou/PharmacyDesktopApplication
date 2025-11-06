using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Abstract.Common {

    public interface IBaseRepository<T> where T : class , IAddRepository<T> , IUpdateRepository<T> , IDeleteRepository<T> {

        protected async Task<IEnumerable<T>> GetAll() { return null; }

        protected abstract Task<T?> GetObjectById(int? Id);

        protected virtual async Task<T?> GetObjectByName(string Name) { return null;}

        protected virtual async Task<int?> Insert(T Entity) { return null; }
                  
        protected virtual async Task<bool> Update(int Id , T Entity) { return true; }

        protected virtual async Task<bool> Delete(int Id) { return true; }
    }
}