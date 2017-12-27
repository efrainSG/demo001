using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WCFCotedivLib {
    [ServiceContract]
    public interface ICotedivServices {
        [OperationContract]
        List<string> getPosts(int idUsuario);
        [OperationContract]
        List<string> getRanking();
        [OperationContract]
        List<string> getResults(string query);
    }
}
