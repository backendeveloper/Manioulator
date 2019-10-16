using CommandLine;
using Common.Options.Interfaces;
using Contact.Dtos.Options.Interfaces;
using Contact.Response;
using MediatR;

namespace Common.Options
{
    [Verb("create_product", HelpText = "Add file contents to the index.")]
    public class CreateProductOptions : ICreateProductOptions
    {
        public string ProductCode { get; set; }
        public int Price { get; set; }
        public int Stock { get; set; }
    }
}