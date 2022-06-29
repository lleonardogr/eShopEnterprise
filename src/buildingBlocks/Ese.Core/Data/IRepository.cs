using Ese.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ese.Core.Data
{
    public interface IRepository<T> : IDisposable where T : Entity, IAggregateRoot
    {

    }
}
