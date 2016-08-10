using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.Repository.Interface
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork CreateUnitOfWork();
    }
}
