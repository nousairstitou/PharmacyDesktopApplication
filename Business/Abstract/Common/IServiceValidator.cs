using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract.Common {

    public interface IServiceValidator<TCreate, TUpdate> {

        Task ValidateCreate(TCreate Entity);
        Task ValidateUpdate(TUpdate Entity);
        Task ValidateDelete(int Id);
    }
}