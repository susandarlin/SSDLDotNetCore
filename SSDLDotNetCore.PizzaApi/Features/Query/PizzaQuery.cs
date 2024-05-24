namespace SSDLDotNetCore.PizzaApi.Features.Query
{
    public class PizzaQuery
    {
        public static string PizzaOrderQuery { get; } = 
            @"select po.*, p.Pizza, p.Price from Tbl_PizzaOrder as po
            inner join Tbl_Pizza as p on po.PizzaId = p.PizzaId
            where PizzaOrderInvoiceNo = @PizzaOrderInvoiceNo";

        public static string PizzaOrderDetailQuery { get; } =
            @"select pod.*, pe.PizzaExtraName, pe.Price from Tbl_PizzaOrderDetail as pod
            inner join Tbl_PizzaExtra as pe on pod.PizzaExtraId = pe.PizzaExtraId
            where PizzaOrderInvoiceNo = @PizzaOrderInvoiceNo";
    }
}
