using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract.Common {

    public interface IEntityToResponseMapper<TResponse , TEntity> {

        TResponse Map(TEntity entity);
    }
}