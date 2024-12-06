using System.ComponentModel.DataAnnotations;

namespace MVVMExampleApp.Backend.Models
{
    public class AddRequest
    {
        [Required(ErrorMessage = "Field FirstInteger is requierd")]
        [Range(int.MinValue, int.MaxValue, ErrorMessage ="Field FirstInteger must be an integer")]
        public int FirstInteger { get; set; }

        [Required(ErrorMessage = "Field SecondInteger is requierd")]
        [Range(int.MinValue, int.MaxValue, ErrorMessage = "Field SecondInteger must be an integer")]
        public int SecondInteger { get; set; }
    }
}
