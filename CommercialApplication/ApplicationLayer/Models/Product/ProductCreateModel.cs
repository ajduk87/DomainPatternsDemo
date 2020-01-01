using CommercialApplication.ApplicationLayer.Models.Product;

namespace CommercialApplicationCommand.ApplicationLayer.Models.Product
{
    public class ProductCreateModel
    {
        public string Name { get; set; }
        public UnitCostModel UnitCost { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string VideoLink { get; set; }
        public string SerialNumber { get; set; }
        public string KindOfProduct { get; set; }
    }
}