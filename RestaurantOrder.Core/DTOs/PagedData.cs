﻿namespace RestaurantOrder.Core.DTOs
{
    public class PagedData<T>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public long TotalItems { get; set; }
        public IEnumerable<T> ItemList { get; set; }
    }
}
