using AvalphaTechnologies.CommissionCalculator.Services.Impl;
using AvalphaTechnologies.CommissionCalculator.DTO;
using Xunit;

namespace CommissionCalculator.Tests;
public class CommissionCalculatorServiceTests
{
    private readonly CommissionCalService _service;

    public CommissionCalculatorServiceTests()
    {
        _service = new CommissionCalService();
    }

    [Fact]
    public void CalculateCommission_ValidInput_ReturnsCommission()
    {
        var request = new CommissionCalRequestDTO
        {
            LocalSalesCount = 10,
            ForeignSalesCount = 5,
            AverageSaleAmount = 1000
        };

        var result = _service.CalculateCommission(request);

        Assert.NotNull(result);
        Assert.True(result.AvalphaTechnologiesCommissionAmount > 0);
        Assert.True(result.CompetitorCommissionAmount > 0);
    }

    [Fact]
    public void CalculateCommission_ZeroSales_ReturnsZero()
    {
        var request = new CommissionCalRequestDTO
        {
            LocalSalesCount = 0,
            ForeignSalesCount = 0,
            AverageSaleAmount = 1000
        };

        var result = _service.CalculateCommission(request);

        Assert.Equal(0, result.AvalphaTechnologiesCommissionAmount);
        Assert.Equal(0, result.CompetitorCommissionAmount);
    }

    [Fact]
    public void CalculateCommission_OnlyLocalSales_ReturnsCommission()
    {
        var request = new CommissionCalRequestDTO
        {
            LocalSalesCount = 8,
            ForeignSalesCount = 0,
            AverageSaleAmount = 2000
        };

        var result = _service.CalculateCommission(request);

        Assert.True(result.AvalphaTechnologiesCommissionAmount > 0);
    }

    [Fact]
    public void CalculateCommission_OnlyForeignSales_ReturnsCommission()
    {
        var request = new CommissionCalRequestDTO
        {
            LocalSalesCount = 0,
            ForeignSalesCount = 6,
            AverageSaleAmount = 1500
        };

        var result = _service.CalculateCommission(request);

        Assert.True(result.AvalphaTechnologiesCommissionAmount > 0);
    }

    [Fact]
    public void CalculateCommission_HighAverageAmount_ReturnsCommission()
    {
        var request = new CommissionCalRequestDTO
        {
            LocalSalesCount = 20,
            ForeignSalesCount = 10,
            AverageSaleAmount = 100000
        };

        var result = _service.CalculateCommission(request);

        Assert.True(result.AvalphaTechnologiesCommissionAmount > 0);
    }
}
