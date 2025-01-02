using Evimden.CoreLayer.DTOs.ProfileDTOs;

namespace Evimden.UI.Web.Models.VMs.SellerVMs
{
    public class ResponseToSellerRequestVM
    {
        public SellerApprovalDto Dto { get; set; }
        public SellerDto SellerInfo { get; set; }
        public bool Response { get; set; }
    }
}
