namespace CommandLineUI.Menu
{
    class MenuFactory
    {
        public static MenuFactory INSTANCE { get; } = new MenuFactory();

        private Menu menu;

        private MenuFactory()
        {
            menu = CreateMenu();
        }

        public MenuElement Create()
        {
            return menu;
        }

        

        private Menu CreateMenu()
        {
            Menu menu = new Menu("Options");
            menu.Add(new MenuItem(RequestUseCase.ADD_ITEM_TO_STOCK, "Add item to stock"));
            menu.Add(new MenuItem(RequestUseCase.ADD_QUANTITY_TO_ITEM, "Add quantity to item"));
            menu.Add(new MenuItem(RequestUseCase.TAKE_QUANTITY_FROM_ITEM, "Take quantity from item"));
            menu.Add(new MenuItem(RequestUseCase.VIEW_INVENTORY_REPORT, "View inventory report"));
            menu.Add(new MenuItem(RequestUseCase.VIEW_FINANCIAL_REPORT, "View transaction log"));
            menu.Add(new MenuItem(RequestUseCase.VIEW_TRANSACTION_LOG, "View Financial report"));
            menu.Add(new MenuItem(RequestUseCase.VIEW_PERSONAL_USAGE_REPORT, "View personal usage report"));
            menu.Add(new MenuItem(RequestUseCase.EXIT, "Exit"));
            return menu;
        }
    }
}
