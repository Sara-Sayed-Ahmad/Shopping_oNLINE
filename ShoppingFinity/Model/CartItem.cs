namespace ShoppingFinity.Model
{
    public class CartItem
    {
        public int CartId { get; set; }
        public Cart Cart { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int Quantity { get; set; }
        
        public float ItemPrice { get; set; }

        public float SubTotal { get; set; }
    }
}
