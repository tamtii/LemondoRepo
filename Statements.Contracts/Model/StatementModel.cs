using Microsoft.AspNetCore.Http;
using Statements.Contracts.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statements.Contracts
{
  public class StatementModel
  {
    public int StatementID { get; set; }
    [Required(ErrorMessage = "Title is Required")]
    public string Title { get; set; }
    [Required(ErrorMessage = "Description is Required")]
    public string Description { get; set; }
    [Required(ErrorMessage = "Image is Required")]
    [ImageValidation(new string[] { ".jpg", ".png",".webp" })]
    public IFormFile Image { get; set; }
    public string? ImageURL { get; set; }
    [Required(ErrorMessage = "Phone Number is Required")]
    [RegularExpression(@"^(5)[0-9]{8}$", 
      ErrorMessage = "Correct Phone Number format")]
    public string PhoneNumber { get; set; }
  }
}
