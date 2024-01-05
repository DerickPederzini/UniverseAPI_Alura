﻿using System.ComponentModel.DataAnnotations;

namespace API.Models;

public class Telescope
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "O campo de nome é obrigatório")]
    public string Name { get; set; }

    public int AddressId { get; set; }

    public virtual Address address { get; set; }
}
