using MaplrSugarShack.Shared;

namespace MaplrSugarShack.Server.Core.Helpers
{
    public static class OrderHelper
    {
        public static OrderValidationResponseDto GetValidation(params string[] errors)
        {
            return new OrderValidationResponseDto
            {
                Errors = errors,
                IsOrderValid = errors is null or { Length: 0 }
            };
        }
    }
}
