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
        public class FunctionReport
        {
            public string FunctionName { get; set; }
            public int Passed { get; set; }
            public int Failed { get; set; }
            public int Total => Passed + Failed;
        }

        private void LoadSummaryData()
        {
            var functionReports = new List<FunctionReport>
    {
        new FunctionReport { FunctionName = "Đăng nhập", Passed = 6, Failed = 1 },
        new FunctionReport { FunctionName = "Đăng ký", Passed = 6, Failed = 1 },
        new FunctionReport { FunctionName = "Đăng xuất", Passed = 1, Failed = 0 },
        new FunctionReport { FunctionName = "Xem thông tin tài khoản", Passed = 1, Failed = 0 },
        new FunctionReport { FunctionName = "Xem chi tiết sản phẩm", Passed = 2, Failed = 0 },
        new FunctionReport { FunctionName = "Quản lý giỏ hàng", Passed = 10, Failed = 7 },
        new FunctionReport { FunctionName = "Mua hàng", Passed = 6, Failed = 1 },
        new FunctionReport { FunctionName = "Tìm kiếm sản phẩm", Passed = 2, Failed = 1 },
        new FunctionReport { FunctionName = "Xem lịch sử mua hàng", Passed = 2, Failed = 1 },


    };

            int totalPassed = functionReports.Sum(f => f.Passed);
            int totalFailed = functionReports.Sum(f => f.Failed);
            int total = totalPassed + totalFailed;

            functionReports.Add(new FunctionReport
            {
                FunctionName = "Tổng",
                Passed = totalPassed,
                Failed = totalFailed
            });

            FunctionReportGrid.ItemsSource = functionReports;

            // Biểu đồ hình tròn – phần trăm
            PassFailPieChart.Series = new SeriesCollection
    {
        new PieSeries
        {
            Title = "Passed",
            Values = new ChartValues<int> { totalPassed },
            DataLabels = true,
            LabelPoint = chartPoint =>
                $"{chartPoint.Participation:P0}", // Phần trăm
            Fill = System.Windows.Media.Brushes.Green
        },
        new PieSeries
        {
            Title = "Failed",
            Values = new ChartValues<int> { totalFailed },
            DataLabels = true,
            LabelPoint = chartPoint =>
                $"{chartPoint.Participation:P0}",
            Fill = System.Windows.Media.Brushes.Red
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
