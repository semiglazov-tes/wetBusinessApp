﻿using System.ComponentModel.DataAnnotations.Schema;



namespace WetBusinessApp.Infrastructure.DB.Entity
{
    [Table("Users")]
    public class UserEntity
    {
        [Column("Id")]
        public Guid Id { get;  set; }

        [Column("Name")]
        public string? UserName { get; set; }

        [Column("Email")]
        public string? UserEmail { get; set; }

        [Column("Password")]
        public string? PasswordHash { get; set; }
    }
}