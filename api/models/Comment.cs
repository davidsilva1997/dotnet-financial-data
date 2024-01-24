using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.models
{
    public class Comment
    {
        public Guid? StockId { get; set; }

        #region Navigation Properties
        public Stock? Stock { get; set; }
        #endregion
    }
}