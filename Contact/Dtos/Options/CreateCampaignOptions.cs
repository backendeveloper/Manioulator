using CommandLine;
using Common.Options.Interfaces;
using Contact.Response;
using MediatR;

namespace Contact.Dtos.Options
{
    [Verb("create_campaign", HelpText = "Clone a repository into a new directory.")]
    public class CreateCampaignOptions : ICreateCampaignOptions
    {
        public string CampaignName { get; set; }
        public string ProductCode { get; set; }
        public int Duration { get; set; }
        public int PMLimit { get; set; }
        public int TargetSalesCount { get; set; }
    }
}