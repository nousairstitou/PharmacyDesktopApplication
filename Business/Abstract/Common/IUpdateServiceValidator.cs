using Business.Validation;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract.Common {
    public interface IUpdateServiceValidator<TUpdate> {

        Task<Result<TUpdate>> ValidateUpdate(TUpdate Entity);
    }
}