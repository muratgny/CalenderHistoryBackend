using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.Validations.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
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

        [SecuredOperation("add, admin")]//it is for to check user claim operations for this method. We chacks if the user has the ability to make this operation
        [ValidationAspect(typeof(CastoryValidator))]
        [CacheRemoveAspect("ICastoryService.Get")]//Removing just castory items from cache
        public IResult Add(Castory castory)
        {
            _castoryDal.Add(castory);

            return new SuccessResult(Messages.Added);
        }

        [CacheRemoveAspect("ICastoryService.Get")]//Removing just castory items from cache
        public IResult Delete(Castory castory)
        {
            _castoryDal.Delete(castory);

            return new SuccessResult(Messages.Deleted);
        }

        [CacheAspect]//working cache example
        public async Task<IDataResult<Castory>> GetById(int id)
        {
            var castory = await _castoryDal.GetAsync(p => p.Id == id);
            return new SuccessDataResult<Castory>(castory);
        }

        //[SecuredOperation("admin")]
        [CacheAspect]
        public async Task<IDataResult<IEnumerable<Castory>>> GetList()
        {
            var castoryList = _castoryDal.GetList();
            return new SuccessDataResult<IEnumerable<Castory>>(castoryList);
        }

        [CacheRemoveAspect("ICastoryService.Get")]//Removing just castory items from cache
        public IResult Update(Castory castory)
        {
            _castoryDal.Update(castory);

            return new SuccessResult(Messages.Updated);
        }
    }
}
