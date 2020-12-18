using System;
using ModelsLibrary;

namespace Interfaces
{

    public interface IComics
    {
        PagedResult<ComicsModel> ComicsGetById(int id);

        PagedResult<ComicsModel> ComicsGetAll();

        PagedResult<ComicsModel> ComicsGetByPageAndPagecount(int page, int pagecount);
    }
}
