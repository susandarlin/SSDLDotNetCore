using System;
using System.Collections.Generic;

namespace SSDLDotNetCore.EFCoreDataBaseFirstAuto.EfCoreDataModels;

public partial class TblLogin
{
    public int Id { get; set; }

    public string UserId { get; set; } = null!;

    public string SessionId { get; set; } = null!;

    public DateTime SessionExpired { get; set; }
}
