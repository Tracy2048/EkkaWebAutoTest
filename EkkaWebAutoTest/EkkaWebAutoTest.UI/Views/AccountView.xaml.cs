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
    /// Interaction logic for AccountView.xaml
    /// </summary>
    public partial class AccountView : UserControl
    {
        private List<TestCase> testCases;

        public AccountView()
        {
            InitializeComponent();
            if (Application.Current.Properties["AccountTestCases"] is List<TestCase> savedCases)
            {
                testCases = savedCases;
            }
            else
            {
                testCases = new List<TestCase>
                {
                    new TestCase
                    {
                        STT = "VA-1",
                        TestName = "Xem thông tin tài khoản thành công",
                        Precondition = "User đã đăng nhập",
                        Steps = "1. Đăng nhập thành công, truy cập trang chủ\n" +
                                "2. Nhấn icon người dùng bên góc trái màn hình\n" +
                                "3. Nhấn nút 'Tài khoản'",
                        ExpectedResult = "3. Hiển thị đúng thông tin người dùng họ tên và email",
                        ExecuteAction = (tc) =>
                        {
                            var test = new AccountTests();
                            try
                            {
                                test.Setup();
                                test.ViewAccount_Success();
                                test.CleanUp();
                                tc.Result = "Pass";
                            }
                            catch (Exception ex)
                            {
                                tc.Result = $"{ex.Message}";
                            }
                        }
                    },


                };

                // Lưu testCases vào Application.Current
                Application.Current.Properties["AccountTestCases"] = testCases;
            }

            AccountTCsGrid.ItemsSource = testCases;
        }
        private void ExecuteTest_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is TestCase testCase)
            {
                testCase.ExecuteAction?.Invoke(testCase); // Gọi hành động được gán riêng cho test này
                AccountTCsGrid.Items.Refresh();
            }
        }
    }
}
