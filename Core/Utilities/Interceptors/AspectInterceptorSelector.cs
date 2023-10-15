using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Interceptors
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>
                (true).ToList();//Get class attributes

            var methodAttributes = type.GetMethod(method.Name)
                .GetCustomAttributes<MethodInterceptionBaseAttribute>(true);//Get method attributes

            classAttributes.AddRange(methodAttributes); //add method attributes to class attributes.

            //alttaki satır tüm projeye loglama eklemek içindir. loglama sistemi hazırlandıktan sonra, bu satırı buraya koyarak 
            //tüm sistemdeki tüm metodlar loglanabilir.
            //classAttributes.Add(new ExceptionLogAspect(typeof(FileLogger))); deaktive ettik log sistemi yapmadığımız için

            return classAttributes.OrderBy(x => x.Priority).ToArray(); //return in order by priority
        }
    }
}
