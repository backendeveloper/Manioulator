using System;
using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class Campaign
    {
        [Key]
        public int CampaignId { get; set; }

        [Required]
        public string Name { get; set; }
        
        [Required]
        public string ProductCode { get; set; }

        [Required]
        public int Duration { get; set; }
        
        [Required]
        public int Limit { get; set; }
        
        [Required]
        public DateTime StartedDate { get; set; }
        
        public DateTime EndedDate { get; set; }
        
        [Required]
        public int TargetSalesCount { get; set; }
        
        public int TotalSalesCount { get; set; }
        
        public float AverageItemPrice { get; set; }

        public float Turnover { get; set; }

        public bool IsActive { get; set; }
    }
}