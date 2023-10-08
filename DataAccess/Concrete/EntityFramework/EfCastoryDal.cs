using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCastoryDal : EfEntityRepositoryBase<Castory, CastoryDbContext>, ICastoryDal //ICastoryDal wants its methods to be here
                                                                                               //But EfEntityRepositoryBase class has all basic methods.
                                                                                               //And ICastory will include all castory-specified methods and they will be here
    {
        public EfCastoryDal(CastoryDbContext context) : base(context)
        {
        }
    }
}
