﻿using API_SITE_Mulher.Model.Domain;
using API_SITE_Mulher.Repository.Implementations;

namespace API_SITE_Mulher.Repository
{
    public interface IPosteresRepository : IRepository<tb_poster> 
    {
        List<tb_poster> FindPostersByTitle(string title);
        List<tb_poster> FindWithPagedSearchPosteres(string query);
        tb_poster CreatePoster(tb_poster poster);
    }
}
