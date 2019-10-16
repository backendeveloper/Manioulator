using Contact.Response;
using MediatR;

namespace Contact.Requests
{
    public class CampaignUpdateRequest : IRequest<CampaignUpdateResponse>
    {
        public int CampaignId { get; set; }
        public bool IsActive { get; set; }
    }
}