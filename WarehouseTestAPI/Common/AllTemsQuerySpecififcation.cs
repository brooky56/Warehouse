using DataModel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WarehouseTestAPI.Common
{
    public class AllTemsQuerySpecification<T> : IQuerySpecification<T> where T : BaseEntity
    {
        public int? Top { get; set; }

        public bool? DescOrder { get; set; }

        public IQueryable<T> Apply(IQueryable<T> query)
        {
            if (DescOrder != null)
            {
                query = (bool)DescOrder
                    ? query.OrderByDescending(p => p.CreatedOn)
                    : query.OrderBy(p => p.CreatedOn);
            }

            if (Top != null)
            {
                query = query.Take((int)(Top > 0 ? Top : 100));
            }
            return query;
        }
    }
}
