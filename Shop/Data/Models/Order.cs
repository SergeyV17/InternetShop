using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Shop.Data.Models
{
    public class Order
    {
        [BindNever]
        public int Id { get; set; }

        [Display(Name = "Введите имя")]
        [StringLength(20)]
        public string FirstName { get; set; }

        [Display(Name = "Введите фамилию")]
        [StringLength(20)]
        public string  LastName { get; set; }

        [Display(Name = "Введите адрес")]
        [StringLength(20)]
        public string Address { get; set; }

        [Display(Name = "Введите номер телефона")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(20)]
        public string Phone { get; set; }

        [Display(Name = "Введите адрес электронной почты")]
        [DataType(DataType.EmailAddress)]
        [StringLength(20)]
        public string Email { get; set; }
    }
}
