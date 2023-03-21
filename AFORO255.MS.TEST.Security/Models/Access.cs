﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AFORO255.MS.TEST.Security.Models;

public class Access
{
    [Key]
    [Column("id_user")]
    public int? UserId { get; set; }
    [Column("username")]
    public string? Username { get; set; }
    [Column("password")]
    public string? Password { get; set; }

}
