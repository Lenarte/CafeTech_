using Microsoft.EntityFrameworkCore;
public static class FuncionarioApi
{
    public static void MapFuncionarioApi(this WebApplication app)
    {
        var group = app.MapGroup("/funcionarios");

        group.MapGet("/", async (CafeTechContext db) =>
        {
            return await db.Funcionarios.ToListAsync();
        });

        group.MapPost("/", async (Funcionario funcionario, CafeTechContext db) =>
        {
            db.Funcionarios.Add(funcionario);
            await db.SaveChangesAsync();
            return Results.Created($"/funcionarios/{funcionario.IdFuncionario}", funcionario);
        });

        group.MapPut("/{id}", async (int id, Funcionario funcionarioAlterado, CafeTechContext db) =>
        {
            var funcionario = await db.Funcionarios.FindAsync(id);
            if (funcionario == null)
            {
                return Results.NotFound();
            }

            funcionario.Nome = funcionarioAlterado.Nome;
            funcionario.CPF = funcionarioAlterado.CPF;
            funcionario.Cargo = funcionarioAlterado.Cargo;
            funcionario.Telefone = funcionarioAlterado.Telefone;
            funcionario.DataAdmissao = funcionarioAlterado.DataAdmissao;

            await db.SaveChangesAsync();
            return Results.NoContent();
        });

        group.MapDelete("/{id}", async (int id, CafeTechContext db) =>
        {
            var funcionario = await db.Funcionarios.FindAsync(id);
            if (funcionario == null)
            {
                return Results.NotFound();
            }

            db.Funcionarios.Remove(funcionario);
            await db.SaveChangesAsync();
            return Results.NoContent();
        });
    }
}