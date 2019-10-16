using Common.Responses;

namespace Contact.Response
{
    public class ProductUpdateResponse : BaseResponse
    {
        public string ProductCode { get; set; }
        public float Price { get; set; }
        public int Stock { get; set; }
    }
}