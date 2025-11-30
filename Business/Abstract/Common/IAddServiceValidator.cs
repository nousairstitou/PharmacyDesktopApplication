using Business.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract.Common {

    public interface IAddServiceValidator<TCreate> {

        Task<Result<TCreate>> ValidateCreate(TCreate Entity);
    }
}