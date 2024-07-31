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
        if (!context.Books.Find(_ => true).Any())
        {
            context.Books.InsertOne(new Book
            {
                Name = "password",
                Yazar = "testuser@example.com",
                Durum = 0
            });
        }

        // Diğer koleksiyonlar için de benzer şekilde örnek veriler ekleyebilirsiniz
    }
}
