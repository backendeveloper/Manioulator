using Contact.Response;
using MediatR;

namespace Contact.Requests
{
    public class CampaignGetRequest : IRequest<CampaignGetResponse>
    {
        public int CampaignId { get; set; }
        public string Name { get; set; }
    }
}