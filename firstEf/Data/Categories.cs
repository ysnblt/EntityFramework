namespace firstEf.Data
{
    public class Categories:Base
    {
        public string CategoryName { get; set; }
        public ICollection<Products> Products { get; set; } //Bağlantıyı Temsil Eder. ForeignKey



    }
}
