using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SklepUKW.ViewModels
{
    public class ItemRemoveViewModel
    {
        public int ItemId { get; set; }

        public int ItemQuantity { get; set; }

        public decimal CartValue { get; set; }

        public int CartQuantity { get; set; }
    }
}