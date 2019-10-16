using CommandLine;

namespace Common.Options.Interfaces
{
    public interface ICreateOrderOptions
    {
        [Value(0,
            HelpText = "Input file to be processed.",
            Required = true)]
        string ProductCode { get; set; }
        
        [Value(1,
            HelpText = "Input file to be processed.",
            Required = true)]
        int Quantity { get; set; }
    }
}