using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WCFCotedivLib {
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class CotedivServices : ICotedivServices {
        public List<string> getPosts(int idUsuario) {
            var lista = ("Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus.").Split('.').ToList();
            return lista;
        }

        public List<string> getRanking() {
            var lista = ("Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus.").Split((",.").ToCharArray()).ToList();
            return lista;
        }

        public List<string> getResults(string query) {
            throw new NotImplementedException();
        }
    }
}
