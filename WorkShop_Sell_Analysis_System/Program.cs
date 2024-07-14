using WorkShop.SalesAnalizer.Models;

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
            new Sell(nextId++,new DateTime(2009, 06, 25),"Lavadora",1500000,3,"AQUILES","PATROCLO",12),
            new Sell(nextId++, new DateTime(2009, 06, 15),"Televisor", 1600000, 5, "HELENA", "ALEJANDRO", 18),
            new Sell(nextId++, new DateTime(2009, 06, 19),"Nevera", 2800000, 3, "PRIAMO", "HECUBA", 15),
            new Sell(nextId++, new DateTime(2010, 06, 30), "Aire Acondicionado", 1200000, 2, "HECTOR", "ANDRÓMACA", 24),
            new Sell(nextId++, new DateTime(2010, 06, 22), "Air Frayer", 300000, 100, "AQUILES", "HECUBA", 10)
        };

        //Creacion del menu en bucle while
        bool flag = false;

        while (!flag)
        {
            Console.Clear(); // Limpiar la consola

            Console.WriteLine(
    @"#############################################################################################################################
#                                             SISTEMA DE ANALISIS DE VENTAS                                                 #
#############################################################################################################################");
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
            Console.WriteLine("12. Consultar ventas por cliente especifico");
            Console.WriteLine("13. Mostrar total de ventas y promedio por vendedor");
            Console.WriteLine("14. Ver mes con mayor numero de ventas y detalles");
            Console.WriteLine("15. Salir");
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------");
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

    //******************************METODOS DE ENTRADA DE DATOS***************************

    //Funcion para registrar nueva venta (1).
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
        Console.Write("Ingresa la fecha de la nueva venta (dd/mm/aaaa) --> ");
        string? inputDate = Console.ReadLine();

        //Verifico que la fecha tenga el formato correcto
        if (!DateTime.TryParseExact(inputDate, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime sellDate))
        {
            Console.WriteLine("Fecha ingresada incorrectamente");
            pressKey();
            return;
        }
        //Se pide el nombre del producto
        Console.WriteLine();
        Console.Write("Ingresa el nombre del producto --> ");
        string? productName = Console.ReadLine();
        //Verifico que el nombre no sea nulo o tenga espacios en blanco
        if (string.IsNullOrWhiteSpace(productName))
        {
            Console.WriteLine("El nombre no puede estar vacio");
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
        Sell? sell = new Sell(sellSheet.Count + 1, sellDate, productName, productValue, productQuantity, seller, buyer, warrantyTime);
        sellSheet.Add(sell);

        Console.WriteLine("Venta agregada satisfactoriamente");

        //Devolver al menu principal 
        pressKey();
    }

    //******************************METODOS DE VISUALIZACION******************************

    //Funcion para devolver al usuario al menu 
    public static void pressKey()

    {
        // Esperar a que el usuario presione cualquier tecla para continuar
        Console.WriteLine("\nPresiona cualquier tecla para volver al menú principal...");
        Console.ReadKey(true);//El parámetro 'true' se utiliza para omitir la visualización de la tecla presionada.
    }
    // Layout de la hoja de ventas. Muestra un listado de ventas en formato tabular
    public static void SellSheetLayout(List<Sell> sellSheet)
    {
        Console.Clear(); // Limpiar la consola
        Console.WriteLine(
    @"#############################################################################################################################
#                                                  LISTADO DE VENTAS                                                        #
#############################################################################################################################");
        Console.WriteLine(
    @"                                                                                              
Nro |    Fecha     | Producto           |    Valor       | Cantidad |  Vendedor  | Comprador    | Garantía  |   Total      
-----------------------------------------------------------------------------------------------------------------------------");

        decimal totalGeneral = 0; // Variable para almacenar el total general de todos los productos

        // Iterar sobre cada venta en la hoja de ventas
        for (int i = 0; i < sellSheet.Count; i++)
        {
            Sell sell = sellSheet[i];

            // Calculo del total del producto (valor del producto x cantidad)
            decimal totalSell = sell.ProductValue * sell.ProductQuantity;
            totalGeneral += totalSell; // Sumar al total general

            // Mostrar cada producto en la tabla usando formatos fijos para mantener el alineamiento
            Console.WriteLine(
                $"{i + 1,-3} | {sell.SellDate.ToShortDateString(),-12} | {sell.ProductName,-18} | " +
                $"{sell.ProductValue,-14:C} | {sell.ProductQuantity,-8} | {sell.Seller,-10} | {sell.Buyer,-12} | {sell.WarrantyTime,-1} meses  | {totalSell,-10:C}");
        }

        //Línea separadora y total general
        Console.WriteLine(
    @"-----------------------------------------------------------------------------------------------------------------------------");
        Console.WriteLine(
    @$"                                      Total general de ventas: {totalGeneral:C}                                          ");
        Console.WriteLine(
    @"-----------------------------------------------------------------------------------------------------------------------------");
    }

    //******************************METODOS DE CALCULO Y ANALISIS*************************

    //Funcion para mostrar el total de ventas (2).
    public static void CalculateTotalSaleValue(List<Sell> sellSheet)
    {
        //Invocamos el Layout
        SellSheetLayout(sellSheet);

        //Devolver al usuario al menu principal
        pressKey();
    }

    //Funcion para calcular las ventas diarias (3).
    public static void CalculateDailySalesAverage(List<Sell> sellSheet)
    {
        Console.Clear(); // Limpiar la consola para una visualización clara

        // Agrupar las ventas por fecha y calcular el total de ventas para cada día
        var dailySales = sellSheet
            .GroupBy(s => s.SellDate.Date) // Agrupamos por fecha sin considerar la hora
            .Select(g => new
            {
                Date = g.Key, // Fecha de la venta
                TotalSales = g.Sum(s => s.ProductValue * s.ProductQuantity) // Total de ventas en ese día
            })
            .OrderBy(d => d.Date) // Ordenar por fecha ascendente
            .ToList(); // Convertir a lista para procesar y mostrar

        // Calcular el promedio de ventas diarias
        decimal averageSales = dailySales.Any() ? dailySales.Average(d => d.TotalSales) : 0; // Si hay datos, calculamos el promedio

        // Mostrar los resultados en formato tabla
        Console.WriteLine(
            @"#######################################
#      VENTAS DIARIAS Y PROMEDIO      #
#######################################");
        Console.WriteLine(
            @"Fecha       | Total de Ventas         |
---------------------------------------");

        // Mostrar cada venta diaria
        foreach (var dailySale in dailySales)
        {
            Console.WriteLine(
                $"{dailySale.Date.ToShortDateString(),-11} | {dailySale.TotalSales,-16:C} ");
        }

        Console.WriteLine(
            @"---------------------------------------");
        Console.WriteLine($"Promedio de ventas diarias: {averageSales:C}"); // Mostrar el promedio al final

        // Devolver al menú principal
        pressKey();
    }

    //Funcion para mostrar el empleado y clientes del mes (4).
    public static void DisplayEmployeeAndCustomerOfTheMonth(List<Sell> sellSheet)
    {
        Console.Clear(); // Limpiar la consola

        // Logica para determinar al empleado del mes

        // Agrupar las ventas por mes y por vendedor para calcular el total de ventas de cada vendedor en cada mes
        var employeeSales = sellSheet
            // Creamos un objeto anónimo que contiene el nombre del vendedor y su total de ventas para cada grupo
            .GroupBy(s => new { s.SellDate.Month, s.Seller })
            .Select(g => new { g.Key.Seller, TotalSales = g.Sum(s => s.ProductValue * s.ProductQuantity) });

        // Ordenar los vendedores por total de ventas en orden descendente y seleccionar el primero (el mejor vendedor)
        var bestSeller = employeeSales
            .OrderByDescending(es => es.TotalSales)
            .FirstOrDefault();//El primer elemento después de ordenar es el vendedor con más ventas, o null si no hay datos

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

        //Agrupar las compras por mes y por cliente para calcular el total de compras de cada cliente en cada mes
        var clientPurchases = sellSheet
            // Creamos un objeto anónimo que contiene el nombre del cliente y su total de compras para cada grupo
            .GroupBy(s => new { s.SellDate.Month, s.Buyer })
            .Select(g => new { g.Key.Buyer, TotalPurchases = g.Sum(s => s.ProductValue * s.ProductQuantity) });

        // Ordenar los clientes por total de compras en orden descendente y seleccionar el primero (el mejor cliente)
        var bestClient = clientPurchases
            .OrderByDescending(es => es.TotalPurchases)
            .FirstOrDefault();// El primer elemento después de ordenar es el cliente con más compras, o null si no hay dato

        // Verificamos si se encontró un mejor cliente y mostramos su información
        if (bestClient != null)
        {
            // Si hay un mejor cliente, mostramos su nombre y el total de sus compras
            Console.WriteLine($"El cliente del mes es {bestClient.Buyer} con un total de compras de {bestClient.TotalPurchases:C}");
        }
        else
        {
            Console.WriteLine("No hay compras registradas para mostrar.");
        }

        //Devolver al menu principal
        pressKey();
    }

    //Función para Agrupar las ventas por mes y calcular el total de ventas mensuales (7).
    public static void CalculateMonthlySalesTotal(List<Sell> sellSheet)
    {
        Console.Clear(); // Limpiar la consola

        // Agrupar las ventas por mes, año y nombre del producto
        var monthlySales = sellSheet
            // Agrupamos las ventas usando un objeto anónimo que contiene el año, el mes y el nombre del producto
            .GroupBy(s => new { s.SellDate.Year, s.SellDate.Month, s.ProductName })
            .Select(g => new
            {
                YearMonth = $"{g.Key.Year}/{g.Key.Month:D2}", // Formato Año-Mes
                ProductName = g.Key.ProductName, // Nombre del producto para mostrar en la tabla
                TotalSales = g.Sum(s => s.ProductValue * s.ProductQuantity), // Calcular el total de ventas para cada producto en el mes
                MaxSale = g.Max(s => s.ProductValue * s.ProductQuantity) // Encontrar la venta máxima para cada producto en el mes
            })
            .OrderBy(g => g.YearMonth) // Ordenar por el período de tiempo (Año/Mes) para mostrar ventas cronológicamente
            .ThenBy(g => g.ProductName); // Luego, ordenar por nombre del producto para agrupar las ventas del mismo producto juntas

        // Mostrar encabezado de la tabla
        Console.WriteLine(
            @"##################################################################
#                   TOTAL DE VENTAS MENSUALES                    #
##################################################################");
        Console.WriteLine(
            @"                                                                                              
Mes     | Producto           |  Total Ventas    | Mayor Venta      
------------------------------------------------------------------");

        // Mostrar los resultados en formato tabla
        foreach (var month in monthlySales)
        {
            Console.WriteLine(
                $"{month.YearMonth,-7} | {month.ProductName,-18} | {month.TotalSales,-16:C} | {month.MaxSale,-15:C}");
        }

        Console.WriteLine(
            @"------------------------------------------------------------------");
        //Devolver al menu principal    
        pressKey();
    }

    //Funcion para encontrar el vendedor con el mayor número de ventas en un período específico (8).
    public static void FindTopSellerInPeriod(List<Sell> sellSheet)
    {
        Console.Clear(); // Limpiar la consola

        // Se solicita al usuario el rango de fechas
        Console.WriteLine();
        Console.Write("Ingresa la fecha inicial (MM/dd/yyyy) --> ");
        string? inputInitialDate = Console.ReadLine();
        Console.Write("Ingresa la fecha final (MM/dd/yyyy) --> ");
        string? inputFinalDate = Console.ReadLine();

        // Verifico que las fechas tengan el formato correcto
        if (!DateTime.TryParseExact(inputInitialDate, "MM/dd/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime initialDate) ||
            !DateTime.TryParseExact(inputFinalDate, "MM/dd/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime finalDate))
        {
            // Mostrar mensaje de error si las fechas son inválidas
            Console.WriteLine("\nFecha ingresada incorrectamente");
            pressKey();
            return;
        }

        // Verificar que la fecha final sea después de la fecha inicial
        if (initialDate > finalDate)
        {
            Console.WriteLine("La fecha final debe ser posterior a la fecha inicial.");
            pressKey();
            return;
        }

        // Filtrar las ventas dentro del período especificado por el usuario
        // Utilizamos el método Where para seleccionar solo las ventas dentro del rango de fechas
        var filteredSales = sellSheet.Where(s => s.SellDate.Date >= initialDate.Date && s.SellDate.Date <= finalDate.Date);

        // Verificar si hay ventas en el período especificado
        if (filteredSales.Any())
        {
            // Contar el número de ventas realizadas por cada vendedor
            var sellerSalesCount = filteredSales
                .GroupBy(s => s.Seller) // Agrupamos las ventas por vendedor
                .Select(group => new
                {
                    Seller = group.Key, // Nombre del vendedor (clave del grupo)
                    SalesCount = group.Count() // Número de ventas realizadas por el vendedor
                })
                .ToList(); // Convertir a lista para procesar

            //Encontrar el vendedor con el mayor número de ventas
            // Ordenamos la lista de vendedores por el número de ventas en orden descendente
            var topSeller = sellerSalesCount
                .OrderByDescending(s => s.SalesCount) // Ordenamos de mayor a menor número de ventas
                .FirstOrDefault(); // Tomamos el primer vendedor de la lista ordenada

            //Mostrar el resultado
            if (topSeller != null)
            {
                Console.WriteLine($"\nEl vendedor con el mayor número de ventas del período {initialDate.ToShortDateString()} al {finalDate.ToShortDateString()} es ->{topSeller.Seller}<- con {topSeller.SalesCount} ventas.");
            }
            else
            {
                Console.WriteLine("\nNo se encontraron vendedores en el período especificado.");
            }
        }
        else
        {
            Console.WriteLine("\nNo hay ventas registradas para mostrar en estas fechas.");
        }

        // Devolver al menú principal
        pressKey();
    }

    //******************************METODOS DE FILTRADO Y BUSQUEDA************************

    //Funcion para filtrar ventas por fecha especifica (5).
    public static void FilterSalesByDate(List<Sell> sellSheet)
    {
        Console.Clear(); // Limpiar la consola

        // Solicitar al usuario la fecha para filtrar
        Console.WriteLine();
        Console.Write("Ingresa la fecha de la venta (dd/MM/yyyy) --> ");
        string? inputDate = Console.ReadLine();

        // Verifico que la fecha tenga el formato correcto
        if (!DateTime.TryParseExact(inputDate, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime sellDate))
        {
            // Mostrar mensaje de error si el formato de la fecha es incorrecto
            Console.WriteLine("Fecha ingresada incorrectamente");
            pressKey();
            return;
        }

        // Filtrar las ventas que coinciden con la fecha ingresada
        var filteredSales = sellSheet.Where(s => s.SellDate.Date == sellDate.Date);

        // Verificar si hay ventas para la fecha especificada
        if (filteredSales.Any())
        {
            Console.WriteLine($"Ventas para la fecha: {sellDate.ToShortDateString()}");

            // Mostrar detalles de cada venta filtrada
            foreach (var sale in filteredSales)
            {
                Console.WriteLine($"\nVenta: {sale.ProductValue:C} \nProducto: {sale.ProductName} \nVendedor: {sale.Seller} \nComprador: {sale.Buyer} \nCantidad: {sale.ProductQuantity}");
            }
        }
        else
        {
            // Informar si no hay ventas para la fecha especificada
            Console.WriteLine("No hay ventas registradas para mostrar en esta fecha.");
        }

        // Devolver al menú principal
        pressKey();
    }

    //Funcion para mostrar vendedores por encima de un valor (6).
    public static void SellersAboveValue(List<Sell> sellSheet)
    {
        Console.Clear();//Limpiar consola

        // Solicitar al usuario un valor de referencia para filtrar los vendedores
        Console.Write("Por favor ingresa un valor de referencia --> ");

        // Usamos decimal.TryParse para manejar entradas no válidas y evitar errores
        if (!decimal.TryParse(Console.ReadLine(), out decimal refValue))
        {
            // Informar al usuario si el valor ingresado no es válido
            Console.WriteLine("Valor inválido");
            pressKey();
            return;
        }

        // Filtrar los vendedores cuyas ventas totales superan el valor de referencia
        var sellersAboveValue = sellSheet
            .GroupBy(s => s.Seller)// Agrupar ventas por vendedor
            .Select(g => new
            {
                Seller = g.Key,// Nombre del vendedor
                TotalSales = g.Sum(s => s.ProductValue * s.ProductQuantity)// Total de ventas para el vendedor
            })
            .Where(g => g.TotalSales >= refValue) // Filtrar grupos con ventas totales mayores o iguales al valor de referencia
            .ToList(); // Convertir a lista para facilitar la verificación

        // Mostrar encabezado y mensaje de resultados
        Console.WriteLine();
        Console.WriteLine("===================================================================");
        Console.WriteLine("          RESULTADOS DE VENDEDORES CON VENTAS SUPERIORES         ");
        Console.WriteLine("===================================================================");
        Console.WriteLine();

        // Comprobar si hay vendedores que cumplan con el criterio
        if (sellersAboveValue.Count == 0)
        {
            // Informar si no hay vendedores con ventas superiores al valor ingresado
            Console.WriteLine("No se encontraron vendedores con ventas superiores al valor ingresado.");
        }
        else
        {
            // Mostrar la información de cada vendedor que cumple con el criterio
            foreach (var seller in sellersAboveValue)
            {
                Console.WriteLine($"Vendedor: {seller.Seller,-15} | Ventas Totales: {seller.TotalSales:C}");
            }
        }
        //Devolver al menu principal
        pressKey();
    }

    //Funcion para buscar venta por valor especifico (11).
    public static void SearchSalesByValue(List<Sell> sellSheet)
    {
        Console.Clear(); // Limpiar la consola

        // Solicitar al usuario el valor exacto de la venta que desea buscar
        Console.WriteLine();
        Console.Write("Ingresa el valor exacto de la venta que desea validar --> ");
        string? inputValue = Console.ReadLine();

        // Verificar que el valor ingresado sea un número decimal válido y que no sea negativo
        if (!decimal.TryParse(inputValue, out decimal value) || value < 0)
        {
            Console.WriteLine("\nValor ingresado incorrectamente. Asegúrate de ingresar un número decimal positivo.");
            pressKey();
            return;
        }

        // Filtrar las ventas que tienen el valor exacto especificado por el usuario
        // Usamos Where para seleccionar solo las ventas donde el valor total (ProductValue * ProductQuantity) coincide con el valor ingresado
        var filteredSales = sellSheet.Where(s => (s.ProductValue * s.ProductQuantity) == value).ToList();

        // Verificar si hay ventas que coinciden con el valor especificado
        if (filteredSales.Any())
        {
            // Mostrar las ventas que coinciden con el valor específico
            Console.WriteLine($"\nVentas con valor exacto de {value:C}:");

            // Iterar sobre cada venta filtrada y mostrar los detalles
            foreach (var sale in filteredSales)
            {
                Console.WriteLine($"\nFecha: {sale.SellDate.ToShortDateString()} \nProducto: {sale.ProductName} \nVendedor: {sale.Seller} \nComprador: {sale.Buyer} \nValor: {sale.ProductValue:C}  \nCantidad: {sale.ProductQuantity} ");
            }
        }
        else
        {
            // Informar al usuario si no se encontraron ventas con el valor exacto
            Console.WriteLine($"\nNo hay ventas registradas con valor de {value:C}.");
        }

        // Devolver al menú principal
        pressKey();
    }

    //Funcion para buscar todas las ventas realizadas a un cliente específico (12).
    public static void SearchSalesByCustomer(List<Sell> sellSheet)
    {
        Console.Clear(); // Limpiar la consola

        // Solicitar al usuario el nombre del cliente
        Console.WriteLine();
        Console.Write("Ingresa el nombre del cliente que desea consultar --> ");
        string? customerName = Console.ReadLine()?.Trim();

        // Verificar que el nombre del cliente no esté vacío o nulo
        if (string.IsNullOrEmpty(customerName))
        {
            Console.WriteLine("\nEl nombre del cliente ingresado es inválido.");
            pressKey();
            return;
        }

        // Filtrar las ventas que tienen al cliente especificado como comprador
        // .Where se usa para seleccionar las ventas donde el campo Buyer coincide con el nombre proporcionado
        var filteredSales = sellSheet
            .Where(s => s.Buyer?.Equals(customerName, StringComparison.OrdinalIgnoreCase) == true)
            .ToList();// Convertir a lista para facilitar el procesamiento y la visualización

        // Verificar si hay ventas para el cliente especificado
        if (filteredSales.Any())
        {
            Console.WriteLine($"\nVentas realizadas a {customerName}:");

            // Mostrar cada venta filtrada
            foreach (var sale in filteredSales)
            {
                // Mostrar los detalles de cada venta, manejando valores null para evitar errores
                Console.WriteLine($"\nVenta: {sale.ProductValue:C} \nProducto: {sale.ProductName ?? "N/A"} \nVendedor: {sale.Seller ?? "N/A"} \nComprador: {sale.Buyer ?? "N/A"} \nCantidad: {sale.ProductQuantity} \nFecha: {sale.SellDate.ToShortDateString()}");
            }
        }
        else
        {
            Console.WriteLine($"\nNo se encontraron ventas realizadas a {customerName}.");
        }

        // Devolver al menú principal
        pressKey();
    }

    //******************************METODOS DE REPORTE***********************************

    //Funcion para ordenar las ventas por valor total descendente y mostrar las primeras N ventas (9).
    public static void ShowTopNSalesDescending(List<Sell> sellSheet)
    {
        Console.Clear(); // Limpiar la consola

        // Solicitar al usuario el número de ventas más altas a mostrar
        Console.WriteLine();
        Console.Write("Ingrese la cantidad de ventas más altas que desea mostrar: ");
        string? inputTopN = Console.ReadLine();

        // Validar que la entrada sea un número entero positivo
        if (!int.TryParse(inputTopN, out int topN) || topN <= 0)
        {
            Console.WriteLine("Número ingresado no válido. Debe ser un número entero positivo.");
            pressKey();
            return;
        }

        //Ordenar las ventas por valor total descendente
        var sortedSales = sellSheet
            .Select(s => new
            {
                s.ProductName,// Nombre del producto
                s.Seller,// Nombre del vendedor
                s.Buyer,// Nombre del comprador
                s.ProductValue,// Valor del producto unitario
                s.ProductQuantity,// Cantidad de productos vendidos
                TotalValue = s.ProductValue * s.ProductQuantity // Calcular el valor total de la venta
            })
            .OrderByDescending(s => s.TotalValue) // Ordenar las ventas de mayor a menor valor total
            .ToList(); // Convertir a lista para permitir la selección de las N primeras ventas

        //Seleccionar las primeras N ventas
        var topSales = sortedSales.Take(topN).ToList(); // Tomar las primeras N ventas ordenadas

        // Mostrar las ventas seleccionadas
        if (topSales.Any())
        {
            Console.WriteLine("\nVentas más altas:");
            Console.WriteLine();
            Console.WriteLine(
                @"Nro | Producto           | Vendedor | Comprador | Valor Producto | Cantidad | Valor Total
--------------------------------------------------------------------------------------------------");

            int counter = 1; // Contador para numerar las ventas
            foreach (var sale in topSales)
            {
                Console.WriteLine(
                    $"{counter,-3} | {sale.ProductName,-18} | {sale.Seller,-8} | {sale.Buyer,-9} | {sale.ProductValue,-14:C} | {sale.ProductQuantity,-8} | {sale.TotalValue,-12:C}");
                counter++;// Incrementar el contador para la siguiente venta
            }
        }
        else
        {
            // Informar al usuario si no hay ventas registradas
            Console.WriteLine("No hay ventas registradas para mostrar.");
        }

        // Devolver al menú principal
        pressKey();
    }

    //Funcion para encontrar los productos más vendidos por cantidad en un año determinado. (10).
    public static void ShowBestSellingProductsByYear(List<Sell> sellSheet)
    {
        Console.Clear(); // Limpiar la consola

        // Solicitar al usuario el año para filtrar los productos vendidos
        Console.WriteLine();
        Console.Write("Ingresa el año para ver los productos más vendidos (por ejemplo, 2009) --> ");
        string? inputYear = Console.ReadLine();

        // Verificar que el año ingresado sea un número válido dentro del rango razonable
        if (!int.TryParse(inputYear, out int year) || year < 1900 || year > 2100)
        {
            Console.WriteLine("\nAño ingresado incorrectamente.");
            pressKey();
            return;
        }

        // Filtrar las ventas para el año especificado permitiendo concentrarse solo en las ventas de ese año
        var salesInYear = sellSheet.Where(s => s.SellDate.Year == year).ToList();

        // Verificar si hay ventas registradas para el año especificado
        if (salesInYear.Any())
        {
            // Agrupar las ventas por nombre de producto y calcular la cantidad total vendida para cada producto
            var productSales = salesInYear
                .GroupBy(s => s.ProductName)// Agrupa por nombre del producto
                .Select(g => new
                {
                    ProductName = g.Key,// Nombre del producto
                    TotalQuantity = g.Sum(s => s.ProductQuantity)// Cantidad total vendida del producto
                })
                .OrderByDescending(p => p.TotalQuantity);// Ordenar los productos de mayor a menor cantidad vendida

            // Mostrar los productos más vendidos en el año especificado
            Console.WriteLine($"\nProductos más vendidos en el año {year}:");
            foreach (var product in productSales)
            {
                Console.WriteLine($"\n{product.ProductName}: {product.TotalQuantity} unidades vendidas");
            }
        }
        else
        {
            // Informar al usuario si no se encontraron ventas para el año ingresado
            Console.WriteLine($"\nNo hay ventas registradas para el año {year}.");
        }

        // Devolver al menú principal
        pressKey();
    }

    //Funcion para calcular el total de ventas para cada vendedor y mostrar el promedio de ventas por vendedor (13).        
    public static void ShowTotalSalesAndAveragePerSeller(List<Sell> sellSheet)
    {
        Console.Clear(); // Limpiar la consola

        // Calcular el total de ventas, el número de ventas y el promedio de ventas por vendedor
        var salesBySeller = sellSheet
            .GroupBy(s => s.Seller)// Agrupar ventas por vendedor
            .Select(g => new
            {
                Seller = g.Key,// Nombre del vendedor
                TotalSales = g.Sum(s => s.ProductValue * s.ProductQuantity),// Total de ventas del vendedor
                NumberOfSales = g.Count(), // Contar cuántas ventas realizó el vendedor
                AverageSaleValue = g.Sum(s => s.ProductValue * s.ProductQuantity) / g.Count() // Calcular el promedio de ventas por transacción
            })
            .ToList();// Convertir a lista para facilitar la visualización y el procesamiento

        // Mostrar los resultados en formato tabla
        Console.WriteLine(
            @"##################################################################
#            TOTAL DE VENTAS Y PROMEDIO POR VENDEDOR             #
##################################################################");
        Console.WriteLine(
            @"                                                                                              
Vendedor       | Total de Ventas  | Ventas   | Promedio de Ventas      
------------------------------------------------------------------");

        foreach (var seller in salesBySeller)
        {
            Console.WriteLine(
                $"{seller.Seller,-14} | {seller.TotalSales,-16:C} | {seller.NumberOfSales,-8} | {seller.AverageSaleValue,-15:C}");
        }// Mostrar el total de ventas, el número de ventas y el promedio de ventas por vendedor

        // Devolver al menú principal
        pressKey();
    }

    //Funcion para encontrar el mes con el mayor número de ventas y mostrar las ventas de ese mes (14)
    public static void ShowMonthWithHighestSales(List<Sell> sellSheet)
    {
        Console.Clear(); // Limpiar la consola

        // Agrupar las ventas por mes y año
        var salesByMonth = sellSheet
            .GroupBy(s => new { Year = s.SellDate.Year, Month = s.SellDate.Month })// Agrupamos por año y mes
            .Select(g => new
            {
                Year = g.Key.Year,// Año del grupo
                Month = g.Key.Month,// Mes del grupo
                NumberOfSales = g.Count() // Contamos el número de ventas en cada mes
            })
            .ToList();// Convertir a lista para procesar fácilmente

        // Verificar si hay ventas registradas
        if (!salesByMonth.Any())
        {
            Console.WriteLine("No hay ventas registradas.");
            pressKey();
            return;
        }

        // Encontrar el mes con el mayor número de ventas
        var monthWithHighestSales = salesByMonth
            .OrderByDescending(m => m.NumberOfSales)// Ordenar por número de ventas en orden descendente
            .First();// Tomar el primer resultado, que será el mes con más ventas

        // Filtrar las ventas del mes con mayor número de ventas
        var salesInHighestMonth = sellSheet
            .Where(s => s.SellDate.Year == monthWithHighestSales.Year && s.SellDate.Month == monthWithHighestSales.Month)
            .ToList();// Convertir a lista para procesar fácilmente

        // Formatear el nombre del mes
        var monthName = new DateTime(monthWithHighestSales.Year, monthWithHighestSales.Month, 1).ToString("MMMM yyyy");

        // Mostrar el resultado
        Console.WriteLine(
            @"#################################################################################################################
#                                 MES CON MAYOR NÚMERO DE VENTAS Y DETALLES                                     #
#################################################################################################################");
        Console.WriteLine(
            $"\nMes con el mayor número de ventas: {monthName}");
        Console.WriteLine(
            $"Número de ventas en {monthName}: {monthWithHighestSales.NumberOfSales}");
        Console.WriteLine();
        Console.WriteLine(
            @"-----------------------------------------------------------------------------------------------------------------");
        Console.WriteLine(
            @"Fecha       | Producto        | Valor           | Cantidad | Vendedor   | Comprador  | Garantía |   Total      
-----------------------------------------------------------------------------------------------------------------");

        // Mostrar las ventas del mes con el mayor número de ventas en formato de tabla
        foreach (var sale in salesInHighestMonth)
        {
            string formattedValue = sale.ProductValue.ToString("C");// Formatear el valor del producto como moneda
            string formattedTotal = (sale.ProductValue * sale.ProductQuantity).ToString("C");// Calcular y formatear el total de la venta

            Console.WriteLine(
                $"{sale.SellDate.ToShortDateString(),-11} | " +
                $"{sale.ProductName,-15} | " +
                $"{formattedValue,-15} | " +
                $"{sale.ProductQuantity,-8} | " +
                $"{sale.Seller,-10} | " +
                $"{sale.Buyer,-10} | " +
                $"{sale.WarrantyTime,-1} meses | " +
                $"{formattedTotal,-10}");
        }

        // Devolver al menú principal
        pressKey();
    }
}