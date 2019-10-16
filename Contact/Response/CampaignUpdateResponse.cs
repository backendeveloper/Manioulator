using System;
using Common.Responses;

namespace Contact.Response
{
    public class CampaignUpdateResponse : BaseResponse
    {
        public int CampaignId { get; set; }
        public string Name { get; set; }
        public string ProductCode { get; set; }
        public int Duration { get; set; }
        public int Limit { get; set; }
        public int TargetSalesCount { get; set; }
        public DateTime CampaignEndDate { get; set; }
    }
}