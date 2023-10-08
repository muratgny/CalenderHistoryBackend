using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICastoryService
    {
        Task<IDataResult<Castory>> GetById(int id);
        Task<IDataResult<IEnumerable<Castory>>> GetList();
        IResult Add(Castory product);
        IResult Delete(Castory product);
        IResult Update(Castory product);
    }
}
