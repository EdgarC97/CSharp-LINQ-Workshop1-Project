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
        // Variable para almacenar el próximo ID
        int nextId = 1;
        List<Sell> sellSheet = new List<Sell>()
        {
            new Sell(nextId++,new DateTime(2009, 06, 25),50000,20,"JOACO","PEPE",3),
            new Sell(nextId++, new DateTime(2009, 06, 15), 60000, 15, "MARIA", "JUAN", 2),
            new Sell(nextId++, new DateTime(2009, 06, 19), 70000, 10, "CARLOS", "ANA", 1)
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

    //Funcion para registrar nueva venta
    public static void RegisterNewSale(List<Sell> sellSheet)
    {
        Console.Clear(); //Limpiar la consola
        Console.WriteLine(
@"###############################################################################################
#                                    AGREGAR UNA VENTA                                        #
###############################################################################################");
        //Se piden datos de la venta al usuario

        //Se solicita la fecha
        Console.WriteLine();
        Console.Write("Ingresa la fecha de la nueva venta (mm/dd/aaaa) --> ");
        string? inputDate = Console.ReadLine();

        //Verifico que la fecha tenga el formato correcto
        if (!DateTime.TryParseExact(inputDate, "MM/dd/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime sellDate))
        {
            Console.WriteLine("Fecha ingresada incorrectamente");
            pressKey();
            return;
        }
        //Se solicita el valor del producto
        Console.Write("Ingresa el valor del producto --> ");
        //Verifico que el valor sea valido
        if (!decimal.TryParse(Console.ReadLine(), out decimal productValue))
        {
            Console.WriteLine("Valor invalido");
            pressKey();
            return;
        }
        //Se solicita la cantidad del producto
        Console.Write("Ingresa la cantidad del producto --> ");
        //Verifico que la cantidad sea valida 
        if (!int.TryParse(Console.ReadLine(), out int productQuantity))
        {
            Console.WriteLine("Cantidad invalida");
            pressKey();
            return;
        }
        //Se solicita el nombre del vendedor
        Console.Write("Ingresa el nombre del vendedor --> ");
        string? seller = Console.ReadLine();
        //Verifico que el vendedor no este nulo ni con espacios en blanco
        if (string.IsNullOrWhiteSpace(seller))
        {
            Console.WriteLine("El nombre no puede estar vacio");
            pressKey();
            return;
        }
        //Se solicita el nombre del cliente
        Console.Write("Ingresa el nombre del cliente --> ");
        string? buyer = Console.ReadLine();
        //Verifico que el cliente no este nulo ni con espacios en blanco
        if (string.IsNullOrWhiteSpace(buyer))
        {
            Console.WriteLine("El nombre no puede estar vacio");
            pressKey();
            return;
        }
        //Se solicita el tiempo de garantia del producto
        Console.Write("Ingresa los meses de garantia --> ");
        //Verifico que la cantidad sea valida 
        if (!int.TryParse(Console.ReadLine(), out int warrantyTime))
        {
            Console.WriteLine("Cantidad invalida");
            pressKey();
            return;
        }

        //Agregamos la venta a la hoja de ventas
        Sell? sell = new Sell(sellSheet.Count + 1, sellDate, productValue, productQuantity, seller, buyer, warrantyTime);
        sellSheet.Add(sell);

        Console.WriteLine("Venta agregada satisfactoriamente");

        //Devolver al menu principal 
        pressKey();
    }

    //Layout de la hoja de ventas
    public static void SellSheetLayout(List<Sell> sellSheet)
    {
        Console.Clear(); // Limpiar la consola
        Console.WriteLine(
    @"#######################################################################################################
#                                         LISTADO DE VENTAS                                           #
#######################################################################################################");
        Console.WriteLine(
    @"                                                                                              
Nro |    Fecha     |    Valor     | Cantidad   |  Vendedor  |   Comprador  | Garantía  |    Total      
-------------------------------------------------------------------------------------------------------");

        decimal totalGeneral = 0; // Variable para almacenar el total general de todos los productos

        // Iterar sobre cada venta en la hoja de ventas
        for (int i = 0; i < sellSheet.Count; i++)
        {
            Sell sell = sellSheet[i];

            // Calculo del total del producto (valor x cantidad)
            decimal totalSell = (decimal)sell.ProductValue * sell.ProductQuantity;
            totalGeneral += totalSell; // Agrego al total general

            // Mostrar cada producto en la tabla usando formatos fijos para mantener el alineamiento
            Console.WriteLine(
                $"{i + 1,-3} | {sell.SellDate.ToShortDateString(),-12} | {sell.ProductValue,-12:C} | " +
                $"{sell.ProductQuantity,-10} | {sell.Seller,-10} | {sell.Buyer,-12} | {sell.WarrantyTime} meses   | {totalSell,-10:C}");
        }

        // Mostrar línea separadora y total general
        Console.WriteLine(
    @"-------------------------------------------------------------------------------------------------------");
        Console.WriteLine(
    @$"                      Total general de ventas: {totalGeneral:C}                                          ");
        Console.WriteLine(
    @"-------------------------------------------------------------------------------------------------------");
    }

    //Funcion para mostrar el total de ventas
    public static void CalculateTotalSaleValue(List<Sell> sellSheet)
    {
        //Invocamos el Layout
        SellSheetLayout(sellSheet);

        //Devolver al usuario al menu principal
        pressKey();
    }

    //Funcion para calcular las ventas diarias
    public static void CalculateDailySalesAverage(List<Sell> sellSheet)
    {
        Console.Clear(); // Limpiar la consola

        // Filtrar las ventas únicas por fecha y calcular el total de ventas
        var dailySales = sellSheet
            .GroupBy(s => s.SellDate.Date) // Para agrupar por fecha
            .Select(g => g.Sum(s => s.ProductValue * s.ProductQuantity)); // Para sumar ventas por grupo

        // Calcular el promedio
        decimal averageSales = dailySales.Any() ? dailySales.Average() : 0;

        // Mostrar el promedio
        Console.WriteLine($"Promedio de ventas diarias: {averageSales:C}");

        //Devolver al menu principal
        pressKey();
    }

    //Funcion para mostrar el empleado y clientes del mes
    public static void DisplayEmployeeAndCustomerOfTheMonth(List<Sell> sellSheet)
    {
        Console.Clear(); // Limpiar la consola

        //Logica para el empleado del mes

        // Agrupar las ventas por mes y vendedor y sumarlas
        var employeeSales = sellSheet
            .GroupBy(s => new { s.SellDate.Month, s.Seller }) // Agrupar por mes y vendedor
            .Select(g => new { g.Key.Seller, TotalSales = g.Sum(s => s.ProductValue * s.ProductQuantity) }); // Selecciona el vendedor y su total de ventas

        // Obtener el empleado con las ventas más altas
        var bestSeller = employeeSales
            .OrderByDescending(es => es.TotalSales)
            .FirstOrDefault();

        //Verificamos que el valor retornado no sea null
        if (bestSeller != null)
        {
            // Mostrar el empleado y sus ventas
            Console.WriteLine($"El empleado del mes es {bestSeller.Seller} con un total de ventas de {bestSeller.TotalSales:C}");
        }
        else
        {
            Console.WriteLine("No hay ventas registradas para mostrar.");
        }

        //Logica para el cliente del mes

        // Agrupar las compras por mes y cliente y sumarlas
        var clientPurchases = sellSheet
            .GroupBy(s => new { s.SellDate.Month, s.Buyer }) // Agrupar por mes y cliente
            .Select(g => new { g.Key.Buyer, TotalPurchases = g.Sum(s => s.ProductValue * s.ProductQuantity) }); // Selecciona el cliente y su total de compras

        // Obtener el cliente con las compras más altas
        var bestClient = clientPurchases
            .OrderByDescending(es => es.TotalPurchases)
            .FirstOrDefault();

        //Verificamos que el valor retornado no sea null
        if (bestClient != null)
        {
            // Mostrar el cliente y el valor de sus compras
            Console.WriteLine($"El cliente del mes es {bestClient.Buyer} con un total de compras de {bestClient.TotalPurchases:C}");
        }
        else
        {
            Console.WriteLine("No hay compras registradas para mostrar.");
        }

        //Devolver al menu principal
        pressKey();
    }

    //Funcion para filtrar ventas por fecha
    public static void FilterSalesByDate(List<Sell> sellSheet)
    {
        Console.Clear(); // Limpiar la consola

        // Se solicita la fecha
        Console.WriteLine();
        Console.Write("Ingresa la fecha de la venta (MM/dd/yyyy) --> ");
        string? inputDate = Console.ReadLine();

        // Verifico que la fecha tenga el formato correcto
        if (!DateTime.TryParseExact(inputDate, "MM/dd/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime sellDate))
        {
            Console.WriteLine("Fecha ingresada incorrectamente");
            pressKey();
            return;
        }

        // Filtrar las ventas por la fecha ingresada
        var filteredSales = sellSheet.Where(s => s.SellDate.Date == sellDate.Date);

        // Verificamos si hay resultados
        if (filteredSales.Any())
        {
            Console.WriteLine($"Ventas para la fecha: {sellDate.ToShortDateString()}");

            // Mostrar cada venta filtrada
            foreach (var sale in filteredSales)
            {
                Console.WriteLine($"\nVenta: {sale.ProductValue:C} \nVendedor: {sale.Seller} \nComprador: {sale.Buyer} \nCantidad: {sale.ProductQuantity}");
            }
        }
        else
        {
            Console.WriteLine("No hay ventas registradas para mostrar en esta fecha.");
        }

        // Devolver al menú principal
        pressKey();
    }

    //Funcion para mostrar vendedores por encima de un valor
    public static void SellersAboveValue(List<Sell> sellSheet)
    {
        Console.Clear();

        // Solicitar un valor de referencia
        Console.Write("Por favor ingresa un valor de referencia --> ");

        // Verificar que el valor sea válido
        if (!decimal.TryParse(Console.ReadLine(), out decimal refValue))
        {
            Console.WriteLine("Valor inválido");
            pressKey();
            return;
        }

        // Filtrar vendedores con ventas superiores al valor de referencia
        var sellersAboveValue = sellSheet
            .GroupBy(s => s.Seller)
            .Where(g => g.Sum(s => s.ProductValue * s.ProductQuantity) > refValue)
            .Select(g => new
            {
                Seller = g.Key,
                TotalSales = g.Sum(s => s.ProductValue * s.ProductQuantity)
            }).ToList(); // Convertir a lista para facilitar la verificación

        // Comprobar si hay resultados
        if (sellersAboveValue.Count == 0)
        {
            Console.WriteLine("No se encontraron vendedores con ventas superiores al valor ingresado.");
        }
        else
        {
            foreach (var seller in sellersAboveValue)
            {
                Console.WriteLine($"Vendedor: {seller.Seller}, Ventas Totales: {seller.TotalSales:C}");
            }
        }

        pressKey();
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