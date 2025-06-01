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
    /// Interaction logic for SignUpView.xaml
    /// </summary>
    public partial class SignUpView : UserControl
    {
        private List<TestCase> testCases;

        public SignUpView()
        {
            InitializeComponent();
            if (Application.Current.Properties["SignUpTestCases"] is List<TestCase> savedCases)
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
                        TestName = "Đăng ký thành công khi nhập các trường hợp lệ",
                        Steps = "1. Nhập Họ và tên, Email và Mật khẩu hợp lệ\n" +
                                "2. Nhấn nút 'Đăng ký'",
                        TestData = "Họ và tên: Hang\n" +
                                   "Email: user1@gmail.com\n" +
                                   "Mật khẩu: User1234@",
                        ExpectedResult = "2. Đăng ký thành công",
                        ExecuteAction = (tc) =>
                        {
                            var test = new SignUpTests();
                            try
                            {
                                test.Setup();
                                test.SignUp_Success();
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
                        STT = "SU-2",
                        TestName = "Đăng ký không thành công khi nhập email đã tồn tại",
                        Steps = "1. Nhập Email đã đăng ký tài khoản\n" +
                                "2. Nhập Họ và tên, Mật khẩu hợp lệ\n" +
                                "3. Nhấn nút 'Đăng ký'",
                        TestData = "Họ và tên: Hang\n" +
                                   "Email: hangt7708@gmail.com\n" +
                                   "Mật khẩu: User1234@",
                        ExpectedResult = "3. Hiển thị thông báo lỗi \"Email đã tồn tại vui lòng đăng nhập.\" ",
                        ExecuteAction = (tc) =>
                        {
                            var test = new SignUpTests();
                            try
                            {
                                test.Setup();
                                test.SignUp_ExistingEmail();
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
                        STT = "SU-3",
                        TestName = "Đăng ký không thành công khi nhập sai định dạng email",
                        Steps = "1. Nhập sai định dạng Email\n" +
                                "2. Nhập Họ và tên và Mật khẩu hợp lệ\n" +
                                "3. Nhấn nút 'Đăng ký'",
                        TestData = "Họ và tên: Hang\n" +
                                   "Email: user\n" +
                                   "Mật khẩu: User1234@",
                        ExpectedResult = "3. Hiển thị thông báo lỗi \"Vui lòng nhập đúng định dạng email.\"",
                        ExecuteAction = (tc) =>
                        {
                            var test = new SignUpTests();
                            try
                            {
                                test.Setup();
                                test.SignUp_InvalidEmailFormat();
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
                        STT = "SU-4",
                        TestName = "Đăng ký không thành công khi nhập mật khẩu không hợp lệ",
                        Steps = "1. Nhập Mật khẩu không hợp lệ\n" +
                                "2. Nhập Họ và tên và Email hợp lệ\n" +
                                "3. Nhấn nút 'Đăng ký'",
                        TestData = "Họ và tên: Hang\n" +
                                   "Email: user2@gmail.com\n" +
                                   "Mật khẩu: user123",
                        ExpectedResult = "3. Hiển thị thông báo lỗi \"Mật khẩu phải có ít nhất 8 ký tự, bao gồm chữ hoa, chữ thường và số.\"",
                        ExecuteAction = (tc) =>
                        {
                            var test = new SignUpTests();
                            try
                            {
                                test.Setup();
                                test.SignUp_InvalidPasswordFormat();
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
                        STT = "SU-5",
                        TestName = "Đăng ký không thành công khi không nhập Họ và tên",
                        Steps = "1. Để trống trường Họ và tên\n" +
                                "2. Nhập Email, Mật khẩu hợp lệ\n" +
                                "3. Nhấn nút 'Đăng ký'",
                        TestData = "Họ và tên: \n" +
                                   "Email: hangt7708@gmail.com\n" +
                                   "Mật khẩu: User1234@",
                        ExpectedResult = "3. Hiển thị thông báo lỗi \"Vui lòng không để trống họ và tên.\" ",
                        ExecuteAction = (tc) =>
                        {
                            var test = new SignUpTests();
                            try
                            {
                                test.Setup();
                                test.SignUp_EmptyName();
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
                        STT = "SU-6",
                        TestName = "Đăng ký không thành công khi không nhập Email",
                        Steps = "1. Để trống trường Email\n" +
                                "2. Nhập Họ và tên, Mật khẩu hợp lệ\n" +
                                "3. Nhấn nút 'Đăng ký'",
                        TestData = "Họ và tên: Hang\n" +
                                   "Email: \n" +
                                   "Mật khẩu: User1234@",
                        ExpectedResult = "3. Hiển thị thông báo lỗi \"Vui lòng không để trống email.\" ",
                        ExecuteAction = (tc) =>
                        {
                            var test = new SignUpTests();
                            try
                            {
                                test.Setup();
                                test.SignUp_EmptyEmail();
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
                        STT = "SU-7",
                        TestName = "Đăng ký không thành công khi không nhập Mật khẩu",
                        Steps = "1. Để trống trường Mật khẩu\n" +
                                "2. Nhập Họ và tên, Email hợp lệ\n" +
                                "3. Nhấn nút 'Đăng ký'",
                        TestData = "Họ và tên: Hang\n" +
                                   "Email: hangt7708@gmail.com\n" +
                                   "Mật khẩu: ",
                        ExpectedResult = "3. Hiển thị thông báo lỗi \"Vui lòng không để trống mật khẩu.\" ",
                        ExecuteAction = (tc) =>
                        {
                            var test = new SignUpTests();
                            try
                            {
                                test.Setup();
                                test.SignUp_EmptyPassword();
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
                Application.Current.Properties["SignUpTestCases"] = testCases;
            }

            SignUpTCsGrid.ItemsSource = testCases;
        }
        private void ExecuteTest_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is TestCase testCase)
            {
                testCase.ExecuteAction?.Invoke(testCase); // Gọi hành động được gán riêng cho test này
                SignUpTCsGrid.Items.Refresh();
            }
        }
    }
}
