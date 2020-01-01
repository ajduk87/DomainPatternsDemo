namespace CommercialApplicationCommand.ApplicationLayer.Dtoes.Product
{
    public class ProductDto : Dto
    {
        public string Name { get; set; }
        public string UnitCost { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string VideoLink { get; set; }
        public string SerialNumber { get; set; }
        public string KindOfProduct { get; set; }
    }
}