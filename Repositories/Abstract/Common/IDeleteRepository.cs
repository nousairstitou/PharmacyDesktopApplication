using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Abstract.Common {

    public interface IDeleteRepository<T> where T : class {

        Task<bool> Delete(int Id);
    }
}