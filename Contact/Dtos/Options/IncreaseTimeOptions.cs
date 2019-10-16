using CommandLine;
using Common.Options.Interfaces;

namespace Common.Options
{
    [Verb("increase_time", HelpText = "Record changes to the repository.")]
    public class IncreaseTimeOptions : IIncreaseTimeOptions
    {
        public int Hour { get; set; }
    }
}