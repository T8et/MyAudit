using System;
using System.Collections.Generic;

namespace DataHub.Models;

public partial class BtGrpDtl
{
    public string GrpId { get; set; } = null!;

    public int GrlSrl { get; set; }

    public string? UserId { get; set; }

    public string? UserLog { get; set; }

    public DateTime? TimeLog { get; set; }

    public string? SysLog { get; set; }
}
