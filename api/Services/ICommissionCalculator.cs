using AvalphaTechnologies.CommissionCalculator.DTO;

namespace AvalphaTechnologies.CommissionCalculator.Services
{
    public interface ICommissionCalculator
    {
        public CommissionCalResponseDTO CalculateCommission(CommissionCalRequestDTO commissionCalRequestDTO);
    }
}