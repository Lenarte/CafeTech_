using Microsoft.EntityFrameworkCore;
public static class ProdutoApi
{
    public static void MapServicoApi(this WebApplication app)
    {
        var group = app.MapGroup("/produtos");

        group.MapGet("/", async (CafeTechContext db) =>
        {
            return await db.Produtos.ToListAsync();
        });

        group.MapPost("/", async (Produto produto, CafeTechContext db) =>
        {
            db.Produtos.Add(produto);
            await db.SaveChangesAsync();
            return Results.Created($"/servicos/{produto.IdProduto}", produto);
        });

        group.MapPut("/{id}", async (int id, Produto produtoAlterado, CafeTechContext db) =>
        {
            var produto = await db.Produtos.FindAsync(id);
            if (produto == null)
            {
                return Results.NotFound();
            }

            produto.Nome = produtoAlterado.Nome;
            produto.Validade = produtoAlterado.Validade;
            produto.Preco = produtoAlterado.Preco;
            produto.Descricao = produtoAlterado.Descricao;

            await db.SaveChangesAsync();
            return Results.NoContent();
        });

        group.MapDelete("/{id}", async (int id, CafeTechContext db) =>
        {
            var produto = await db.Produtos.FindAsync(id);
            if (produto == null)
            {
                return Results.NotFound();
            }

            db.Produtos.Remove(produto);
            await db.SaveChangesAsync();
            return Results.NoContent();
        });
    }
}