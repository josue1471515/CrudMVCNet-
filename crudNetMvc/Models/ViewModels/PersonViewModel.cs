using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace crudNetMvc.Models.ViewModels
{
    public class PersonViewModel
    {
        public int PersonID { get; set; }
        [Required]
        [Display(Name = "Apellido")]
        [StringLength(20)]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Nombres")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Direccion")]
        public string Address { get; set; }
        [Required]
        [Display(Name = "Ciudad")]
        public string City { get; set; }
    }
}