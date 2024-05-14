using System.ComponentModel.DataAnnotations;
public class Funcionario
{
    [Key]
    public int IdFuncionario { get; set; }
    public string? Nome { get; set; }
    public string? CPF { get; set; }
    public string? Cargo { get; set; }
    public string? Telefone { get; set; }
    public DateTime DataAdmissao { get; set; }

    public override string ToString()
    {
        return $"Id: {IdFuncionario}, Nome: {Nome}, Cargo: {Cargo}, Telefone: {Telefone}";
    }

    
}
