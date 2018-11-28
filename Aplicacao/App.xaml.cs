using System;
using System.Linq;
using System.Windows;
using Aplicacao.Config;

namespace Aplicacao {

    public partial class App : Application {

        public App() {
            //http://www.andrealveslima.com.br/blog/index.php/2015/09/02/armazenando-bibliotecas-em-subdiretorios-no-c/
            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(ResolveAssemblyEventArgs);

            this.Startup += new StartupEventHandler(S_Startup);
        }

        private System.Reflection.Assembly ResolveAssemblyEventArgs(object sender, ResolveEventArgs args) {
            string folderPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string assemblyPath = System.IO.Path.Combine(folderPath, "Lib", new System.Reflection.AssemblyName(args.Name).Name + ".dll");
            if (!System.IO.File.Exists(assemblyPath)) return null;
            System.Reflection.Assembly assembly = System.Reflection.Assembly.LoadFrom(assemblyPath);
            return assembly;
        }

        private void S_Startup(object sender, StartupEventArgs e) {

            MainWindow mw = new MainWindow();

            if (System.Diagnostics.Process.GetProcessesByName("Imob - Sistema Imobiliario").Count() >= 2) {     //Perguntar o Andre pq desse CONUT >= 2
                EncerraApp();
            }
            else {
                ConectionString conString = new ConectionString();
                if (conString.ConectionStringExiste()) {
                    mw.ShowDialog();
                }
                else {
                    CriarXmlConnectionString xml = new CriarXmlConnectionString();
                    xml.ShowDialog();

                    mw.ShowDialog();
                }
            }
        }

        private void EncerraApp() {
            if (System.Windows.Application.Current != null)
                System.Windows.Application.Current.Shutdown();
        }
    }
}
