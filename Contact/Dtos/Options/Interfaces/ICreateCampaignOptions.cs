using CommandLine;
using MediatR;

namespace Common.Options.Interfaces
{
    public interface ICreateCampaignOptions
    {
        [Value(0,
            HelpText = "Input file to be processed.",
            Required = true)]
        string CampaignName { get; set; }
		
        [Value(1,
            HelpText = "Input file to be processed.",
            Required = true)]
        string ProductCode { get; set; }
        
        [Value(2,
            HelpText = "Input file to be processed.",
            Required = true)]
        int Duration { get; set; }
		
        [Value(3,
            HelpText = "Input file to be processed.",
            Required = true)]
        int PMLimit { get; set; }
		
        [Value(4,
            HelpText = "Input file to be processed.",
            Required = true)]
        int TargetSalesCount { get; set; }
    }
}