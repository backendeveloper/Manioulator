using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Common.Handlers;
using Contact.Requests;
using Contact.Response;
using Data;
using Data.Entities;

namespace Business.Handlers
{
    public class CampaignCreateRequestHandler : BaseHandler<CampaignCreateRequest, CampaignCreateResponse>
    {
        private readonly DataContext _dataContext;
        private readonly TextWriter _textWriter;

        public CampaignCreateRequestHandler(DataContext dataContext, TextWriter textWriter)
        {
            _dataContext = dataContext;
            _textWriter = textWriter;
        }

        public override Task<CampaignCreateResponse> Execute(CampaignCreateRequest request)
        {
            Campaign campaign = new Campaign
            {
                Name = request.Name,
                ProductCode = request.ProductCode,
                Duration = request.Duration,
                Limit = request.Limit,
                TargetSalesCount = request.TargetSalesCount,
                StartedDate = DateTime.Now.AddHours(request.Duration)
            };
            _dataContext.Campaigns.Add(campaign);
            _dataContext.SaveChanges();

            CampaignCreateResponse campaignCreateResponse = new CampaignCreateResponse
            {
                Name = campaign.Name,
                ProductCode = campaign.ProductCode,
                Duration = campaign.Duration,
                Limit = campaign.Limit,
                TargetSalesCount = campaign.Limit
            };
            
            _textWriter.WriteLine("Campaign created; name {0}, product {1}, duration {2}, limit {3}, target sales count {4}", campaignCreateResponse.Name, campaignCreateResponse.ProductCode, campaignCreateResponse.Duration, campaignCreateResponse.Limit, campaignCreateResponse.TargetSalesCount);
            
            return Task.FromResult(campaignCreateResponse);
        }
    }
}