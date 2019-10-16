using Common.Responses;

namespace Contact.Response
{
    public class ProductGetResponse : BaseResponse
    {
        public string ProductCode { get; set; }
        public float Price { get; set; }
        public float ChangedPrice { get; set; }
        public int Stock { get; set; }
    }
}