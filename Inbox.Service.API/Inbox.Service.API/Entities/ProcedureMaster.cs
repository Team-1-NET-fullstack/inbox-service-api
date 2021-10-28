﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Inbox.Service.API.Entities
{
    public partial class ProcedureMaster
    {
        public int ProcedureMastersId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsDeprecated { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
