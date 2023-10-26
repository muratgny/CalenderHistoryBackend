using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class FollowerManager : IFollowerService
    {
        public IFollowerDal _followerDal;

        public FollowerManager(IFollowerDal folowerDal)
        {
            _followerDal = folowerDal;
        }

        public IResult Add(Follower follower)
        {
            _followerDal.Add(follower);

            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Follower follower)
        {
            _followerDal.Delete(follower);

            return new SuccessResult(Messages.Deleted);
        }

        public Task<IDataResult<Follower>> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<IEnumerable<Follower>>> GetList()
        {
            throw new NotImplementedException();
        }

        public IResult Update(Follower follower)
        {
            throw new NotImplementedException();
        }

        //TODO - We will add new operations here to handle follower actions. We setup only basics
    }
}
