using firstEf.Data;

namespace firstEf.Models
{
    public class CategoryModel
    {
        public Categories Categories { get; set; }
        public string Head { get; set; }
        public string Txt { get; set; }
        public string Cls { get; set; }
        public bool IncProducts { get; set; }
        public string IncMessage { get; set; }

    }
}
