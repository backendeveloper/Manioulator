using System;
using System.Linq;
using System.Threading.Tasks;
using Common.Handlers;
using Contact.Requests;
using Contact.Response;
using Data;
using Data.Entities;

namespace Business.Handlers
{
    public class CampaignUpdateRequestHandler : BaseHandler<CampaignUpdateRequest, CampaignUpdateResponse>
    {
        private readonly DataContext _dataContext;

        public CampaignUpdateRequestHandler(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public override Task<CampaignUpdateResponse> Execute(CampaignUpdateRequest request)
        {
            Campaign campaign = _dataContext.Campaigns.FirstOrDefault(x => x.CampaignId == request.CampaignId);

            campaign.IsActive = request.IsActive;

            _dataContext.Campaigns.Update(campaign);
            _dataContext.SaveChanges();

            CampaignUpdateResponse campaignUpdateResponse = new CampaignUpdateResponse
            {
                CampaignId = campaign.CampaignId,
                Name = campaign.Name,
                ProductCode = campaign.ProductCode,
                Duration = campaign.Duration,
                Limit = campaign.Limit
            };

            return Task.FromResult(campaignUpdateResponse);
        }
    }
}