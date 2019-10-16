using Contact.Response;
using MediatR;

namespace Contact.Requests
{
    public class CampaignCreateRequest : IRequest<CampaignCreateResponse>
    {
        public string Name { get; set; }
        public string ProductCode { get; set; }
        public int Duration { get; set; }
        public int Limit { get; set; }
        public int TargetSalesCount { get; set; }
    }
}