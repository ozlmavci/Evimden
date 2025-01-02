using Evimden.CoreLayer.Abstract;
using Evimden.CoreLayer.Concrete.ProductEntities;

namespace Evimden.CoreLayer.Concrete.OrderEntities
{
    public class ProductCart : IEntity
    {
        public Guid ProductCartId { get; set; }
        public Guid CartId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }

        public Product Product { get; set; }
        public Cart Cart { get; set; }
    }   
}
