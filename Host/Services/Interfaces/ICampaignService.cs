using Common.Options;
using Contact.Dtos.Options;

namespace Host.Services.Interfaces
{
    public interface ICampaignService
    {
        int CreateCampaign(CreateCampaignOptions request);
        int GetCampaign(GetCampaignInfoOptions request);
    }
}