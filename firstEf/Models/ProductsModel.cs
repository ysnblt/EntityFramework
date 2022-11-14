using firstEf.Data;

namespace firstEf.Models
{
    public class ProductsModel
    {
        public Products Products { get; set; }
        public string Head { get; set; }
        public string Txt { get; set; }
        public string Cls { get; set; }
        public List<Categories> Categories { get; set; }
    }
}
