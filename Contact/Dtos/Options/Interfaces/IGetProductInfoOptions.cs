using CommandLine;

namespace Common.Options.Interfaces
{
    public interface IGetProductInfoOptions
    {
        [Value(0,
            HelpText = "Input file to be processed.",
            Required = true)]
        string ProductCode { get; set; }
    }
}