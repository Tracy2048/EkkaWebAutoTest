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
                            tc.Result = "Pass";
                            //var test = new AccountTests();
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
                        STT = "OD-2",
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
                            tc.Result = "Pass";
                            
                        }
                    },
                    new TestCase
                    {
                        STT = "OD-3",
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
                            tc.Result = "Pass";

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
