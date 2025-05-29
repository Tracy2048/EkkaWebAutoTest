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
                            var test = new CartTests();
                            try
                            {
                                test.Setup();
                                test.Cart_Without_Login();
                                test.CleanUp();
                                tc.Result = "Pass";
                            }
                            catch (Exception ex)
                            {
                                tc.Result = "Fail";
                                test.CleanUp();
                            }
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
                            var test = new CartTests();
                            try
                            {
                                test.Setup();
                                test.Cart_Empty();
                                test.CleanUp();
                                tc.Result = "Pass";
                            }
                            catch (Exception ex)
                            {
                                tc.Result = "Fail";
                                test.CleanUp();
                            }
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
                            var test = new CartTests();
                            try
                            {
                                test.Setup();
                                test.AddProduct_Without_Login();
                                test.CleanUp();
                                tc.Result = "Pass";
                            }
                            catch (Exception ex)
                            {
                                tc.Result = "Fail";
                                test.CleanUp();
                            }
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
                            var test = new CartTests();
                            try
                            {
                                test.Setup();
                                test.AddProduct_After_Login();
                                test.CleanUp();
                                tc.Result = "Pass";
                            }
                            catch (Exception ex)
                            {
                                tc.Result = "Fail";
                                test.CleanUp();
                            }
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
                            var test = new CartTests();
                            try
                            {
                                test.Setup();
                                test.AddProduct_Duplicate();
                                test.CleanUp();
                                tc.Result = "Pass";
                            }
                            catch (Exception ex)
                            {
                                tc.Result = "Fail";
                                test.CleanUp();
                            }
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
                            var test = new CartTests();
                            try
                            {
                                test.Setup();
                                test.AddProduct_OutStock();
                                test.CleanUp();
                                tc.Result = "Pass";
                            }
                            catch (Exception ex)
                            {
                                tc.Result = "Pass";
                                test.CleanUp();
                            }
                        }
                    },
                    new TestCase
                    {
                        STT = "CM-7",
                        TestName = "Thêm sản phẩm không thành công khi vượt quá số lượng tồn kho",
                        Precondition = "User đã đăng nhập",
                        Steps = "1. Đăng nhập thành công, truy cập trang chủ\n" +
                                "2. Nhấn vào sản phẩm, nhập số lượng\n" +
                                "3. Nhấn nút 'Thêm vào giỏ hàng'",
                        ExpectedResult = "3. Hiển thị thông báo \"Vui lòng kiểm tra lại số lượng.\"",
                        ExecuteAction = (tc) =>
                        {
                            var test = new CartTests();
                            try
                            {
                                test.Setup();
                                test.AddProduct_OverStock();
                                test.CleanUp();
                                tc.Result = "Pass";
                            }
                            catch (Exception ex)
                            {
                                tc.Result = "Fail";
                                test.CleanUp();
                            }
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
                            var test = new CartTests();
                            try
                            {
                                test.Setup();
                                test.AddProduct_NegativeQuantity();
                                test.CleanUp();
                                tc.Result = "Pass";
                            }
                            catch (Exception ex)
                            {
                                tc.Result = "Fail";
                                test.CleanUp();
                            }
                        }
                    },
                    new TestCase
                    {
                        STT = "CM-9",
                        TestName = "Tăng số lượng sản phẩm trong giỏ hàng bằng nút mũi tên",
                        Precondition = "User đã đăng nhập",
                        Steps = "1. Đăng nhập thành công, truy cập trang chủ\n" +
                                "2. Nhấn vào biểu tượng giỏ hàng\n" +
                                "3. Nhấn nút mũi tên tăng",
                        ExpectedResult = "3. Tăng số lượng sản phẩm và cập nhật lại tổng giá sản phẩm",
                        ExecuteAction = (tc) =>
                        {
                            var test = new CartTests();
                            try
                            {
                                test.Setup();
                                test.Cart_IncreaseQuantity_ByButton();
                                test.CleanUp();
                                tc.Result = "Pass";
                            }
                            catch (Exception ex)
                            {
                                tc.Result = "Fail";
                                test.CleanUp();
                            }
                        }
                    },
                    new TestCase
                    {
                        STT = "CM-10",
                        TestName = "Giảm số lượng sản phẩm trong giỏ hàng bằng nút mũi tên",
                        Precondition = "User đã đăng nhập",
                        Steps = "1. Đăng nhập thành công, truy cập trang chủ\n" +
                                "2. Nhấn vào biểu tượng giỏ hàng\n" +
                                "3. Nhấn nút mũi tên giảm",
                        ExpectedResult = "3. Giảm số lượng sản phẩm và cập nhật lại tổng giá sản phẩm",
                        ExecuteAction = (tc) =>
                        {
                            var test = new CartTests();
                            try
                            {
                                test.Setup();
                                test.Cart_DecreaseQuantity_ByButton();
                                test.CleanUp();
                                tc.Result = "Pass";
                            }
                            catch (Exception ex)
                            {
                                tc.Result = "Fail";
                                test.CleanUp();
                            }
                        }
                    },
                    new TestCase
                    {
                        STT = "CM-11",
                        TestName = "Tăng số lượng sản phẩm vượt quá tồn kho",
                        Precondition = "User đã đăng nhập",
                        Steps = "1. Đăng nhập thành công, truy cập trang chủ\n" +
                                "2. Nhấn vào biểu tượng giỏ hàng\n" +
                                "3. Nhấn nút mũi tên tăng",
                        ExpectedResult = "3. Hiển thị thông báo \"Vui lòng kiểm tra lại số lượng.\"",
                        ExecuteAction = (tc) =>
                        {
                            var test = new CartTests();
                            try
                            {
                                test.Setup();
                                test.Cart_IncreaseQuantity_OverStock();
                                test.CleanUp();
                                tc.Result = "Pass";
                            }
                            catch (Exception ex)
                            {
                                tc.Result = "Fail";
                                test.CleanUp();
                            }
                        }
                    },
                    new TestCase
                    {
                        STT = "CM-12",
                        TestName = "Giảm số lượng sản phẩm đến 1 và tiếp tục giảm",
                        Precondition = "User đã đăng nhập",
                        Steps = "1. Đăng nhập thành công, truy cập trang chủ\n" +
                                "2. Nhấn vào biểu tượng giỏ hàng\n" +
                                "3. Nhấn nút mũi tên giảm",
                        ExpectedResult = "3. Hiển thị thông báo \"Vui lòng kiểm tra lại số lượng.\"",
                        ExecuteAction = (tc) =>
                        {
                            var test = new CartTests();
                            try
                            {
                                test.Setup();
                                test.Cart_DecreaseQuantity_ToZero();
                                test.CleanUp();
                                tc.Result = "Pass";
                            }
                            catch (Exception ex)
                            {
                                tc.Result = "Fail";
                                test.CleanUp();
                            }
                        }
                    },
                    new TestCase
                    {
                        STT = "CM-13",
                        TestName = "Nhập số lượng trực tiếp vào ô nhập liệu",
                        Precondition = "User đã đăng nhập",
                        Steps = "1. Đăng nhập thành công, truy cập trang chủ\n" +
                                "2. Nhấn vào biểu tượng giỏ hàng\n" +
                                "3. Nhập số lượng sản phẩm",
                        ExpectedResult = "3. Cập nhật số lượng và tổng giá sản phẩm",
                        ExecuteAction = (tc) =>
                        {
                            var test = new CartTests();
                            try
                            {
                                test.Setup();
                                test.Cart_EnterQuantity_ToTextBox();
                                test.CleanUp();
                                tc.Result = "Pass";
                            }
                            catch (Exception ex)
                            {
                                tc.Result = "Fail";
                                test.CleanUp();
                            }
                        }
                    },
                    new TestCase
                    {
                        STT = "CM-14",
                        TestName = "Nhập số lượng vượt quá tồn kho hoặc nhỏ hơn 1 vào ô nhập liệu",
                        Precondition = "User đã đăng nhập",
                        Steps = "1. Đăng nhập thành công, truy cập trang chủ\n" +
                                "2. Nhấn vào biểu tượng giỏ hàng\n" +
                                "3. Nhập số lượng sản phẩm",
                        ExpectedResult = "3. Hiển thị thông báo \"Vui lòng kiểm tra lại số lượng.\"",
                        ExecuteAction = (tc) =>
                        {
                            var test = new CartTests();
                            try
                            {
                                test.Setup();
                                test.Cart_EnterQuantity_InvalidNumber();
                                test.CleanUp();
                                tc.Result = "Pass";
                            }
                            catch (Exception ex)
                            {
                                tc.Result = "Fail";
                                test.CleanUp();
                            }
                        }
                    },
                    new TestCase
                    {
                        STT = "CM-15",
                        TestName = "Nhập kí tự không phải số vào ô nhập liệu",
                        Precondition = "User đã đăng nhập",
                        Steps = "1. Đăng nhập thành công, truy cập trang chủ\n" +
                                "2. Nhấn vào biểu tượng giỏ hàng\n" +
                                "3. Nhập số lượng sản phẩm",
                        ExpectedResult = "3. Hiển thị thông báo \"Vui lòng nhập số hợp lệ.\"",
                        ExecuteAction = (tc) =>
                        {
                            var test = new CartTests();
                            try
                            {
                                test.Setup();
                                test.Cart_EnterQuantity_Invalid();
                                test.CleanUp();
                                tc.Result = "Pass";
                            }
                            catch (Exception ex)
                            {
                                tc.Result = "Fail";
                                test.CleanUp();
                            }
                        }
                    },
                    new TestCase
                    {
                        STT = "CM-16",
                        TestName = "Xem giỏ hàng thành công khi giỏ hàng có nhiều sản phẩm",
                        Precondition = "User đã đăng nhập",
                        Steps = "1. Đăng nhập thành công, truy cập trang chủ\n" +
                                "2. Nhấn vào biểu tượng giỏ hàng\n",
                        ExpectedResult = "1. Biểu tượng giỏ hàng có số lượng mặt hàng trong giỏ\n" +
                                         "2. Hiển thị ra cửa sổ xem giỏ hàng có sản phẩm",
                        ExecuteAction = (tc) =>
                        {
                            var test = new CartTests();
                            try
                            {
                                test.Setup();
                                test.Cart_ViewSomeProduct();
                                test.CleanUp();
                                tc.Result = "Pass";
                            }
                            catch (Exception ex)
                            {
                                tc.Result = "Fail";
                                test.CleanUp();
                            }
                        }
                    },
                    new TestCase
                    {
                        STT = "CM-17",
                        TestName = "Xóa sản phẩm khỏi giỏ hàng thành công",
                        Precondition = "User đã đăng nhập",
                        Steps = "1. Đăng nhập thành công, truy cập trang chủ\n" +
                                "2. Nhấn vào biểu tượng giỏ hàng\n" +
                                "3. Nhấn vào biểu tượng thùng rác cạnh sản phẩm muốn xóa",
                        ExpectedResult = "3. Sản phẩm bị xóa khỏi giỏ hàng",
                        ExecuteAction = (tc) =>
                        {
                            var test = new CartTests();
                            try
                            {
                                test.Setup();
                                test.Cart_DeleteProduct();
                                test.CleanUp();
                                tc.Result = "Pass";
                            }
                            catch (Exception ex)
                            {
                                tc.Result = "Fail";
                                test.CleanUp();
                            }
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
