using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IFollowerService
    {
        Task<IDataResult<Follower>> GetById(int id);
        Task<IDataResult<IEnumerable<Follower>>> GetList();
        IResult Add(Follower follower);
        IResult Delete(Follower follower);
        IResult Update(Follower follower);
    }
}
