using Evimden.CoreLayer.Abstract;

namespace Evimden.CoreLayer.DTOs.OrderDTOs
{
    public class ProductCartDto : IDtoModel
    {
        public Guid ProductCartId { get; set; }
        public Guid CartId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
