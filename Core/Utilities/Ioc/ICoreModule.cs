using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Ioc
{
    public interface ICoreModule
    {
        void Load(IServiceCollection services);//Aim of the structure is to make globally available some services which
                                               //we will use everywhere and every project. For ex: IHttpContextAccessor
    }
}
