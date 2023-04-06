using DTOs;

namespace UseCases
{
    public abstract class AbstractPresenter
    {

        public DTO DataToPresent { get; set; }

        public abstract ViewData ViewData { get; }
    }
}
