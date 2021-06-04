using DataModel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WarehouseTestAPI.Common
{
    public interface IQuerySpecification<T> where T : BaseEntity
    {
        IQueryable<T> Apply(IQueryable<T> query);
    }
}
