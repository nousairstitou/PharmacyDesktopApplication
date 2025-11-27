using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Abstract.Common {

    public interface IViewMapper<T> where T : class {

        T MapToView(SqlDataReader Reader);
    }
}