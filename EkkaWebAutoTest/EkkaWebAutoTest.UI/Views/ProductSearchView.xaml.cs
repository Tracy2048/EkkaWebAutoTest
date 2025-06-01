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
    /// Interaction logic for ProductSearchView.xaml
    /// </summary>
    public partial class ProductSearchView : UserControl
    {
        private List<TestCase> testCases;

        public ProductSearchView()
        {
            InitializeComponent();
            if (Application.Current.Properties["ProductSearchTestCases"] is List<TestCase> savedCases)
            {
                testCases = savedCases;
            }
            else
            {
                testCases = new List<TestCase>
                {
                    new TestCase
                    {
                        STT = "PS-1",
                        TestName = "Tìm kiếm sản phẩm thành công khi có sản phẩm phù hợp với thông tin tìm kiếm",
                        Steps = "1. Nhấn thanh tìm kiếm\n" +
                                "2. Nhập tên sản phẩm cần tìm\n" +
                                "3. Nhấn Enter",
                        TestData = "Tìm kiếm: bag\n",
                        ExpectedResult = "3. Hiển thị danh sách các sản phẩm có thông tin phù hợp",
                        ExecuteAction = (tc) =>
                        {
                            var test = new ProductSearchTests();
                            try
                            {
                                test.Setup();
                                test.SearchProduct_Success();
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
                        STT = "PS-2",
                        TestName = "Tìm kiếm sản phẩm khi không có sản phẩm phù hợp với thông tin tìm kiếm",
                        Steps = "1. Nhấn thanh tìm kiếm\n" +
                                "2. Nhập tên sản phẩm cần tìm\n" +
                                "3. Nhấn Enter",
                        TestData = "Tìm kiếm: glove\n",
                        ExpectedResult = "3. Hiển thị thông báo \"Không có sản phẩm phù hợp.\"",
                        ExecuteAction = (tc) =>
                        {
                            var test = new ProductSearchTests();
                            try
                            {
                                test.Setup();
                                test.SearchProduct_NotFound();
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
                        STT = "PS-3",
                        TestName = "Tìm kiếm sản phẩm khi không nhập tên sản phẩm",
                        Steps = "1. Nhấn thanh tìm kiếm\n" +
                                "2. Không nhập tên sản phẩm cần tìm\n" +
                                "3. Nhấn Enter",
                        //TestData = "Tìm kiếm: \n",
                        ExpectedResult = "3. Hiển thị toàn bộ sản phẩm",
                        ExecuteAction = (tc) =>
                        {
                            var test = new ProductSearchTests();
                            try
                            {
                                test.Setup();
                                test.SearchProduct_EmptyField();
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
                Application.Current.Properties["ProductSearchTestCases"] = testCases;
            }

            ProductSearchTCsGrid.ItemsSource = testCases;
        }
        private void ExecuteTest_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is TestCase testCase)
            {
                testCase.ExecuteAction?.Invoke(testCase); // Gọi hành động được gán riêng cho test này
                ProductSearchTCsGrid.Items.Refresh();
            }
        }
    }
}
