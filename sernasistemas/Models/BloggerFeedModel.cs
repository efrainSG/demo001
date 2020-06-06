using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SernaSistemas.Models {
    public class BloggerFeedModel {
        public string MsgError {
            get; set;
        }

        public Dictionary<string,string> entries {
            get; set;
        }

        public KeyValuePair<string,string> topEntryContent {
            get; set;
        }
        public BloggerFeedModel() {
            entries = new Dictionary<string, string>();
            topEntryContent = new KeyValuePair<string, string>();
            MsgError = string.Empty;
        }
    }
    public class sesionModel
    {
        public int IdUsuario { get; set; }
        public string Usuario { get; set; }
        public string UltimoLogin { get; set; }
        public int IdTienda { get; set; }
    }
}