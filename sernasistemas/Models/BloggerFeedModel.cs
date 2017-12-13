using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SernaSistemas.Models {
    public class BloggerFeedModel {
        public List<string> entries {
            get; set;
        }

        public BloggerFeedModel() {
            entries = new List<string>();
        }
    }
}