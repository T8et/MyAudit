using System;
using System.Collections.Generic;

namespace DataHub.Models;

public partial class BtUser
{
    public string UserId { get; set; } = null!;

    public string? UserName { get; set; }

    public string? UserPass { get; set; }

    public string? UserEmail { get; set; }

    public string? UserSts { get; set; }

    public string? XtraChar1 { get; set; }

    public string? XtraChar2 { get; set; }

    public DateTime? TimeLog { get; set; }

    public string? UserLog { get; set; }

    public string? SysLog { get; set; }
}
