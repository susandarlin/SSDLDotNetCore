using System;
using System.Collections.Generic;

namespace SSDLDotNetCore.ConsoleAppEFCore.Databases.Models;

public partial class TblPizza
{
    public int PizzaId { get; set; }

    public string? Pizza { get; set; }

    public decimal? Price { get; set; }
}
