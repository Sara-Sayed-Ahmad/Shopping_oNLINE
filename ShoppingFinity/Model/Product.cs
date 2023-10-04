﻿using System.ComponentModel.DataAnnotations;

namespace ShoppingFinity.Model
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public string Description { get; set; }

        public int CategoryId { get; set;}
        public Category Category { get; set; }

        public float Price { get; set; }

        public float DiscountPercentage { get; set; }

        public int Quantity { get; set; }

        public bool IsAvaliable { get; set; }

        public DateTime? DiscountEndDate { get; set; }

        public int CountOrder { get; set; }

        public string Season { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public ICollection<User> Users { get; set; }

        public ICollection<Order> Orders { get; set; }

        public ICollection<Cart> Carts { get; set; }

        public List<Favorite> Favorites { get; set; }

        public List<OrderItem> OrderItems { get; set; }

        public List<CartItem> CartItems { get; set; }

        public List<Images> Images { get; set; }

        public List<SizeProduct> SizeProducts { get; set; }

        public List<ProductReview> ProductReviews { get; set; }
    }
}