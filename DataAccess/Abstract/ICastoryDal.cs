using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICastoryDal : IEntityRepository<Castory>//We will write castory specific operations here, all basic operations
        // are in EfEntityRepositoryBase class in core layer. And we use this interface in the business layer. And also this interface
        // will be roof for all different database types. Now we are using Entity Framework only.
    {
    }
}
