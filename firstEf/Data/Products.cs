using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace firstEf.Data
{
    public class Products:Base
    {  
        public string  ?ProductName { get; set; }
        public int CategoryId { get; set; }
        public decimal Price { get; set; }
       

        [ForeignKey("CategoryId")]
        public Categories Categories { get; set; } // Bağlantıyı Temsil Eder. ForeignKey
    }
}
