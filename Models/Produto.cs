using System.ComponentModel.DataAnnotations;

namespace LojaMVC.Models
{
    public class Produto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        [StringLength(100)]
        [Display(Name = "Nome do Produto")]
        public string Nome { get; set; } = string.Empty;

        [StringLength(500)]
        [Display(Name = "Descrição")]
        public string? Descricao { get; set; }

        [Required(ErrorMessage = "O preço é obrigatório")]
        [Range(0.01, 999999.99, ErrorMessage = "Informe um preço válido")]
        [DataType(DataType.Currency)]
        [Display(Name = "Preço")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "A categoria é obrigatória")]
        [StringLength(50)]
        [Display(Name = "Categoria")]
        public string Categoria { get; set; } = string.Empty;

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Estoque não pode ser negativo")]
        [Display(Name = "Quantidade em Estoque")]
        public int Estoque { get; set; }

        [Display(Name = "URL da Imagem")]
        [StringLength(300)]
        public string? ImagemUrl { get; set; }

        [Display(Name = "Data de Cadastro")]
        public DateTime DataCadastro { get; set; } = DateTime.Now;
    }
}