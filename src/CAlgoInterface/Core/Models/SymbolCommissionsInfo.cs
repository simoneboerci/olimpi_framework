using System;
using CAlgoInterface.Core.Enums;

namespace CAlgoInterface.Core.Models;

public readonly struct SymbolCommissionInfo
{
    double Commission { get; }
    SymbolCommissionType CommissionType { get; }
    double MinCommission { get; }

    DayOfWeek? AdministrativeCharge3DaysRollover { get; }
    double AdministrativeCharge { get; }
    
    public SymbolCommissionInfo(double commission, SymbolCommissionType commissionType, double minCommission, DayOfWeek? administrativeCharge3DaysRollover, double administrativeCharge)
    {
        Commission = commission;
        CommissionType = commissionType;
        MinCommission = minCommission;
        AdministrativeCharge3DaysRollover = administrativeCharge3DaysRollover;
        AdministrativeCharge = administrativeCharge;
    }
}