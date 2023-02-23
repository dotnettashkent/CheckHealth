﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckHealth.Service.Helpers
{
    public class GenericResponse<TValue>
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public TValue Value { get; set; }
    }

}
