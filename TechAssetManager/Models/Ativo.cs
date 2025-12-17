using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechAssetManager.Models;

public class Ativo
{
    public int Id { get; set; }

    [Required(ErrorMessage = "O nome do modelo/ativo é obrigatório.")]
    [StringLength(100)]
    public string? Nome { get; set; }

    [Required(ErrorMessage = "O número de série é obrigatório.")]
    [Display(Name = "Número de Série")]
    public string? NumeroSerie { get; set; }

    [DataType(DataType.Date)]
    [Display(Name = "Data de Aquisição")]
    public DateTime DataAquisicao { get; set; }

    [Required(ErrorMessage = "O valor é obrigatório.")]
    [Display(Name = "Valor (R$)")]
    [Column(TypeName = "decimal(18,2)")]
    public decimal Valor { get; set; }


    [Display(Name = "Categoria")]
    public int CategoriaId { get; set; }


    public Categoria? Categoria { get; set; }
}
