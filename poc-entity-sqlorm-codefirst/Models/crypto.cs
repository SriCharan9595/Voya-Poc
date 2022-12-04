using System.ComponentModel.DataAnnotations;

namespace poc_voya_entity.Models
{
    public class crypto
    {
        [Key]
        public int cryptoID { get; set; }
        public string cryptoName { get; set; }
        public double priceUSD { get; set; }
        public string cryptoDescription { get; set; }
    }
}
