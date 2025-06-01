using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EkkaWebAutoTest.UI.Models
{
    public class TestCase 
    {
        public string FunctionName { get; set; }
        public string STT { get; set; }
        public string TestName { get; set; }
        public string Precondition { get; set; }
        public string Steps { get; set; }
        public string TestData { get; set; }
        public string ExpectedResult { get; set; }
        public string Result { get; set; }
        public Action<TestCase> ExecuteAction { get; set; }

        public string ErrorMessage;
    }
}
