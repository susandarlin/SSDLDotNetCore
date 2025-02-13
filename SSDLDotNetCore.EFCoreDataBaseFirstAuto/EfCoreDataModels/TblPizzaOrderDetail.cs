using System;
using System.Collections.Generic;

namespace SSDLDotNetCore.EFCoreDataBaseFirstAuto.EfCoreDataModels;

public partial class TblPizzaOrderDetail
{
    public int PizzaOrderDetailId { get; set; }

    public string PizzaOrderInvoiceNo { get; set; } = null!;

    public int PizzaExtraId { get; set; }
}
