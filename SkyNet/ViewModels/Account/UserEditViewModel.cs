using System;
using System.ComponentModel.DataAnnotations;

namespace SkyNet.ViewModels.Account;

public class UserEditViewModel
{
    [Required(ErrorMessage = "Поле обязательно для заполнения")]
    [Display(Name = "Идентификатор пользователя")]
    public string UserId { get; set; }

    [Required(ErrorMessage = "Поле обязательно для заполнения")]
    [DataType(DataType.Text)]
    [Display(Name = "Имя", Prompt = "Введите имя")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Поле обязательно для заполнения")]
    [DataType(DataType.Text)]
    [Display(Name = "Фамилия", Prompt = "Введите фамилию")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "Поле обязательно для заполнения")]
    [DataType(DataType.Text)]
    [Display(Name = "Отчество", Prompt = "Введите отчество")]
    public string MiddleName { get; set; }

    [Required(ErrorMessage = "Поле обязательно для заполнения")]
    [DataType(DataType.Date)]
    [Display(Name = "Дата рождения")]
    public DateTime BirthDate { get; set; }

    [Required(ErrorMessage = "Поле обязательно для заполнения")]
    [EmailAddress]
    [Display(Name = "Email", Prompt = "example.com")]
    public string Email { get; set; }

    public string UserName => Email;

    [DataType(DataType.ImageUrl)]
    [Display(Name = "Фото", Prompt = "Укажите ссылку на картинку")]
    public string Image { get; set; }

    [DataType(DataType.Text)]
    [Display(Name = "Статус", Prompt = "Введите статус")]
    public string Status { get; set; }

    [DataType(DataType.Text)]
    [Display(Name = "О себе", Prompt = "Введите данные о себе")]
    public string About { get; set; }
}