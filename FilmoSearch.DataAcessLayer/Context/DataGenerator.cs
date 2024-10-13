using Bogus;
using FilmoSearch.DataAcessLayer.Entities;

namespace FilmoSearch.DataAcessLayer.Context
{
    public class DataGenerator
    {
        public static readonly List<Film> Films = new();
        public static readonly List<Review> Reviews = new();
        public static readonly List<Actor> Actors = new();

        public const int NumberOfFilms = 2;

        public static void Init()
        {
            GetBogusActorsData();
            GetBogusFilmsData();

            Films.ForEach(f => GetBogusReviewsData(f.Id));
        }

        private static List<Film> GetBogusFilmsData()
        {
            var filmGenerator = GetFilmFaker();
            var generatedFilms = filmGenerator.Generate(NumberOfFilms);
            Films.AddRange(generatedFilms);
            return generatedFilms;
        }

        private static List<Review> GetBogusReviewsData(int filmId)
        {
            var reviewsGenerator = GetReviewFaker(filmId);
            var generatedReviews = reviewsGenerator.Generate(NumberOfFilms);
            Reviews.AddRange(generatedReviews);
            return generatedReviews;
        }
        private static List<Actor> GetBogusActorsData()
        {
            var actorsGenerator = GetActorFaker();
            var generatedActors = actorsGenerator.Generate(NumberOfFilms);
            Actors.AddRange(generatedActors);
            return generatedActors;
        }

        private static Faker<Actor> GetActorFaker() =>
            new Faker<Actor>()
            .RuleFor(a => a.Id, f => f.Random.Int())
            .RuleFor(a => a.FirstName, f => f.Name.FirstName())
            .RuleFor(a => a.LastName, f => f.Name.LastName())
            .RuleFor(a => a.Films, _ => []);

        private static Faker<Film> GetFilmFaker()
        {
            return new Faker<Film>()
                .RuleFor(f => f.Id, f => f.Random.Int())
                .RuleFor(f => f.Title, f => f.Commerce.ProductName())
                .RuleFor(f => f.Actors, _ => []);
        }

        private static Faker<Review> GetReviewFaker(int filmId) =>
            new Faker<Review>()
            .RuleFor(r => r.Id, f => f.Random.Int())
            .RuleFor(r => r.Title, f => f.Commerce.ProductName())
            .RuleFor(r => r.Description, f => f.Lorem.Word())
            .RuleFor(r => r.Stars, f => f.Random.Double())
            .RuleFor(r => r.FilmId, filmId);
    }
}
