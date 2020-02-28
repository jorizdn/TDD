using System;
using System.Collections.Generic;
using System.Text;

namespace TDDUnitTestImplementation.Model
{
    public class ChangeResult
    {
        public double Change { get; set; }
        public bool IsSuccessful { get; set; }
        public string Message { get; set; }
        public Product Product { get; set; }
    }
}
