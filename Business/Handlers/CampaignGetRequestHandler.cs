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
    public class CampaignGetRequestHandler : BaseHandler<CampaignGetRequest, CampaignGetResponse>
    {
        private readonly DataContext _dataContext;
        private readonly TextWriter _textWriter;

        public CampaignGetRequestHandler(DataContext dataContext, TextWriter textWriter)
        {
            _dataContext = dataContext;
            _textWriter = textWriter;
        }

        public override Task<CampaignGetResponse> Execute(CampaignGetRequest request)
        {
            Campaign campaign = _dataContext.Campaigns.FirstOrDefault(x => x.Name == request.Name);  
            
            CampaignGetResponse campaignGetResponse = new CampaignGetResponse
            {
                CampaignId = campaign.CampaignId,
                Name = campaign.Name,
                ProductCode = campaign.ProductCode,
                Duration = campaign.Duration,
                Limit = campaign.Limit,
                TargetSalesCount = campaign.Limit,
                CampaignEndedDate = campaign.EndedDate
            };
            
            //_textWriter.WriteLine("Campaign {0} info; Status {1}, Target Sales {1}, Total Sales {2}, Turnover {3}, Average Item Price {4}", campaignCreateResponse.Name, campaignCreateResponse.ProductCode, campaignCreateResponse.Duration, campaignCreateResponse.Limit, campaignCreateResponse.TargetSalesCount);
            
            return Task.FromResult(campaignGetResponse);
        }
    }
}