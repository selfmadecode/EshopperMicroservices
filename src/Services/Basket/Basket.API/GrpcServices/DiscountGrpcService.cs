using Discount.Grpc.Protos;
using System;
using System.Threading.Tasks;

namespace Basket.API.GrpcServices
{
    // C# generated class DiscountProtoService.DiscountProtoServiceClient
    // we did not inherit this class like we did in discount grpc because it is not a server class
    // To see this class, show all files, obj, debug, net5.0, protos folder, click on discountgrpc.cs
    // Was created after connecting to the proto file in discount and setting as client
    public class DiscountGrpcService
    {
        private readonly DiscountProtoService.DiscountProtoServiceClient _discountProtoServiceClient;

        public DiscountGrpcService(DiscountProtoService.DiscountProtoServiceClient discountProtoServiceClient)
        {
            _discountProtoServiceClient = discountProtoServiceClient ?? throw new ArgumentNullException(nameof(discountProtoServiceClient));
        }

        public async Task<CouponModel> GetDiscount(string productName)
        {
            var getDiscountRequest = new GetDiscountRequest { ProductName = productName };

            return await _discountProtoServiceClient.GetDiscountAsync(getDiscountRequest);
        }
    }
}
