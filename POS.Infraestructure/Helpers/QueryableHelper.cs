﻿using POS.Infraestructure.Commons.Bases.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Infraestructure.Helpers
{
    public static class QueryableHelper
    {
        public static IQueryable<T> Paginate<T>(this IQueryable<T> queryable,BasePaginationRequest paginationRequest) 
        {
            return queryable.Skip((paginationRequest.NumPage - 1) * paginationRequest.Records).Take(paginationRequest.Records);
        }
    }
}
