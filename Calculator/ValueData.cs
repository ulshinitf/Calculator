﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calculator
{
    public static class ValueData
    {
        public static double Data { get; set; }
        public static bool Cancelled { get; set; }

        static ValueData()
        {
            Data = 0;
            Cancelled = false;
        }
    }
}
