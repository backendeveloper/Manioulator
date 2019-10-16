using Common.Responses;

namespace Contact.Response
{
    public class ProductCreateResponse : BaseResponse
    {
        public string ProductCode { get; set; }
        public int Price { get; set; }
        public int Stock { get; set; }
    }
}