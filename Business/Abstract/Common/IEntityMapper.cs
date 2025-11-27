using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract.Common {

    public interface IEntityMapper<TRequest , TEntity> {

        TEntity Map(TRequest Request);
    }
}