using DTOs;
using System.Collections.Generic;
using UseCase;
namespace Presenters
{
    class AllBooksPresenterWPF : AbstractPresenter
    {

        public override IViewData ViewData
        {
            get
            {
                List<BookDTO> books = ((BookDTO_List)DataToPresent).List;
                List<BookDTO> bookDataList = new List<BookDTO>();
                foreach (var book in books) 
                {
                    BookDTO BookData = new BookDTO(book.Id, book.Author, book.ISBN, book.Title, book.State);
                    

                    bookDataList.Add(BookData);
                }

                return new WPFViewData<BookDTO>(bookDataList);
            }
        }

        //private string DisplayBook(BookDTO b)
        //{
        //    return string.Format(
        //        "\t{0, -4} {1, -20} {2, -20} {3, -15} {4}",
        //        b.Id,
        //        b.Title,
        //        b.Author,
        //        b.ISBN,
        //        b.State);
        //}
    }
}
