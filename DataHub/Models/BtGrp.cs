using System;
using System.Collections.Generic;

namespace DataHub.Models;

public partial class BtGrp
{
    public string GrpId { get; set; } = null!;

    public string? GrpName { get; set; }

    public string? GrpSts { get; set; }

    public string? UserLog { get; set; }

    public DateTime? TimeLog { get; set; }

    public string? SysLog { get; set; }
}
