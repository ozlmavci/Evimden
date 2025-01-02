namespace Evimden.CoreLayer.DTOs.OrderDTOs
{
    public class CartDto : BaseDto
    {
        public Guid CartId { get; set; }
        public Guid UserId { get; set; }
        public decimal SubTotal { get; set; }
    }
}
