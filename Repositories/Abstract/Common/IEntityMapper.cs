using Azure.Core;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Abstract.Common {

    public interface IEntityMapper<T> {

        T Map(SqlDataReader Reader);
    }
}