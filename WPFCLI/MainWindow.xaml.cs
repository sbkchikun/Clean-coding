
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Windows.Commands;
using Windows;


namespace WPF_Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CommandFactory factory = new CommandFactory();
        private MyWPFClient client;
        private Task clientTask;
        private bool MemberIdValidation;
        private bool BookIdValidation;
        public MainWindow()
        {
            
            
            InitializeComponent();
            client = new MyWPFClient(ConsoleBox);
            clientTask = Task.Run(client.Run);
            MemberIdValidation = false;
            BookIdValidation = false;
        }

        private void BorrowButton_Click(object sender, RoutedEventArgs e)
        {
            
            int memberId = int.Parse(MemberIdTextBox.Text);
            int bookId =int.Parse(BookIdTextBox.Text);

            client.AddCommand(factory
                   .CreateCommand(RequestUseCase.BORROW_BOOK, memberId, bookId)
                   .Execute());
            
        }
        
        private void ReturnButton_Click(object sender, RoutedEventArgs e)
        {
            int memberId = int.Parse(MemberIdTextBox.Text);
            int bookId = int.Parse(BookIdTextBox.Text);
            client.AddCommand(factory
                   .CreateCommand(RequestUseCase.RETURN_BOOK, memberId, bookId)
                   .Execute());
        }

        private void RenewButton_Click(object sender, RoutedEventArgs e)
        {
            int memberId = int.Parse(MemberIdTextBox.Text);
            int bookId = int.Parse(BookIdTextBox.Text);
            client.AddCommand(factory.CreateCommand(RequestUseCase.RENEW_LOAN, memberId, bookId).Execute());
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ViewcurrentloansButton_Click(object sender, RoutedEventArgs e)
        {
            client.AddCommand(factory.CreateCommand(RequestUseCase.VIEW_CURRENT_LOANS,0,0).Execute());
        }

        private void ViewallmembersButton_Click(object sender, RoutedEventArgs e)
        {
            
            client.AddCommand(factory.CreateCommand(RequestUseCase.VIEW_ALL_MEMBERS, 0, 0).Execute());
        }

        private void ViewallbooksButton_Click(object sender, RoutedEventArgs e)
        {
            
            client.AddCommand(factory.CreateCommand(RequestUseCase.VIEW_ALL_BOOKS, 0, 0).Execute());
        }

        private void ConsoleBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void validatebuttons() 
        {
            if (BookIdValidation == true && MemberIdValidation == true) { 
                ReturnButton.IsEnabled=true;
                BorrowButton.IsEnabled = true;
                RenewButton.IsEnabled = true;

            }
            else
            {
                ReturnButton.IsEnabled = false;
                BorrowButton.IsEnabled = false;
                RenewButton.IsEnabled = false;

            }
        }
        private void Rapid_requests(object sender, RoutedEventArgs e)
        {
            client.RapidRequests();
        }

        private void MemberIdTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            int i;
            MemberIdValidation = int.TryParse(MemberIdTextBox.Text,out i);
            validatebuttons();
        }

        private void BookIdTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            int i;
            BookIdValidation = int.TryParse(BookIdTextBox.Text, out i);
            validatebuttons();
        }
    }
}
