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
    /// Interaction logic for OrderView.xaml
    /// </summary>
    public partial class OrderView : UserControl
    {
        private List<TestCase> testCases;

        public OrderView()
        {
            InitializeComponent();
            if (Application.Current.Properties["OrderTestCases"] is List<TestCase> savedCases)
            {
                testCases = savedCases;
            }
            else
            {
                testCases = new List<TestCase>
                {
                    new TestCase
                    {
                        STT = "OD-1",
                        TestName = "Mua hàng không thành công khi giỏ hàng trống",
                        Precondition = "User đã đăng nhập",
                        Steps = "1. Đăng nhập thành công, truy cập trang chủ\n" +
                                "2. Nhấn vào biểu tượng giỏ hàng\n" +
                                "3. Nhấn nút 'Thanh toán'\n",
                        ExpectedResult = "3. Hiển thị thông báo \"Vui lòng thêm sản phẩm vào giỏ hàng.\"",
                        ExecuteAction = (tc) =>
                        {
                            var test = new OrderTests();
                            try
                            {
                                test.Setup();
                                test.Order_CartEmpty();
                                test.CleanUp();
                                tc.Result = "Pass";
                            }
                            catch (Exception ex)
                            {
                                tc.Result = "Fail";
                                tc.ErrorMessage = ex.Message;
                                test.CleanUp();
                            }
                        }
                    },
                    new TestCase
                    {
                        STT = "OD-2",
                        TestName = "Mua hàng thành công khi thanh toán khi nhận hàng",
                        Precondition = "User đã đăng nhập",
                        Steps = "1. Đăng nhập thành công, truy cập trang chủ\n" +
                                "2. Nhấn vào biểu tượng giỏ hàng\n" +
                                "3. Nhấn nút 'Thanh toán'\n" +
                                "4. Nhập thông tin người nhận và chọn thanh toán khi nhận hàng\n" +
                                "5. Nhấn nút 'Đặt hàng'",
                        ExpectedResult = "5. Hiển thị thông báo \"Bạn đã đặt hàng thành công\"",
                        ExecuteAction = (tc) =>
                        {
                            var test = new OrderTests();
                            try
                            {
                                test.Setup();
                                test.Order_COD();
                                test.CleanUp();
                                tc.Result = "Pass";
                            }
                            catch (Exception ex)
                            {
                                tc.Result = "Fail";
                                tc.ErrorMessage = ex.Message;
                                test.CleanUp();
                            }
                        }
                    },
                    new TestCase
                    {
                        STT = "OD-3",
                        TestName = "Mua hàng thành công khi thanh toán bằng VNPAY",
                        Precondition = "User đã đăng nhập",
                        Steps = "1. Đăng nhập thành công, truy cập trang chủ\n" +
                                "2. Nhấn vào biểu tượng giỏ hàng\n" +
                                "3. Nhấn nút 'Thanh toán'\n" +
                                "4. Nhập thông tin người nhận và chọn thanh toán bằng VNPAY\n" +
                                "5. Nhấn nút 'Đặt hàng'\n" +
                                "6. Thanh toán",
                        ExpectedResult = "6. Hiển thị thông báo \"Bạn đã đặt hàng thành công\"",
                        ExecuteAction = (tc) =>
                        {
                            var test = new OrderTests();
                            try
                            {
                                test.Setup();
                                test.Order_VNPAY();
                                test.CleanUp();
                                tc.Result = "Pass";
                            }
                            catch (Exception ex)
                            {
                                tc.Result = "Fail";
                                tc.ErrorMessage = ex.Message;
                                test.CleanUp();
                            }
                        }
                    },
                    new TestCase
                    {
                        STT = "OD-4",
                        TestName = "Mua hàng thành công khi thanh toán bằng MOMO",
                        Precondition = "User đã đăng nhập",
                        Steps = "1. Đăng nhập thành công, truy cập trang chủ\n" +
                                "2. Nhấn vào biểu tượng giỏ hàng\n" +
                                "3. Nhấn nút 'Thanh toán'\n" +
                                "4. Nhập thông tin người nhận và chọn thanh toán bằng MOMO\n" +
                                "5. Nhấn nút 'Đặt hàng'\n" +
                                "6. Thanh toán",
                        ExpectedResult = "6. Hiển thị thông báo \"Bạn đã đặt hàng thành công\"",
                        ExecuteAction = (tc) =>
                        {
                            var test = new OrderTests();
                            try
                            {
                                test.Setup();
                                test.Order_MOMO();
                                test.CleanUp();
                                tc.Result = "Pass";
                            }
                            catch (Exception ex)
                            {
                                tc.Result = "Fail";
                                tc.ErrorMessage = ex.Message;
                                test.CleanUp();
                            }
                        }
                    },
                    new TestCase
                    {
                        STT = "OD-5",
                        TestName = "Kiểm tra số lượng sản phẩm tồn kho sau khi mua hàng thành công",
                        Precondition = "",
                        Steps = "1. Truy cập trang chủ\n" +
                                "2. Nhấn vào sản phẩm đã mua",
                        ExpectedResult = "2. Số lượng sản phẩm được cập nhật lại",
                        ExecuteAction = (tc) =>
                        {
                            var test = new OrderTests();
                            try
                            {
                                test.Setup();
                                test.CheckQuantity_AfterOrder();
                                test.CleanUp();
                                tc.Result = "Pass";
                            }
                            catch (Exception ex)
                            {
                                tc.Result = "Fail";
                                tc.ErrorMessage = ex.Message;
                                test.CleanUp();
                            }
                        }
                    },
                    new TestCase
                    {
                        STT = "OD-6",
                        TestName = "Mua hàng khi bỏ trống các trường thông tin",
                        Precondition = "User đã đăng nhập",
                        Steps = "1. Đăng nhập thành công, truy cập trang chủ\n" +
                                "2. Nhấn vào biểu tượng giỏ hàng\n" +
                                "3. Nhấn nút 'Thanh toán'\n" +
                                "4. Bỏ trống các trường thông tin\n" +
                                "5. Nhấn nút 'Đặt hàng'\n" +
                                "6. Thanh toán",
                        ExpectedResult = "6. Hiển thị thông báo yêu cầu không được bỏ trống dưới mỗi trường",
                        ExecuteAction = (tc) =>
                        {
                            var test = new OrderTests();
                            try
                            {
                                test.Setup();
                                test.Order_EmptyInfo();
                                test.CleanUp();
                                tc.Result = "Pass";
                            }
                            catch (Exception ex)
                            {
                                tc.Result = "Fail";
                                tc.ErrorMessage = ex.Message;
                                test.CleanUp();
                            }
                        }
                    },
                    new TestCase
                    {
                        STT = "OD-7",
                        TestName = "Mua hàng khi nhập số điện thoại không hợp lệ",
                        Precondition = "User đã đăng nhập",
                        Steps = "1. Đăng nhập thành công, truy cập trang chủ\n" +
                                "2. Nhấn vào biểu tượng giỏ hàng\n" +
                                "3. Nhấn nút 'Thanh toán'\n" +
                                "4. Nhập số điện thoại không hợp lệ và nhập thông tin người nhận\n" +
                                "5. Nhấn nút 'Đặt hàng'\n" +
                                "6. Thanh toán",
                        ExpectedResult = "6. Hiển thị thông báo \"Vui lòng nhập đúng số điện thoại hợp lệ.\"",
                        ExecuteAction = (tc) =>
                        {
                            var test = new OrderTests();
                            try
                            {
                                test.Setup();
                                test.Order_InvalidPhone();
                                test.CleanUp();
                                tc.Result = "Pass";
                            }
                            catch (Exception ex)
                            {
                                tc.Result = "Fail";
                                tc.ErrorMessage = ex.Message;
                                test.CleanUp();
                            }
                        }
                    },
                };

                // Lưu testCases vào Application.Current
                Application.Current.Properties["OrderTestCases"] = testCases;
            }

            OrderTCsGrid.ItemsSource = testCases;
        }
        private void ExecuteTest_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is TestCase testCase)
            {
                testCase.ExecuteAction?.Invoke(testCase); // Gọi hành động được gán riêng cho test này
                OrderTCsGrid.Items.Refresh();
            }
        }
    }
}
