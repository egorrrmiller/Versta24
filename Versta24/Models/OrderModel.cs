using System.ComponentModel.DataAnnotations;

namespace Versta24.Models;

public class OrderModel
{
    [Required(ErrorMessage = "Город отправителя обязателен для заполнения.")]
    public string FromCity { get; set; }
    
    [Required(ErrorMessage = "Адрес отправителя обязателен для заполнения.")]
    public string FromAddress { get; set; }
    
    [Required(ErrorMessage = "Город получателя обязателен для заполнения.")]
    public string ToCity { get; set; }
    
    [Required(ErrorMessage = "Город получателя обязателен для заполнения.")]
    public string ToAddress { get; set; }
    
    [Required(ErrorMessage = "Вес груза обязателен для заполнения.")]
    public long CargoWeight { get; set; }
    
    [Required(ErrorMessage = "Дата забора груза обязателен для заполнения.")]
    public string DatePickupCargo { get; set; }

    [Key]
    public long IdCargo { get; set; }
}