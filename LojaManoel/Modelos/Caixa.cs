namespace LojaManoel.Modelos
{
    public class Caixa
    {
        public string Caixa_Id { get; set; } // Identificador de la caja
        public int Altura { get; set; }     // Altura de la caja en cm
        public int Largura { get; set; }    // Largura de la caja en cm
        public int Comprimento { get; set; }// Comprimento de la caja en cm
        public List<string> Produtos { get; set; } // Lista de productos en la caja
        public string Observacao { get; set; } // Observación (opcional)
    }
}
