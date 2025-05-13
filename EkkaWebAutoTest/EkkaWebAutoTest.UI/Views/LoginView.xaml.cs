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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EkkaWebAutoTest.UI.Views
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : UserControl
    {
        private List<TestCase> testCases;

        public LoginView()
        {
            InitializeComponent();

            if (Application.Current.Properties["LoginTestCases"] is List<TestCase> savedCases)
            {
                testCases = savedCases;
            }
            else
            {
                testCases = new List<TestCase> 
                { 
                    new TestCase
                    {
                        STT = "SU-1",
                        TestName = "Đăng nhập thành công khi nhập các trường hợp lệ",
                        Steps = "1. Nhập Địa chỉ Email và Mật khẩu hợp lệ\n" +
                                "2. Nhấn nút 'Đăng nhập'",
                        TestData = "Email: hangt7708@gmail.com\n" +
                                   "Mật khẩu: User1234@",
                        ExpectedResult = "2. Đăng nhập thành công",
                        ExecuteAction = (tc) =>
                        {
                            var test = new LoginTests();
                            try
                            {
                                test.Setup();
                                test.Login_Success();
                                test.CleanUp();
                                tc.Result = "Pass";
                            }
                            catch (Exception ex)
                            {
                                tc.Result = $"{ex.Message}";
                            }
                        }
                    },
                    new TestCase
                    {
                        STT = "SU-2",
                        TestName = "Đăng nhập không thành công khi không nhập Email",
                        Steps = "1. Để trống trường Email và nhập trường Mật khẩu\n" +
                                "2. Nhấn nút 'Đăng nhập'",
                        TestData = "Email:\n" +
                                   "Mật khẩu: User1234@",
                        ExpectedResult = "2. Hiển thị thông báo lỗi \"Vui lòng không để trống email.\" ",
                        ExecuteAction = (tc) =>
                        {
                            var test = new LoginTests();
                            try
                            {
                                test.Setup();
                                test.Login_EmptyEmail();
                                test.CleanUp();
                                tc.Result = "Pass";
                            }
                            catch (Exception ex)
                            {
                                tc.Result = $"{ex.Message}";
                            }
                        }
                    },
                    new TestCase
                    {
                        STT = "SU-3",
                        TestName = "Đăng nhập không thành công khi không nhập Mật khẩu",
                        Steps = "1. Nhập trường Email và để trống trường Mật khẩu\n" +
                                "2. Nhấn nút 'Đăng nhập'",
                        TestData = "Email: hangt7708@gmail.com\n" +
                                   "Mật khẩu: ",
                        ExpectedResult = "2. Hiển thị thông báo lỗi \"Vui lòng không để trống mật khẩu.\" ",
                        ExecuteAction = (tc) =>
                        {
                            var test = new LoginTests();
                            try
                            {
                                test.Setup();
                                test.Login_EmptyPassword();
                                test.CleanUp();
                                tc.Result = "Pass";
                            }
                            catch (Exception ex)
                            {
                                tc.Result = $"{ex.Message}";
                            }
                        }
                    },
                    new TestCase
                    {
                        STT = "SU-4",
                        TestName = "Đăng nhập không thành công khi nhập sai Email",
                        Steps = "1. Nhập sai Email và nhập Mật khẩu hợp lệ\n" +
                                "2. Nhấn nút 'Đăng nhập'",
                        TestData = "Email: hang@gmail.com\n" +
                                   "Mật khẩu: User1234@",
                        ExpectedResult = "2. Hiển thị thông báo lỗi \"Email hoặc mật khẩu không chính xác.\" ",
                        ExecuteAction = (tc) =>
                        {
                            var test = new LoginTests();
                            try
                            {
                                test.Setup();
                                test.Login_IncorrectEmail();
                                test.CleanUp();
                                tc.Result = "Pass";
                            }
                            catch (Exception ex)
                            {
                                tc.Result = $"{ex.Message}";
                            }
                        }
                    },
                    new TestCase
                    {
                        STT = "SU-5",
                        TestName = "Đăng nhập không thành công khi nhập sai Mật khẩu",
                        Steps = "1. Nhập Email hợp lệ và nhập sai Mật khẩu\n" +
                                "2. Nhấn nút 'Đăng nhập'",
                        TestData = "Email: hangt7708@gmail.com\n" +
                                   "Mật khẩu: User@1111",
                        ExpectedResult = "2. Hiển thị thông báo lỗi \"Email hoặc mật khẩu không chính xác.\" ",
                        ExecuteAction = (tc) =>
                        {
                            var test = new LoginTests();
                            try
                            {
                                test.Setup();
                                test.Login_IncorrectPassword();
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
                Application.Current.Properties["LoginTestCases"] = testCases;
            }

            TestCasesGrid.ItemsSource = testCases;

        }

        private void ExecuteTest_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is TestCase testCase)
            {
                testCase.ExecuteAction?.Invoke(testCase); // Gọi hành động được gán riêng cho test này
                TestCasesGrid.Items.Refresh();
            }
        }


    }
}
