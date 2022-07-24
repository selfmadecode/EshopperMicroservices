using AutoMapper;
using Discount.Grpc.Protos;
using Discount.Grpc.Repositories;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Discount.Grpc.Services
{
    // C# generated class DiscountProtoService.DiscountProtoServiceBase
    // To see this class, show all files, obj, debug, net5.0, protos folder, click on discountgrpc.cs
    public class DiscountService : DiscountProtoService.DiscountProtoServiceBase
    {
        private readonly IDiscountRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<DiscountService> _logger;

        public DiscountService(IDiscountRepository repository, ILogger<DiscountService> logger, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public override async Task<CouponModel> GetDiscount(GetDiscountRequest request, ServerCallContext context)
        {
            var coupon = await _repository.GetDiscount(request.ProductName);

            if(coupon == null)
            {
                throw new RpcException(new Status(StatusCode.NotFound, $"Discount with Product name {request.ProductName} not found."));
            }
            _logger.LogInformation($"Discount retrieved for ProductName: {coupon.ProductName}, Amount: {coupon.Amount}");

            var couponModel = _mapper.Map<CouponModel>(coupon);
            return couponModel;
        }
    }
}
