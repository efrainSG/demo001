using SernaSistemas.Core.Bases;
using SernaSistemas.Core.Models;
using System.Runtime.Serialization;

namespace WCFTiendasLib.Contracts {
    [DataContract]
    public class LoginResponse : ResponseBase {
        public LoginModel loginModel {
            get; set;
        }
        public LoginResponse() {
            loginModel = new LoginModel();
        }
    }

    [DataContract]
    public class LoginRequest : RequestBase {
        public LoginModel loginModel {
            get; set;
        }
        public LoginRequest() {
            loginModel = new LoginModel();
        }
    }
}