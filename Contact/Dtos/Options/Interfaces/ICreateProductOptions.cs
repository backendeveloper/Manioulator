using CommandLine;
using MediatR;

namespace Contact.Dtos.Options.Interfaces
{
    public interface ICreateProductOptions
    {
        [Value(0,
            HelpText = "Input file to be processed.",
            Required = true)]
        string ProductCode { get; set; }
        
        [Value(1,
            HelpText = "Input file to be processed.",
            Required = true)]
        int Price { get; set; }
        
        [Value(2,
            HelpText = "Input file to be processed.",
            Required = true)]
        int Stock { get; set; }
    }
}