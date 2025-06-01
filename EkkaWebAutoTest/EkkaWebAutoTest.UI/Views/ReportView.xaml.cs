using LiveCharts.Wpf;
using LiveCharts;
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
using System.Runtime.InteropServices;
using EkkaWebAutoTest.UI.Models;

namespace EkkaWebAutoTest.UI.Views
{
    /// <summary>
    /// Interaction logic for ReportView.xaml
    /// </summary>
    public partial class ReportView : UserControl
    {
        public ReportView()
        {
            InitializeComponent();
            ExecutionDateText.Text = DateTime.Now.ToString("dd/MM/yyyy");
            LoadSummaryData();
        }
        // Mô hình dữ liệu cho từng chức năng

        private void RunAllTestCases_Click(object sender, RoutedEventArgs e)
        {
            // Duyệt qua tất cả cặp key-value trong Application.Current.Properties
            foreach (var key in Application.Current.Properties.Keys)
            {
                if (Application.Current.Properties[key] is List<TestCase> testCases)
                {
                    foreach (var testCase in testCases)
                    {
                        try
                        {
                            testCase.ExecuteAction?.Invoke(testCase);
                        }
                        catch (Exception ex)
                        {
                            testCase.Result = "Fail";
                        }
                    }
                }
            }
            LoadSummaryData();
            // Nếu bạn biết các UserControl đang hiển thị, gọi Items.Refresh() nếu cần
            // Ví dụ:
            //AccountTCsGrid?.Items.Refresh();
            //ProductTCsGrid?.Items.Refresh();
            //CartTCsGrid?.Items.Refresh();
        }

        public class FunctionReport
        {
            public string FunctionName { get; set; }
            public int Passed { get; set; }
            public int Failed { get; set; }
            public int Total => Passed + Failed;
        }

        private void LoadSummaryData()
        {
            var functionReports = new List<FunctionReport>();

            foreach (var key in Application.Current.Properties.Keys)
            {
                if (Application.Current.Properties[key] is List<TestCase> testCases)
                {
                    var functionName = key.ToString().Replace("TestCases", "").Replace("TCs", "");

                    var vietnameseNames = new Dictionary<string, string>
                    {
                        { "OrderHistory", "Xem lịch sử mua hàng" },
                        { "ProductSearch", "Tìm kiếm sản phẩm" },
                        { "SignUp", "Đăng ký" },
                        { "Logout", "Đăng xuất" },
                        { "Account", "Xem thông tin tài khoản" },
                        { "Product", "Xem chi tiết sản phẩm" },
                        { "Cart", "Quản lý giỏ hàng" },
                        { "Order", "Mua hàng" },
                        { "Login", "Đăng nhập" }
                    };

                    foreach (var pair in vietnameseNames.OrderByDescending(p => p.Key.Length))
                    {
                        if (functionName.Contains(pair.Key))
                        {
                            functionName = functionName.Replace(pair.Key, pair.Value);
                        }
                    }

                    int passed = testCases.Count(tc => tc.Result?.Trim().ToLower() == "pass");
                    int failed = testCases.Count(tc => tc.Result?.Trim().ToLower() == "fail");

                    functionReports.Add(new FunctionReport
                    {
                        FunctionName = functionName,
                        Passed = passed,
                        Failed = failed
                    });
                }
            }

            int totalPassed = functionReports.Sum(f => f.Passed);
            int totalFailed = functionReports.Sum(f => f.Failed);

            functionReports.Add(new FunctionReport
            {
                FunctionName = "Tổng",
                Passed = totalPassed,
                Failed = totalFailed
            });

            FunctionReportGrid.ItemsSource = functionReports;
            FunctionReportGrid.Items.Refresh();

            PassFailPieChart.Series = new SeriesCollection
    {
        new PieSeries
        {
            Title = "Passed",
            Values = new ChartValues<int> { totalPassed },
            DataLabels = true,
            LabelPoint = chartPoint => $"{chartPoint.Y} ({chartPoint.Participation:P0})",
            Fill = Brushes.Green
        },
        new PieSeries
        {
            Title = "Failed",
            Values = new ChartValues<int> { totalFailed },
            DataLabels = true,
            LabelPoint = chartPoint => $"{chartPoint.Y} ({chartPoint.Participation:P0})",
            Fill = Brushes.Red
        }
    };
        }



        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            string os = RuntimeInformation.OSDescription;
            string browser = "Google Chrome";
            EnvironmentText.Text = $"{os}, {browser}";

            ExecutionDateText.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }


    }
}
