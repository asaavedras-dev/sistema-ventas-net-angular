﻿using POS.Infraestructure.Commons.Bases.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Infraestructure.Commons.Bases.Request
{
    public class BaseFilterRequest: BasePaginationRequest
    {
        public int? NumFilter { get; set; } = null;
        public string? TextFilter { get; set; } = null;
        public int? StateFilter { get; set; } = null;

        public string? StartDate { get; set; } = null;

        public string? EndtDate { get; set; } = null;

        public bool? Dowload { get; set; } = null;
    }
}
