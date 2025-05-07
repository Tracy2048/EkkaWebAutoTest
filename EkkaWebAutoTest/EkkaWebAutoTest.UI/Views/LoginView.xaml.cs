using EkkaWebAutoTest.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EkkaWebAutoTest.UI.Views
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : UserControl
    {
        public LoginView()
        {
            InitializeComponent();
        }
        private void RunTest_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var test = new LoginTests();
                test.Setup(); // Gọi NUnit setup trực tiếp
                test.Login_Success(); // Gọi NUnit test trực tiếp
                test.CleanUp(); // Gọi NUnit teardown trực tiếp
                ResultText.Text = "✅ Đăng nhập thành công";
            }
            catch (Exception ex)
            {
                ResultText.Text = $"❌ Thất bại: {ex.Message}";
            }
        }
    }
}
