using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace firstEf.Data
{
    public class Base
    {
        [Key]

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public bool Deleted { get; set; }
    }
}
