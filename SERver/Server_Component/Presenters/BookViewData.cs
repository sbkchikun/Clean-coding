using System.Collections.Generic;
using UseCase;
using DTOs;
namespace  Presenters
{
    class BookViewData : IViewData
    {
        public List<BookDTO> ViewData { get; }

        public BookViewData(List<BookDTO> viewData)
        {
            ViewData = viewData;
        }
    }
}
