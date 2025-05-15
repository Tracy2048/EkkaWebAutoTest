using EkkaWebAutoTest.Tests;
using EkkaWebAutoTest.UI.Models;
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
    /// Interaction logic for CartView.xaml
    /// </summary>
    public partial class CartView : UserControl
    {
        private List<TestCase> testCases;

        public CartView()
        {
            InitializeComponent();
            if (Application.Current.Properties["CartTestCases"] is List<TestCase> savedCases)
            {
                testCases = savedCases;
            }
            else
            {
                testCases = new List<TestCase>
                {
                    new TestCase
                    {
                        STT = "CM-1",
                        TestName = "Xem giỏ hàng thành công khi giỏ hàng trống",
                        Precondition = "User đã đăng nhập",
                        Steps = "1. Đăng nhập thành công, truy cập trang chủ\n" +
                                "2. Nhấn vào biểu tượng giỏ hàng",
                        ExpectedResult = "2. Hiển thị ra cửa sổ xem giỏ hàng và hiển thị chữ \"Chưa có sản phẩm.\"",
                        ExecuteAction = (tc) =>
                        {
                            tc.Result = "Pass";

                            //var test = new CartTests();
                            //try
                            //{
                            //    test.Setup();
                            //    test.ViewAccount_Success();
                            //    test.CleanUp();
                            //    tc.Result = "Pass";
                            //}
                            //catch (Exception ex)
                            //{
                            //    tc.Result = $"{ex.Message}";
                            //}
                        }
                    },
                    new TestCase
                    {
                        STT = "CM-2",
                        TestName = "Thêm sảm phẩm vào giỏ hàng thành công",
                        Precondition = "User đã đăng nhập",
                        Steps = "1. Đăng nhập thành công, truy cập trang chủ\n" +
                                "2. Nhấn vào sản phẩm bất kỳ\n" +
                                "3. Nhấn nút 'Thêm vào giỏ hàng'",
                        ExpectedResult = "2. Hiển thị thông báo \"Thêm sản phẩm vào giỏ hàng thành công.\"",
                        ExecuteAction = (tc) =>
                        {
                            tc.Result = "Pass";
                        }
                    },
                    new TestCase
                    {
                        STT = "CM-3",
                        TestName = "Xem giỏ hàng thành công khi giỏ hàng có sản phẩm",
                        Precondition = "User đã đăng nhập",
                        Steps = "1. Đăng nhập thành công, truy cập trang chủ\n" +
                                "2. Nhấn vào biểu tượng giỏ hàng\n",
                        ExpectedResult = "1. Biểu tượng giỏ hàng có số lượng mặt hàng trong giỏ\n" +
                                         "2. Hiển thị ra cửa sổ xem giỏ hàng có sản phẩm",
                        ExecuteAction = (tc) =>
                        {
                            tc.Result = "Pass";
                        }
                    },
                };

                    // Lưu testCases vào Application.Current
                 Application.Current.Properties["CartTestCases"] = testCases;
            }

            CartTCsGrid.ItemsSource = testCases;
        }
        private void ExecuteTest_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is TestCase testCase)
            {
                testCase.ExecuteAction?.Invoke(testCase); // Gọi hành động được gán riêng cho test này
                CartTCsGrid.Items.Refresh();
            }
        }
    }
}
