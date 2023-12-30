using Kinogo.WebAPI.Data.Common.Config.MongoDb.Contracts;
using Kinogo.WebAPI.Data.Common.Repository;
using Kinogo.WebAPI.Domain.Genre.Entities;
using Kinogo.WebAPI.Domain.Genre.Repositories;
using MongoDB.Bson;

namespace Kinogo.WebAPI.Data.Genre.Repositories
{
    public class MongoDbGenreRespository : MongoDbBaseRepository<GenreEntity>, IGenreRepository
    {
        public MongoDbGenreRespository(IMongoDbSettings settings) : base(settings)
        {
            SeedData();
        }

        public override string CollectionName { get; set; } = "Genres";

        public void SeedData()
        {
            if (_collection.CountDocuments(new BsonDocument()) == 0)
            {
                _collection.InsertMany(genres);
            }
        }

        public List<GenreEntity> genres = new()
        {
            new GenreEntity()
            {
                Name = "Біографія"
            },
            new GenreEntity()
            {
                Name = "Бойовик"
            },
            new GenreEntity()
            {
                Name = "Вестерн"
            },
            new GenreEntity()
            {
                Name = "Воєнний"
            },
            new GenreEntity()
            {
                Name = "Детектив"
            },
            new GenreEntity()
            {
                Name = "Дитячий"
            },
            new GenreEntity()
            {
                Name = "Документальний"
            },
            new GenreEntity()
            {
                Name = "Драма"
            },
            new GenreEntity()
            {
                Name = "Історичний"
            },
            new GenreEntity()
            {
                Name = "Комедія"
            },
            new GenreEntity()
            {
                Name = "Кримінал"
            },
            new GenreEntity()
            {
                Name = "Мелодрама"
            },
            new GenreEntity()
            {
                Name = "Мультфільм"
            },
            new GenreEntity()
            {
                Name = "Мюзикл"
            },
            new GenreEntity()
            {
                Name = "Пригодницький"
            },
            new GenreEntity()
            {
                Name = "Сімейний"
            },
            new GenreEntity()
            {
                Name = "Спортивний"
            },
            new GenreEntity()
            {
                Name = "Триллер"
            },
            new GenreEntity()
            {
                Name = "Ужаси"
            },
            new GenreEntity()
            {
                Name = "Фантастика"
            },
            new GenreEntity()
            {
                Name = "Фентезі"
            },
        };
    }
}
