using EkkaWebAutoTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EkkaWebAutoTest.Constants
{
    public static class AccountStore
    {
        public static Account Account1 = new Account
        {
            name = "Hang",
            email = "hangt7708@gmail.com",
            password = "User1234@",
            phone = "0834561567",
            address = "298 Cau Dien, Bac Tu Liem, Hanoi, Vietnam",
        };
        public static Account Account2 = new Account
        {
            name = "Tracy",
            email = "tranhang2048@gmail.com",
            password = "User1234#",
            phone = "0834561567",
            address = "298 Cau Dien, Bac Tu Liem, Hanoi, Vietnam",
        };
    }
}
