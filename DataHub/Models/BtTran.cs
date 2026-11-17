using System;
using System.Collections.Generic;

namespace DataHub.Models;

public partial class BtTran
{
    public string TranId { get; set; } = null!;

    public DateTime? TranDate { get; set; }

    public string? GrpId { get; set; }

    public string? ItemDesc { get; set; }

    public decimal? ItemCost { get; set; }

    public string? TranSts { get; set; }

    public string? UserLog { get; set; }

    public DateTime? TimeLog { get; set; }

    public string? SysLog { get; set; }

    public string? XtraChar1 { get; set; }

    public string? XtraChar2 { get; set; }
}
