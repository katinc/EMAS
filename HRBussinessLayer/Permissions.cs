using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRDataAccessLayer
{
    public class Permissions
    {
        public bool CanEdit { get; set; }
        public bool CanAdd { get; set; }
        public bool CanDelete { get; set; }
        public bool CanPrint { get; set; }
        public bool CanView { get; set; }
    }
}
