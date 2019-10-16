using System;
using Common.Options;
using Contact.Dtos.Options;
using Contact.Requests;
using Contact.Response;
using Hangfire;
using Host.Services.Interfaces;
using MediatR;

namespace Host.Services
{
    public class CampaignService : ICampaignService
    {
        private static IMediator _mediator;

        public CampaignService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public int CreateCampaign(CreateCampaignOptions request)
        {
            CampaignCreateRequest campaignCreateRequest = new CampaignCreateRequest
            {
                Name = request.CampaignName,
                ProductCode = request.ProductCode,
                Duration = request.Duration,
                Limit = request.Duration,
                TargetSalesCount = request.TargetSalesCount
            };
            CampaignCreateResponse campaignCreateResponse = _mediator.Send(campaignCreateRequest).Result;
            RecurringJob.AddOrUpdate(() => OrderProcess(campaignCreateResponse), Cron.Minutely);
            RecurringJob.AddOrUpdate(() => IncreasingSalesProcess(campaignCreateResponse), Cron.Minutely);
            
            return 1;
        }

        public int GetCampaign(GetCampaignInfoOptions request)
        {
            CampaignGetRequest campaignGetRequest = new CampaignGetRequest
            {
                Name = request.CampaignName
            };
            _mediator.Send(campaignGetRequest);
            
            return 1;
        }
        
        private void IncreasingSalesProcess(CampaignCreateResponse campaignCreateResponse)
        {
            bool isCampaignEnd = CampaignCheckDate(campaignCreateResponse);
            if (isCampaignEnd)
                return;
            
            CampaignGetRequest campaignGetRequest = new CampaignGetRequest
            {
                CampaignId = campaignCreateResponse.CampaignId
            };
            CampaignGetResponse campaignGetResponse = _mediator.Send(campaignGetRequest).Result;
            
            ProductGetResponse productGetResponse = GetCampaignProduct(campaignGetResponse.ProductCode);

            DateTime currentDateTime = new DateTime();
            int totalCampaignTime = campaignGetResponse.CampaignEndedDate.Subtract(campaignGetResponse.CampaignStartedDate).Hours;
            int campaignDurationTime = currentDateTime.Subtract(campaignGetResponse.CampaignStartedDate).Hours;
            float minPrice = productGetResponse.Price - productGetResponse.Price * campaignGetResponse.Limit / 100;
            float maxPrice = productGetResponse.Price + productGetResponse.Price * campaignGetResponse.Limit / 100;
            
//            if (campaignDurationTime < totalCampaignTime/2)
//            {
//                // Zaman Cok
//                if (campaignGetResponse.TargetSalesCount/2 > campaignGetResponse.TotalSalesCount)
//                {
//                    // Target Daha Cok
//                    if (campaignGetResponse.Turnover / productGetResponse.Stock > campaignGetResponse.AverageItemPrice)
//                    {
//                        // AverageSalesPrice Cok
//                        productGetResponse.ChangedPrice = productGetResponse.Price + (campaignGetResponse.Limit * 0.10f);
//                        if (Enumerable.Range((int) minPrice, (int) maxPrice).Contains(productGetResponse.ChangedPrice))
//                        {
//                            ProductUpdateRequest productUpdateRequest = new ProductUpdateRequest
//                            {
//                                Price = price,
//                                ChangeStockCount = randomQuantity,
//                                ProductCode = changingProduct.ProductCode
//                            };
//                            _mediator.Send(productUpdateRequest);
//                        }
//                        
//                    }
//                    else
//                    {
//                        // AverageSalesPrice Az
//                    }
//                    
//                    
//                }
//                else
//                {
//                    // Target Az
//                    if (campaignGetResponse.Turnover / productGetResponse.Stock > campaignGetResponse.AverageItemPrice)
//                    {
//                        // AverageSalesPrice Cok
//                    }
//                    else
//                    {
//                        // AverageSalesPrice Az
//                    }
//                }
//            }
//            else
//            {
//                // Zaman Az
//                if (campaignGetResponse.TargetSalesCount / 2 > campaignGetResponse.TotalSalesCount)
//                {
//                    // Target Daha Cok
//                    if (campaignGetResponse.Turnover / productGetResponse.Stock > campaignGetResponse.AverageItemPrice)
//                    {
//                        // AverageSalesPrice Cok
//                    }
//                    else
//                    {
//                        // AverageSalesPrice Az
//                    }
//                }
//                else
//                {
//                    // Target Az
//                    if (campaignGetResponse.Turnover / productGetResponse.Stock > campaignGetResponse.AverageItemPrice)
//                    {
//                        // AverageSalesPrice Cok
//                    }
//                    else
//                    {
//                        // AverageSalesPrice Az
//                    }
//                }
//            }
        }

        private void OrderProcess(CampaignCreateResponse campaignCreateResponse)
        {
            bool isCampaignEnd = CampaignCheckDate(campaignCreateResponse);
            if (isCampaignEnd)
                return;

            ProductGetResponse productGetResponse = GetCampaignProduct(campaignCreateResponse.ProductCode);

            Random rnd = new Random();
            int randomQuantity = rnd.Next(10);
            
            CreateRandomOrderGenerator(randomQuantity, campaignCreateResponse.ProductCode, productGetResponse.Price);
            ProductChangeStockCount(randomQuantity, productGetResponse);
        }

        private void ProductChangeStockCount(int randomQuantity, ProductGetResponse changingProduct)
        {
            ProductUpdateRequest productUpdateRequest = new ProductUpdateRequest
            {
                Price = changingProduct.Price,
                ChangeStockCount = randomQuantity,
                ProductCode = changingProduct.ProductCode
            };
            _mediator.Send(productUpdateRequest);
        }

        private void CreateRandomOrderGenerator(int randomQuantity, string CampaignProductCode, float productCurrentPrice)
        {
            OrderCreateRequest orderCreateRequest = new OrderCreateRequest
            {
                ProductCode = CampaignProductCode,
                Quantity = randomQuantity,
                Price = productCurrentPrice
            };
            _mediator.Send(orderCreateRequest);
        }

        private ProductGetResponse GetCampaignProduct(string productCode)
        {
            ProductGetRequest productGetRequest = new ProductGetRequest
            {
                ProductCode = productCode
            };
            
            return _mediator.Send(productGetRequest).Result;
        }

        private bool CampaignCheckDate(CampaignCreateResponse campaignCreateResponse)
        {
            CampaignGetRequest campaignGetRequest = new CampaignGetRequest
            {
                CampaignId = campaignCreateResponse.CampaignId
            };
            CampaignGetResponse campaignGetResponse = _mediator.Send(campaignGetRequest).Result;

            if (campaignGetResponse.CampaignEndedDate != DateTime.Now) return true;
            CampaignUpdateRequest campaignUpdateRequest = new CampaignUpdateRequest
            {
                CampaignId = campaignGetResponse.CampaignId,
                IsActive = false
            };
            _mediator.Send(campaignUpdateRequest);
                
            return false;
        }
    }
}