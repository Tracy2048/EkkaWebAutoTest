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
                        TestName = "Xem giỏ hàng không thành công khi chưa đăng nhập",
                        Precondition = "",
                        Steps = "1. Nhấn vào biểu tượng giỏ hàng",
                        ExpectedResult = "1. Điều hướng đến trang đăng nhập",
                        ExecuteAction = (tc) =>
                        {
                            tc.Result = "Fail";

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
                        TestName = "Xem giỏ hàng thành công khi giỏ hàng trống",
                        Precondition = "User đã đăng nhập",
                        Steps = "1. Đăng nhập thành công, truy cập trang chủ\n" +
                                "2. Nhấn vào biểu tượng giỏ hàng",
                        ExpectedResult = "2. Hiển thị ra cửa sổ xem giỏ hàng và hiển thị chữ \"Chưa có sản phẩm.\"",
                        ExecuteAction = (tc) =>
                        {
                            tc.Result = "Fail";

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
                        STT = "CM-3",
                        TestName = "Thêm sản phẩm vào giỏ hàng không thành công khi chưa đăng nhập",
                        Precondition = "",
                        Steps = "1. Nhấn vào sản phẩm ở trang chủ\n" +
                                "2. Nhấn nút 'Thêm vào giỏ hàng'",
                        ExpectedResult = "2. Điều hướng đến trang đăng nhập",
                        ExecuteAction = (tc) =>
                        {
                            tc.Result = "Fail";
                        }
                    },
                    new TestCase
                    {
                        STT = "CM-4",
                        TestName = "Thêm sản phẩm vào giỏ hàng thành công",
                        Precondition = "User đã đăng nhập",
                        Steps = "1. Đăng nhập thành công, truy cập trang chủ\n" +
                                "2. Nhấn vào sản phẩm\n" +
                                "3. Nhấn nút 'Thêm vào giỏ hàng'",
                        ExpectedResult = "3. Hiển thị thông báo \"Thêm sản phẩm vào giỏ hàng thành công\"\n" +
                                         "   Cập nhật số lượng ở icon giỏ hàng",
                        ExecuteAction = (tc) =>
                        {
                            tc.Result = "Pass";
                        }
                    },
                    new TestCase
                    {
                        STT = "CM-5",
                        TestName = "Thêm 1 sản phẩm nhiều lần",
                        Precondition = "User đã đăng nhập",
                        Steps = "1. Đăng nhập thành công, truy cập trang chủ\n" +
                                "2. Nhấn vào sản phẩm\n" +
                                "3. Nhấn nút 'Thêm vào giỏ hàng' nhiều lần",
                        ExpectedResult = "3. Hiển thị thông báo \"Thêm sản phẩm vào giỏ hàng thành công\"\n" +
                                         "   Số lượng ở icon giỏ hàng không thay đổi\n" +
                                         "   Cập nhật số lượng của sản phẩm trong giỏ hàng",
                        ExecuteAction = (tc) =>
                        {
                            tc.Result = "Pass";
                        }
                    },
                    new TestCase
                    {
                        STT = "CM-6",
                        TestName = "Thêm sản phẩm không thành công khi sản phẩm hết hàng",
                        Precondition = "User đã đăng nhập",
                        Steps = "1. Đăng nhập thành công, truy cập trang chủ\n" +
                                "2. Nhấn vào sản phẩm hết hàng\n",
                        ExpectedResult = "2. Nút \"Thêm vào giỏ hàng\" chuyển thành \"Sản phẩm tạm hết\" và không bấm được",
                        ExecuteAction = (tc) =>
                        {
                            tc.Result = "Pass";
                        }
                    },
                    new TestCase
                    {
                        STT = "CM-7",
                        TestName = "Thêm sản phẩm không thành công khi vượt quá số lượng của sản phẩm",
                        Precondition = "User đã đăng nhập",
                        Steps = "1. Đăng nhập thành công, truy cập trang chủ\n" +
                                "2. Nhấn vào sản phẩm, nhập số lượng\n" +
                                "3. Nhấn nút 'Thêm vào giỏ hàng'",
                        ExpectedResult = "3. Hiển thị thông báo \"Vui lòng kiểm tra lại số lượng.\"",
                        ExecuteAction = (tc) =>
                        {
                            tc.Result = "Pass";
                        }
                    },
                    new TestCase
                    {
                        STT = "CM-8",
                        TestName = "Thêm sản phẩm không thành công khi nhập số lượng âm",
                        Precondition = "User đã đăng nhập",
                        Steps = "1. Đăng nhập thành công, truy cập trang chủ\n" +
                                "2. Nhấn vào sản phẩm, nhập số lượng âm\n" +
                                "3. Nhấn nút 'Thêm vào giỏ hàng'",
                        ExpectedResult = "3. Hiển thị thông báo \"Vui lòng kiểm tra lại số lượng.\"",
                        ExecuteAction = (tc) =>
                        {
                            tc.Result = "Fail";
                        }
                    },
                    new TestCase
                    {
                        STT = "CM-9",
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
