﻿namespace RestaurantOrder.Data.Models
{
    public class MenuItem : ModelBase
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
