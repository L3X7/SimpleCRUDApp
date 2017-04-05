using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace SimpleCRUDApp.Models.ViewModels
{
    public class UsersViewModel
    {
        public long IdUser { get; set; }
        [Required(ErrorMessage = "Name required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Last Name required")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Address required")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Email required")]
        [EmailAddress(ErrorMessage = "Write a email valid")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Phone required")]
        public string Phone { get; set; }
    }

}