using CommandLine;

namespace Common.Options.Interfaces
{
    public interface IIncreaseTimeOptions
    {
        [Value(0,
            HelpText = "Input file to be processed.",
            Required = true)]
        int Hour { get; set; }
    }
}