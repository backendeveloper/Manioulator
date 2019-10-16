using CommandLine;
using Common.Options.Interfaces;

namespace Common.Options
{
    [Verb("create_order", HelpText = "Clone a repository into a new directory.")]
    public class CreateOrderOptions : ICreateOrderOptions
    {
        public string ProductCode { get; set; }
        public int Quantity { get; set; }
    }
}