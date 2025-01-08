﻿using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace NZWalks.API.Models.DTO
{
    public class LoginRequestDto
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Username{ get; set; }



        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
