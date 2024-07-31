using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

using BookLibary.Api.Data.Context;
using BookLibary.Api.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        var context = serviceProvider.GetRequiredService<MongoDbContext>();

        // Örnek kullanıcı verisi ekleyerek Users koleksiyonunu oluşturun
        if (!context.Users.Find(_ => true).Any())
        {
            context.Users.InsertOne(new User
            {
                UserName = "alperen",
                FullName = "alperen akal",
                Password = "12345",
                Email = "alperen@gmail.com"
            });
        }

        // Diğer koleksiyonlar için de benzer şekilde örnek veriler ekleyebilirsiniz
    }
}
