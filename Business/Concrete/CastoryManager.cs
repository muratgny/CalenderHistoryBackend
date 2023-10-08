using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CastoryManager : ICastoryService //We are not inheriting from IEntitiyRepository<Castory> because in further times
                                                  //Data access layer and business layer works can be complicated. This is business layer and we need to keep things seperated.
    {
        public ICastoryDal _castoryDal;

        public CastoryManager(ICastoryDal castoryDal) 
        {
            _castoryDal = castoryDal;
        }
        public IResult Add(Castory castory)
        {
            _castoryDal.Add(castory);

            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Castory castory)
        {
            _castoryDal.Delete(castory);

            return new SuccessResult(Messages.Deleted);
        }

        public async Task<IDataResult<Castory>> GetById(int id)
        {
            var castory = await _castoryDal.GetAsync(p => p.Id == id);
            return new SuccessDataResult<Castory>(castory);
        }

        public async Task<IDataResult<IEnumerable<Castory>>> GetList()
        {
            var castoryList = await _castoryDal.GetListAsync();
            return new SuccessDataResult<IEnumerable<Castory>>(castoryList);
        }

        public IResult Update(Castory castory)
        {
            _castoryDal.Update(castory);

            return new SuccessResult(Messages.Updated);
        }
    }
}
