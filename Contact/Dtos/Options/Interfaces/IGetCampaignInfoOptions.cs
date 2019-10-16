using CommandLine;

namespace Common.Options.Interfaces
{
    public interface IGetCampaignInfoOptions
    {
        [Value(0,
            HelpText = "Input file to be processed.",
            Required = true)]
        string CampaignName { get; set; }
    }
}