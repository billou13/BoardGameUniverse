using System;
using System.ComponentModel.DataAnnotations;

namespace BGU.MarvelChampions.DeckService.Database.Entities;

public class DeckEntity
{
    [Key]
    public Guid? Guid { get; set; }

    [Required]
    public string? Name { get; set; }

    [Required]
    public DateTime? CreateDate { get; set; }

    [Required]
    public DateTime? UpdateDate { get; set; }

    public DateTime? DeleteDate { get; set; }
}
