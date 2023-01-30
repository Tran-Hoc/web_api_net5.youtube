﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace API_net5.Model
{
    public class PaginatedList<T> : List<T>
    {
        public int PageIndex { get; set; }
        public int TotalPage { get; set; }

        public PaginatedList(List<T> items, int count, int pageindex, int pageSize)
        {
            PageIndex= pageindex;
            TotalPage= (int) Math.Ceiling(Count/(double)pageSize);
            AddRange(items);
        }

        public static PaginatedList<T> Create(IQueryable<T> source, int pageIndex, int pageSize)
        {
            var count = source.Count();
            var items = source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
                
            return new PaginatedList<T>(items, count, pageIndex, pageSize);
        }
    }
}
