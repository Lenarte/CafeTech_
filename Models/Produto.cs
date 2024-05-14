using System.ComponentModel.DataAnnotations;
public class Produto
{
    [Key]
    public int IdProduto { get; set; }
    public string? Nome { get; set; }
    public int Validade { get; set; }
    public decimal Preco { get; set; }
    public string? Descricao { get; set; }

    public override string ToString()
    {
        return $"Id: {IdProduto}, Nome: {Nome}, Preço: {Preco}, Duração: {Validade}";
    }
}
