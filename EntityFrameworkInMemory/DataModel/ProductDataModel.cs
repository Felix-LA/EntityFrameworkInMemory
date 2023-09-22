using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkInMemory.DataModel
{
    public class ProductDataModel
    {
        [Key]

        //váriavel do tipo Guid para o id, o guid cria uma chave de caracteres aleatórias
        public Guid Id { get; set; }

        //váriavel do tipo sring para o nome, o tipo string é um aglomerado de letras, permite textos
        public string Name { get; set; }    

        //váriavel do tipo sring para a categoria, o tipo string é um aglomerado de letras, permite textos
        public string Category { get; set; }

        //Váriavel do tipo float para o preço, o tipo float permite números quebrados
        public float Price { get; set; }
    }
}
