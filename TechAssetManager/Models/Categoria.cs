using System.ComponentModel.DataAnnotations;

namespace TechAssetManager.Models;

public class Categoria
{
    public int Id { get; set; }

    [Required(ErrorMessage = "O nome da categoria é obrigatório.")]
    [StringLength(50)]
    public string? Nome { get; set; }

    [Display(Name = "Descrição")]
    public string? Descricao { get; set; }

    public ICollection<Ativo>? Ativos { get; set; }
}
