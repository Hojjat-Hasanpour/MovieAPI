using Microsoft.EntityFrameworkCore;
using MovieAPI.Data;

namespace MovieAPI.Endpoints
{
    public static class GenresEndpoints
    {
        public static RouteGroupBuilder MapGenresEndpoints(this WebApplication app)
        {
            var group = app.MapGroup("genres").WithParameterValidation();
            group.MapGet("/", async (MovieContext movieContext) => await movieContext.Genres.ToListAsync());
            return group;
        }
    }
}
