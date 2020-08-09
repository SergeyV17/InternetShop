using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Shop.Data.Models.Interfaces;

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

        public IEnumerable<OrderDetail> OrderDetails { get; set; }

        public decimal Value { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime OrderDateTime { get; set; }

        [NotMapped]
        public IShippingMethod ShippingMethod { get; set; }
    }
}
