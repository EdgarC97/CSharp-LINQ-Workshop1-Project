
namespace WorkShop.SalesAnalizer.Models
{
    // Clase que representa una venta en el sistema
    public class Sell
    {
        public int Id { get; set; }// Identificador único de la venta
        public DateTime SellDate { get; set; }// Fecha en que se realizó la venta
        public string? ProductName { get; set; }// Nombre del producto vendido
        public decimal ProductValue { get; set; }// Valor monetario del producto vendido
        public int ProductQuantity { get; set; }// Cantidad de unidades del producto vendidas
        public string? Seller { get; set; }// Nombre del vendedor que realizó la venta
        public string? Buyer { get; set; }// Nombre del comprador que adquirió el producto
        public int WarrantyTime { get; set; }// Tiempo de garantía del producto en meses

        // Constructor para inicializar una nueva instancia de la clase Sell
        public Sell(int id, DateTime selldate, string productname, decimal productvalue, int productquantity, string seller, string buyer, int warrantytime)
        {
            Id = id;
            SellDate = selldate;
            ProductName = productname;
            ProductValue = productvalue;
            ProductQuantity = productquantity;
            Seller = seller;
            Buyer = buyer;
            WarrantyTime = warrantytime;
        }
        //Sobreescribo con metodo ToString() para obtener representacion visual legible
        public override string ToString()
        {
            return $"Id: {Id}, Sell Date: {SellDate}, Product Name: {ProductName} Product Value: {ProductValue:C}, Product Quantity: {ProductQuantity}, Seller: {Seller}, Buyer: {Buyer}, Warranty time: {WarrantyTime} months";
        }
    }
}