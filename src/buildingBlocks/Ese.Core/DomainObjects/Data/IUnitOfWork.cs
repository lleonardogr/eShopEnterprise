using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ese.Core.DomainObjects.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
