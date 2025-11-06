using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Abstract.Common {

    public interface IAddRepository<T> where T : class {

        Task<int?> Insert(T Entity);
    }
}