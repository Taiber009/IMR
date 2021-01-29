using System;
using System.Collections.Generic;
using ModelsLibrary;

namespace Interfaces
{

    public interface IComicsService
    {
        List<ComicsModel> ComicsGetById(int id);

        List<ComicsModel> ComicsGetAll();

        ///PagedResult<ComicsModel> ComicsGetByPageAndPagecount(int page, int pagecount);
    }
}
