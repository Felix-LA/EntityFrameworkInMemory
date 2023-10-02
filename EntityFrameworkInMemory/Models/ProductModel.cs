using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkInMemory.Models
{
    public class ProductModel
    {
        [Key]

        //váriavel do tipo Guid para o id, o guid cria uma chave de caracteres aleatórias
        public Guid ProductId { get; set; }

        //váriavel do tipo sring para o nome, o tipo string é um aglomerado de letras, permite textos
        public string ProductName { get; set; }

        //váriavel do tipo sring para a categoria, o tipo string é um aglomerado de letras, permite textos
        public CategoryModel ProductCategory { get; set; }

        //Váriavel do tipo float para o preço, o tipo float permite números quebrados
        public float ProductPrice { get; set; }

        //Variavel do tipo int para o codigo, o tipo int gera numeros inteniros
        public int ProductCodigo { get; set; }
        
    }
}
