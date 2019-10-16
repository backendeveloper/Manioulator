using CommandLine;
using Common.Options.Interfaces;

namespace Common.Options
{
    [Verb("get_product_info", HelpText = "Record changes to the repository.")]
    public class GetProductInfoOptions : IGetProductInfoOptions
    {
        public string ProductCode { get; set; }
    }
}