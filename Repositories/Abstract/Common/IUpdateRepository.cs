using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Abstract.Common {

    public interface IUpdateRepository<T> where T : class {

        Task<bool> Update(int Id , T Entity);
    }
}