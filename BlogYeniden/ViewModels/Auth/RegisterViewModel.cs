using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogYeniden.ViewModels.Auth
{
    public class RegisterViewModel
    {
        [Required]
        public string Username { get; set; }

        [Required,DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
