using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract.Common {

    public interface IUpdateService<T> where T : class {

        Task<bool> Update(int Id , T Entity);
    }
}