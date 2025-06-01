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
    /// Interaction logic for ProductView.xaml
    /// </summary>
    public partial class ProductView : UserControl
    {
        private List<TestCase> testCases;

        public ProductView()
        {
            InitializeComponent();
            if (Application.Current.Properties["ProductTestCases"] is List<TestCase> savedCases)
            {
                testCases = savedCases;
            }
            else
            {
                testCases = new List<TestCase>
                {
                    new TestCase
                    {
                        STT = "VP-1",
                        TestName = "Xem chi tiết sản phẩm thành công khi user chưa đăng nhập",
                        //Precondition = "",
                        Steps = "1. Truy cập trang chủ\n" +
                                "2. Nhấn vào sản phẩm muốn xem",
                        ExpectedResult = "2. Hiển thị đúng thông tin sản phẩm đã chọn",
                        ExecuteAction = (tc) =>
                        {
                            var test = new ProductTests();
                            try
                            {
                                test.Setup();
                                test.ViewProduct_Without_Login();
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
                        STT = "VP-2",
                        TestName = "Xem chi tiết sản phẩm thành công khi user đã đăng nhập",
                        Precondition = "User đã đăng nhập",
                        Steps = "1. Đăng nhập thành công, truy cập trang chủ\n" +
                                "2. Nhấn vào sản phẩm muốn xem",
                        ExpectedResult = "2. Hiển thị đúng thông tin sản phẩm đã chọn",
                        ExecuteAction = (tc) =>
                        {
                            var test = new ProductTests();
                            try
                            {
                                test.Setup();
                                test.ViewProduct_After_Login();
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
                Application.Current.Properties["ProductTestCases"] = testCases;
            }

            ProductTCsGrid.ItemsSource = testCases;
        }
        private void ExecuteTest_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is TestCase testCase)
            {
                testCase.ExecuteAction?.Invoke(testCase); // Gọi hành động được gán riêng cho test này
                ProductTCsGrid.Items.Refresh();
            }
        }
    }
}
