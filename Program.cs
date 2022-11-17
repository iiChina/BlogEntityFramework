using BlogEntityFramework.Data;


using var context = new BlogDataContext();
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
// var tags = context
//             .Tags    
//             .AsNoTracking() // Esse método faz com que o EF entenda que não precisa trazer os objetos carregado com os metadados, pois não sera feito nenhuma manipulação desses objetos.
//             .ToList();

// foreach(var tag in tags)
// {
//     Console.WriteLine(tag.Name);
// }
//======================================================================================
// var user = new User {
//     Name = "Leonardo Chinarelo",
//     Slug = "leonardochinarelo",
//     Email = "leonardo.chinarelo1@gmail.com",
//     Bio = "Desenvolvedor",
//     Image = "http://site.com",
//     PasswordHash = "12345678"
// };

// var category = new Category {
//     Name = "Backend",
//     Slug = "backend"
// };

// var post = new Post {
//     /*
//         Fazendo dessa maneira, o EF consegue identificar que o Author e a Category são
//         registros que não existem dentro do banco de dados e dessa forma ele consegue
//         gerenciar de forma automática para criar esses registros antes de gerar um novo
//         Post
//     */
//     Author = user,
//     Category = category,
//     Body = "<h1>Hello World</h1>",
//     Slug = "Comacando-com-ef-core",
//     Title = "Começando com EF Core",
//     Summary = "Neste artigo vamos aprender EF Core",
//     CreateDate = DateTime.Now,
//     LastUpdateDate = DateTime.Now
// };

// context.Posts.Add(post);
// context.SaveChanges();
//======================================================================================
// var posts = context
//     .Posts
//     .AsNoTracking()
//     .Include(x => x.Author)
//     .Include(x => x.Category)
//         // .ThenInclude(x => x.Slug) Esse método serve para acessar as propriedades do subconjunto fazendo uma subselect
//     .OrderByDescending(x => x.LastUpdateDate)
//     .ToList();

// foreach(var post in posts)
    // Console.WriteLine($"{post.Title} escrito por {post.Author?.Name} em {post.Category?.Name}");
//======================================================================================
/*
    Uma maneira simples de dar um update em um registro no banco de dados.
*/
// var post = context
//     .Posts
//     // .AsNoTracking()
//     .Include(x => x.Author)
//     .Include(x => x.Category)
//         // .ThenInclude(x => x.Slug) Esse método serve para acessar as propriedades do subconjunto fazendo uma subselect
//     .OrderByDescending(x => x.LastUpdateDate)
//     .FirstOrDefault();

// post.Author.Name = "Teste";

// context.Posts.Update(post);
// context.SaveChanges();
//======================================================================================
// context.Users.Add(new User
// {
//     Bio = "Desenvolvedor",
//     Email = "leonardo.chinarelo1@gmail.com",
//     Image = "http://site.com",
//     Name = "Leonardo Chinarelo",
//     PasswordHash = "1234",
//     Slug = "leonardochinarelo"
// });

// context.SaveChanges();
//======================================================================================
// var user = context.Users.FirstOrDefault();

// var post = new Post {
//     Author = user,
//     Body = "Meu artigo",
//     Category = new Category {
//         Name = "Backend",
//         Slug = "backend"
//     }, 
//     CreateDate = DateTime.Now,
//     //LastUpdateDate
//     Slug = "meu-artigo",
//     Summary = "Neste artigo vamos conferir...",
//     Title = "Meu artigo"
// };

// context.Posts.Add(post);
// context.SaveChanges();
//======================================================================================