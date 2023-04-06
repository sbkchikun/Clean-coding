using DTOs;
using System.Collections.Generic;
using UseCases;

namespace CommandLineUI.Presenters
{
    class InventoryReportPresenter : AbstractPresenter
    {

        public override ViewData ViewData
        {
            get
            {
                List<ItemDTO> items = ((ItemDTO_List)DataToPresent).List;
                List<string> lines = new List<string>(items.Count + 2);
                lines.Add("\nAll Items");
                lines.Add(string.Format("\t{0, -4} {1, -20} {2, -20}", "ID", "Name", "Quantity"));

                items.ForEach(i => lines.Add(DisplayItem(i)));

                return new CommandLineViewData(lines);
            }
        }

        private string DisplayItem(ItemDTO i)
        {
            return string.Format(
                "\t{0, -4} {1, -20} {2, -20}",
                i.Id,
                i.ItemName,
                i.QTY
                );
        }
    }
}
