using GigHub.Core.Models;
using System.Collections.Generic;

namespace GigHub.Core.Repositories
{
    public interface IGenreRepository
    {
        List<Genre> GetGenres();
    }
}