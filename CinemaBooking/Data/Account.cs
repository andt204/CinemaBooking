using CinemaBooking.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CinemaBooking.Data
{
    public partial class Account
    {
        public Account()
        {
            Comments = new HashSet<Comment>();
            Posts = new HashSet<Post>();
            Tickets = new HashSet<Ticket>();
            Votes = new HashSet<Vote>();
        }

        public int AccountId { get; set; }
        [Required(ErrorMessage = "Customer Name is required")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "The length of name is from 3 to 20 characters")]
        [Display(Name = "Customer Name")]
        public string FullName { get; set; } = null!;

        public string? Avatar { get; set; }
        [Required(ErrorMessage = "Customer Gender is required")]
        [Display(Name = "Customer Gender")]
        public string Gender { get; set; } = null!;
        [CustomValidation(typeof(PhoneValitdation), nameof(PhoneValitdation.ValidatePhone))]
        [Display(Name = "Customer Phone")]

        public string? PhoneNumber { get; set; }
        [Required(ErrorMessage = "Date of Birth is required")]
        [Display(Name = "Date Of birth")]
        [CustomValidation(typeof(AgeValidation), nameof(AgeValidation.ValidateAge))]
        public DateTime? DateOfBirth { get; set; }
        [CustomValidation(typeof(EmailValidation), nameof(EmailValidation.ValidateEmail))]
        [Display(Name = "Email")]
        public string Email { get; set; } = null!;

        [CustomValidation(typeof(PasswordValidation), nameof(PasswordValidation.ValidatePassword))]
        public string Password { get; set; } = null!;
        public byte Status { get; set; }
        public int RoleId { get; set; }

        public virtual Role Role { get; set; } = null!;
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
        public virtual ICollection<Vote> Votes { get; set; }
    }
}