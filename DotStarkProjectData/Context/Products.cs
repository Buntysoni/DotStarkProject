using static DotStarkProjectData.Model.CommonModel;

namespace DotStarkProjectData.Context
{
    public class Products
    {
        public int id { get; set; }
        public Guid ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? StockAvailable { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}