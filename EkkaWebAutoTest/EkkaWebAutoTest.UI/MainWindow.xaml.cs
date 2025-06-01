using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EkkaWebAutoTest.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Views.LoginView loginView = new();
        private readonly Views.SignUpView signUpView = new();
        private readonly Views.LogoutView logoutView = new();
        private readonly Views.AccountView accountView = new();
        private readonly Views.ProductView productView = new();
        private readonly Views.CartView cartView = new();
        private readonly Views.OrderView orderView = new();
        private readonly Views.ProductSearchView productSearchView = new();
        private readonly Views.OrderHistoryView orderHistoryView = new();
        private readonly Views.ReportView reportView = new();

        public MainWindow()
        {
            InitializeComponent();
        }
        private void Menu_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            var tag = btn?.Tag?.ToString();

            UserControl content = tag switch
            {
                "LoginView" => new Views.LoginView(),
                "SignUpView" => new Views.SignUpView(),
                "LogoutView" => new Views.LogoutView(),
                "AccountView" => new Views.AccountView(),
                "ProductView" => new Views.ProductView(),
                "CartView" => new Views.CartView(),
                "OrderView" => new Views.OrderView(),
                "ProductSearchView" => new Views.ProductSearchView(),
                "OrderHistoryView" => new Views.OrderHistoryView(),
                "ReportView" => new Views.ReportView(),
                _ => null
            };

            MainContent.Content = content;
        }
    }
}