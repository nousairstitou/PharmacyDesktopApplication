using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract.Common {

    public interface IAddService<T> where T : class {

        Task<int?> Add(T Entity);
    }
}