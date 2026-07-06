namespace DapperCase7.Entites
{
    public class Shipment
    {
        public int Id { get; set; }
        public string TrackingNumber { get; set; } = string.Empty;
        public string SenderCity { get; set; } = string.Empty;
        public string ReceiverCity { get; set; } = string.Empty;
        public decimal ReceiverLat { get; set; }
        public decimal ReceiverLng { get; set; }
        public int ShipmentStatus { get; set; } // 1: Hazırlanıyor, 2: Yolda, 3: Dağıtımda, 4: Teslim Edildi, 5: İade
        public decimal Weight { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
