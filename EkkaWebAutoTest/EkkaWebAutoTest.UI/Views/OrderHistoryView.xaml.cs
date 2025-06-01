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
    /// Interaction logic for OrderHistoryView.xaml
    /// </summary>
    public partial class OrderHistoryView : UserControl
    {
        private List<TestCase> testCases;

        public OrderHistoryView()
        {
            InitializeComponent();
            if (Application.Current.Properties["OrderHistoryTestCases"] is List<TestCase> savedCases)
            {
                testCases = savedCases;
            }
            else
            {
                testCases = new List<TestCase>
                {
                    new TestCase
                    {
                        STT = "OH-1",
                        TestName = "Xem lịch sử mua hàng thành công khi người dùng chưa mua hàng",
                        Precondition = "User đã đăng nhập, \n" +
                                       "User chưa mua hàng",
                        Steps = "1. Đăng nhập thành công, truy cập trang chủ\n" +
                                "2. Nhấn icon người dùng bên góc trái màn hình\n" +
                                "3. Nhấn nút 'Tài khoản'\n" +
                                "4. Nhấn nút 'Lịch sử mua hàng'",
                        ExpectedResult = "4. Hiển thị thông báo \"Bạn chưa có đơn hàng nào.\"",
                        ExecuteAction = (tc) =>
                        {
                            var test = new OrderHistoryTests();
                            try
                            {
                                test.Setup();
                                test.OrderHistory_Empty();
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
                        STT = "OH-2",
                        TestName = "Xem lịch sử mua hàng thành công khi người dùng đã mua hàng",
                        Precondition = "User đã đăng nhập, \n" +
                                       "User đã mua hàng",
                        Steps = "1. Đăng nhập thành công, truy cập trang chủ\n" +
                                "2. Nhấn icon người dùng bên góc trái màn hình\n" +
                                "3. Nhấn nút 'Tài khoản'\n" +
                                "4. Nhấn nút 'Lịch sử mua hàng'",
                        ExpectedResult = "4. Hiển thị danh sách các sản phẩm đã mua",
                        ExecuteAction = (tc) =>
                        {
                            var test = new OrderHistoryTests();
                            try
                            {
                                test.Setup();
                                test.OrderHistory_HasOrders();
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
                        STT = "OH-3",
                        TestName = "Xem chi tiết đơn hàng đã mua",
                        Precondition = "User đã đăng nhập, \n" +
                                       "User đã mua hàng",
                        Steps = "1. Đăng nhập thành công, truy cập trang chủ\n" +
                                "2. Nhấn icon người dùng bên góc trái màn hình\n" +
                                "3. Nhấn nút 'Tài khoản'\n" +
                                "4. Nhấn nút 'Lịch sử mua hàng'\n" +
                                "5. Nhấn nút 'Xem' bên cạnh đơn hàng muốn xem",
                        ExpectedResult = "5. Hiển thị thông tin chi tiết đơn hàng",
                        ExecuteAction = (tc) =>
                        {
                            var test = new OrderHistoryTests();
                            try
                            {
                                test.Setup();
                                test.OrderHistory_OrderDetails();
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
                Application.Current.Properties["OrderHistoryTestCases"] = testCases;
            }

            OrderHistoryTCsGrid.ItemsSource = testCases;
        }
        private void ExecuteTest_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is TestCase testCase)
            {
                testCase.ExecuteAction?.Invoke(testCase); // Gọi hành động được gán riêng cho test này
                OrderHistoryTCsGrid.Items.Refresh();
            }
        }
    }
}
