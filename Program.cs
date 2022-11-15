using BlogEntityFramework.Data;
using Microsoft.EntityFrameworkCore;

using (var context = new BlogDataContext())
{
    // var tag = new Tag { Name = "Asp.Net", Slug = "aspnet" };
    // context.Tags.Add(tag);
    // context.SaveChanges();
    //======================================================================================
    /*
        Utilizando EF é necessário fazer a rehidratação de um objeto antes de um Update.

        Não é possível alterar/remover objetos usando um "new" Tag(), pois esse objeto não possui Tracking com o banco de dados.

        Dessa maneira, o EF traz metadados junto ao objeto que esta vindo do banco e consegue identificar propriedades que foram alteradas
        e as que não foram para montar querys e commands mais performáticas.
    */
    // var tag = context.Tags.FirstOrDefault(x => x.Id == 1);
    // tag.Name = ".NET";
    // tag.Slug = "dotnet";
    // context.Update(tag);
    // context.SaveChanges();
    //======================================================================================
    // var tag = context.Tags.FirstOrDefault(x => x.Id == 1);
    // context.Tags.Remove(tag);
    // context.SaveChanges();
    //======================================================================================
    /* 
        Aqui o EF ainda não executou nenhuma query no banco de dados, oq ele passou para
        a variável na verdade é apenas uma referência para a tabela.
    */
    // var tags = context.Tags;

    // foreach(var tag in tags) // Aqui a query é realmente executada.
    // {
    //     Console.WriteLine(tag.Name);
    // }
    //======================================================================================
    // var tags = context.Tags.ToList(); // O método ToList() força a execução da query.

    // foreach(var tag in tags) 
    // {
    //     Console.WriteLine(tag.Name);
    // }
    //======================================================================================
    var tags = context
                .Tags    
                .AsNoTracking() // Esse método faz com que o EF entenda que não precisa trazer os objetos carregado com os metadados, pois não sera feito nenhuma manipulação desses objetos.
                .ToList();
    
    foreach(var tag in tags)
    {
        Console.WriteLine(tag.Name);
    }
} 