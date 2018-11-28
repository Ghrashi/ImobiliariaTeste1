using System;
using System.Xml;

namespace Aplicacao.Config {
    public class ConectionString {

        String conectionString = string.Empty;
        String _instancia = string.Empty;
        String _bd = string.Empty;
        String _usuario = string.Empty;
        String _senha = string.Empty;

        public ConectionString() {
            conectionString = System.IO.Path.Combine(Environment.CurrentDirectory, "ConnectionString.xml");
        }

        public string Instancia {
            get { return _instancia; }
            set {
                if(value != null) {
                    _instancia = value;
                }
            }
        }

        public string Bd {
            get { return _bd; }
            set {
                if (value != null) {
                    _bd = value;
                }
            }
        }

        public string Usuario {
            get { return _usuario; }
            set {
                if (value != null) {
                    _usuario = value;
                }
            }
        }

        public string Senha {
            get { return _senha; }
            set {
                if (value != null) {
                    _senha = value;
                }
            }
        }

        public bool ExistsXml {
            get {
                return System.IO.File.Exists(conectionString);
            }
        }
 
        public bool ConectionStringExiste() {
            if (ExistsXml)
                return true;
            else {
                return false;
            }
        }

        public void CriarConnectioString() {
            XmlWriter xmlCS = XmlWriter.Create("ConnectionString.xml");

            xmlCS.WriteStartDocument();
            xmlCS.WriteStartElement("conexaoBD");
            xmlCS.WriteElementString("instancia", _instancia);
            xmlCS.WriteElementString("bancoDados", _bd);
            xmlCS.WriteElementString("usuario", _usuario);
            xmlCS.WriteElementString("senha", _senha);
            xmlCS.WriteEndElement();
            xmlCS.WriteEndDocument();
            xmlCS.Close();
        }
    }
}
