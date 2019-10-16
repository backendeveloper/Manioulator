using Common.Responses;

namespace Contact.Response
{
    public class OrderCreateResponse : BaseResponse
    {
        public int OrderId { get; set; }
        public string ProductCode { get; set; }
        public int Quantity { get; set; }
    }
}