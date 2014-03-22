using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HistoryOfIdeas.DAL.Entity.Interface;

namespace HistoryOfIdeas.DAL.Entity
{
    public class User: IEntity
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        
        public string Surname { get; set; }
        
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        
        [Required]
        public string Password { get; set; }


        public virtual ICollection<Idea> Ideas { get; set; }
    
    }

    public class UserAuth
    {
        [EmailAddress]
        [Required(ErrorMessage = "*")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "*")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }

    public class UserReg
    {
        [Required(ErrorMessage = "*")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Surname")]
        public string Surname { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "*")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "*")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Confirm password")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }

}
