using CommandLine;
using Common.Options.Interfaces;

namespace Common.Options
{
    [Verb("get_campaign_info", HelpText = "Record changes to the repository.")]
    public class GetCampaignInfoOptions : IGetCampaignInfoOptions
    {
        public string CampaignName { get; set; }
    }
}