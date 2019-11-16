using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace site.Models
{
    public class EmailModel
    {
        [Required(ErrorMessage = "Please enter your email address")]
        [EmailAddress]
        [Display(Name = "From Email Address")]
        public string From { get; set; }
        
        [Required(ErrorMessage = "Please enter your email address")]
        [EmailAddress]
        [Display(Name = "To Email Address")]
        public string To { get; set; }

        [Required(ErrorMessage = "Subject for the message")]
        [MinLength(5)]
        [MaxLength(20)]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Dont you want to send a message?")]
        [MinLength(5)]
        [MaxLength(1024)]
        public string Body { get; set; }
    }
}
