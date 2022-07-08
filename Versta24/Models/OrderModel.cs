using System.ComponentModel.DataAnnotations;

namespace Versta24.Models;

public class OrderModel
{
    [Required(ErrorMessage = "Город отправителя обязателен для заполнения.")]
    [Display(Name = "Город отправителя")]
    public string FromCity { get; set; }

    [Required(ErrorMessage = "Адрес отправителя обязателен для заполнения.")]
    [Display(Name = "Адрес отправителя")]
    public string FromAddress { get; set; }

    [Required(ErrorMessage = "Город получателя обязателен для заполнения.")]
    [Display(Name = "Город получателя")]
    public string ToCity { get; set; }

    [Required(ErrorMessage = "Адрес получателя обязателен для заполнения.")]
    [Display(Name = "Адрес получателя")]
    public string ToAddress { get; set; }

    [Required(ErrorMessage = "Вес груза обязателен для заполнения.")]
    [Display(Name = "Вес груза")]
    public long CargoWeight { get; set; }

    [Required(ErrorMessage = "Дата забора груза обязателен для заполнения.")]
    [Display(Name = "Дата забора")]
    public string DatePickupCargo { get; set; }

    [Key]
    public long IdCargo { get; set; }
}