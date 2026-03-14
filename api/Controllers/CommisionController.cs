using Microsoft.AspNetCore.Mvc;
using AvalphaTechnologies.CommissionCalculator.DTO;
using AvalphaTechnologies.CommissionCalculator.Services;
namespace AvalphaTechnologies.CommissionCalculator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommisionController : ControllerBase
    {
        private ICommissionCalculator _commissionCalService;
        public CommisionController(ICommissionCalculator commissionCalculator)
        {
            _commissionCalService=commissionCalculator;
        }

        [ProducesResponseType(typeof(CommissionCalResponseDTO), 200)]
        [HttpPost]
        [Route("CalculateCommission")]
        public IActionResult Calculate(CommissionCalRequestDTO calculationRequest)
        {
            if (calculationRequest.LocalSalesCount < 0 || calculationRequest.ForeignSalesCount < 0 || calculationRequest.AverageSaleAmount < 0)
            {
                return BadRequest(new ErrorResponseDTO { ErrorMessage="Sales count must be >=0"});   
            }

            if (calculationRequest.LocalSalesCount > 100000 || calculationRequest.ForeignSalesCount > 100000)
            {
                return BadRequest(new ErrorResponseDTO {ErrorMessage="Sales count too large"});   
            }
            CommissionCalResponseDTO response=_commissionCalService.CalculateCommission(calculationRequest);
            return Ok(response);
        }
    }

}
