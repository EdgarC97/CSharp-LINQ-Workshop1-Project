//Creacion de la clase principal de Ventas

public class Sell
{
    public int Id { get; set; }
    public DateTime SellDate { get; set; }
    public decimal ProductValue { get; set; }
    public int ProductQuantity { get; set; }
    public string? Seller { get; set; }
    public string? Buyer { get; set; }
    public int WarrantyTime { get; set; }

    //Constructor de la clase - Creacion de instancia (objeto especifico creado a partir de una clase   )
    public Sell(int id, DateTime selldate, decimal productvalue, int productquantity, string seller, string buyer, int warrantytime)
    {
        Id = id;
        SellDate = selldate;
        ProductValue = productvalue;
        ProductQuantity = productquantity;
        Seller = seller;
        Buyer = buyer;
        WarrantyTime = warrantytime;
    }
    //Sobreescribo con metodo ToString() para obtener representacion visual legible
    public override string ToString()
    {
        return $"Id: {Id}, Sell Date: {SellDate}, Product Value: {ProductValue:C}, Product Quantity: {ProductQuantity}, Seller: {Seller}, Buyer: {Buyer}, Warranty time: {WarrantyTime} months";
    }
}

class Program
{
    //Punto de entrada de la aplicacion
    static void Main(string[] args)
    {
        //Creacion de la lista que contiene productos de la clase de ventas
        List<Sell> sellSheet = new List<Sell>()
        {
            new Sell (1,new DateTime(2009, 06, 05),50000,20,"JOACO","PEPE",3)
        };

        //Creacion del menu en bucle while
        bool flag = false;

        while (!flag)
        {
            Console.Clear(); // Limpiar la consola

            Console.WriteLine(
@"###############################################################################################
#                             SISTEMA DE ANALISIS DE VENTAS                                   #
###############################################################################################");
            Console.WriteLine("\n1. Registrar nueva venta");
            Console.WriteLine("2. Consultar valor total de una venta");
            Console.WriteLine("3. Consultar promedio de ventas diarias");
            Console.WriteLine("4. Ver empleado y cliente del mes");
            Console.WriteLine("5. Filtrar ventas por fecha");
            Console.WriteLine("6. Consultar vendedores por encima de un valor");
            Console.WriteLine("7. Consultar total de ventas mensuales");
            Console.WriteLine("8. Encontrar el mejor vendedor por periodo");
            Console.WriteLine("9. Mostrar Top N Ventas por Valor Descendente");
            Console.WriteLine("10. Mostrar productos mas vendidos por año");
            Console.WriteLine("11. Consultar ventas por valor especifico");
            Console.WriteLine("12. Consultar ventas por cliente");
            Console.WriteLine("13. Mostrar total de ventas y promedio por vendedor");
            Console.WriteLine("14. Ver mes con mayor numero de ventas y detalles");
            Console.WriteLine("15. Salir");
            Console.WriteLine("-----------------------------------------------------------------------------------------------");
            Console.Write("Selecciona una opcion --> ");

            //Switch para manejar las opciones ingresadas por el usuario
            switch (Console.ReadLine())
            {
                case "1":
                    RegisterNewSale(sellSheet);
                    break;
                case "2":
                    CalculateTotalSaleValue(sellSheet);
                    break;
                case "3":
                    CalculateDailySalesAverage(sellSheet);
                    break;
                case "4":
                    DisplayEmployeeAndCustomerOfTheMonth(sellSheet);
                    break;
                case "5":
                    FilterSalesByDate(sellSheet);
                    break;
                case "6":
                    SellersAboveValue(sellSheet);
                    break;
                case "7":
                    CalculateMonthlySalesTotal(sellSheet);
                    break;
                case "8":
                    FindTopSellerInPeriod(sellSheet);
                    break;
                case "9":
                    ShowTopNSalesDescending(sellSheet);
                    break;
                case "10":
                    ShowBestSellingProductsByYear(sellSheet);
                    break;
                case "11":
                    SearchSalesByValue(sellSheet);
                    break;
                case "12":
                    SearchSalesByCustomer(sellSheet);
                    break;
                case "13":
                    ShowTotalSalesAndAveragePerSeller(sellSheet);
                    break;
                case "14":
                    ShowMonthWithHighestSales(sellSheet);
                    break;
                case "15":
                    Console.WriteLine("Saliendo del programa...");
                    Console.WriteLine("Gracias por usar el gestor de inventarios.");
                    flag = true;
                    break;
                default:
                    Console.WriteLine("Opcion invalida, intenta de nuevo");
                    pressKey();
                    break;
            }
        }
    }
    //Funcion para devolver al usuario al menu 
    public static void pressKey()
    {
        // Esperar a que el usuario presione cualquier tecla para continuar
        Console.WriteLine("\nPresiona cualquier tecla para volver al menú principal...");
        Console.ReadKey(true);
    }

    public static void RegisterNewSale(List<Sell> sellSheet)
    {
        // Implementar la lógica para registrar una nueva venta
    }

    public static void CalculateTotalSaleValue(List<Sell> sellSheet)
    {
        // Implementar la lógica para calcular el valor total de una venta específica
    }

    public static void CalculateDailySalesAverage(List<Sell> sellSheet)
    {
        // Implementar la lógica para calcular el promedio de ventas diarias
    }

    public static void DisplayEmployeeAndCustomerOfTheMonth(List<Sell> sellSheet)
    {
        // Implementar la lógica para mostrar al empleado y cliente del mes
    }

    public static void FilterSalesByDate(List<Sell> sellSheet)
    {
        // Implementar la lógica para filtrar las ventas por fecha
    }

    public static void SellersAboveValue(List<Sell> sellSheet)
    {
        // Implementar la lógica para listar vendedores que superan un valor de ventas
    }

    public static void CalculateMonthlySalesTotal(List<Sell> sellSheet)
    {
        // Implementar la lógica para calcular el total de ventas mensuales
    }

    public static void FindTopSellerInPeriod(List<Sell> sellSheet)
    {
        // Implementar la lógica para encontrar al mejor vendedor en un período específico
    }

    public static void ShowTopNSalesDescending(List<Sell> sellSheet)
    {
        // Implementar la lógica para mostrar las N ventas más altas en orden descendente
    }

    public static void ShowBestSellingProductsByYear(List<Sell> sellSheet)
    {
        // Implementar la lógica para mostrar los productos más vendidos por año
    }

    public static void SearchSalesByValue(List<Sell> sellSheet)
    {
        // Implementar la lógica para buscar ventas por un valor específico
    }

    public static void SearchSalesByCustomer(List<Sell> sellSheet)
    {
        // Implementar la lógica para buscar ventas por cliente específico
    }

    public static void ShowTotalSalesAndAveragePerSeller(List<Sell> sellSheet)
    {
        // Implementar la lógica para mostrar el total de ventas y promedio por vendedor
    }

    public static void ShowMonthWithHighestSales(List<Sell> sellSheet)
    {
        // Implementar la lógica para mostrar el mes con mayor número de ventas y detalles
    }
}