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
    /// Interaction logic for LogoutView.xaml
    /// </summary>
    public partial class LogoutView : UserControl
    {
        private List<TestCase> testCases;

        public LogoutView()
        {
            InitializeComponent();
            if (Application.Current.Properties["LogoutTestCases"] is List<TestCase> savedCases)
            {
                testCases = savedCases;
            }
            else
            {
                testCases = new List<TestCase>
                {
                    new TestCase
                    {
                        STT = "LO-1",
                        TestName = "Đăng xuất thành công",
                        Precondition = "User đã đăng nhập",
                        Steps = "1. Nhấn icon người dùng bên góc trái màn hình\n" +
                                "2. Nhấn nút 'Đăng xuất'",
                        ExpectedResult = "2. Đăng xuất thành công",
                        ExecuteAction = (tc) =>
                        {
                            var test = new LogoutTests();
                            try
                            {
                                test.Setup();
                                test.Logout_Success();
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
                Application.Current.Properties["LogoutTestCases"] = testCases;
            }

            LogoutTCsGrid.ItemsSource = testCases;
        }
        private void ExecuteTest_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is TestCase testCase)
            {
                testCase.ExecuteAction?.Invoke(testCase); // Gọi hành động được gán riêng cho test này
                LogoutTCsGrid.Items.Refresh();
            }
        }
    }
}
