using System.ComponentModel.DataAnnotations;

namespace Lottery.Data
{
    public class SecondaryNumbers
    {
        [Required]
        public int Value { get; set; }

    }
}