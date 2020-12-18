using System;

namespace ModelsLibrary
{
    public class PagedResult<T>
    {
        public int PageCount;
        public T[] Page;
    }
}
