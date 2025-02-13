using System;
using System.Collections.Generic;

namespace SSDLDotNetCore.EFCoreDataBaseFirstAuto.EfCoreDataModels;

public partial class TblMiddlewareUser
{
    public string UserId { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;
}
