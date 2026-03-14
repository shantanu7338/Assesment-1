using AvalphaTechnologies.CommissionCalculator.DTO;
namespace AvalphaTechnologies.CommissionCalculator.Services.Impl
{
    public class CommissionCalService : ICommissionCalculator
    {
        public CommissionCalResponseDTO CalculateCommission(CommissionCalRequestDTO commissionCalRequestDTO)
        {
            var avalphaLocal = 0.20m * commissionCalRequestDTO.LocalSalesCount * commissionCalRequestDTO.AverageSaleAmount;
            var avalphaForeign = 0.35m * commissionCalRequestDTO.ForeignSalesCount * commissionCalRequestDTO.AverageSaleAmount;
            var avalphaTotal = avalphaLocal + avalphaForeign;

            var compLocal = 0.02m * commissionCalRequestDTO.LocalSalesCount * commissionCalRequestDTO.AverageSaleAmount;
            var compForeign = 0.0755m * commissionCalRequestDTO.ForeignSalesCount * commissionCalRequestDTO.AverageSaleAmount;
            var compTotal = compLocal + compForeign;

            var response = new CommissionCalResponseDTO
            {
                 AvalphaTechnologiesCommissionAmount=Math.Round(avalphaTotal,2),
                 CompetitorCommissionAmount=Math.Round(compTotal,2)
            };
            return response;
        }
    }
}