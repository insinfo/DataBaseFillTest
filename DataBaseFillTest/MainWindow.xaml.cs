using DataBaseFillTest.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DataBaseFillTest
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
       

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var c = new ContratoRepository();
            var f = new FakeGenerate();
            var dataInicio = f.GetRandomPastDate();
            var dataFim = f.GetRandomFutureDate();

            c.FillContratos(new Contrato() {                
                numeroProcesso= f.GetRandomNumber(),
                anoProcesso= dataInicio.Year,
                numeroContrato= f.GetRandomNumber(),
                anoContrato= dataInicio.Year,
                dataInicio= dataInicio,
                dataFim = dataFim,
                valor= f.GetRandomPrices(),
                custoPrevisto = f.GetRandomPrices(),
                modalidade= "Tecnológico",
                idSecretaria= f.GetRandomIdSecretaria(),
                idEmpresa= 7177,
                objeto= f.GetLoremIpsum(),
                observacao= f.GetLoremIpsum(),
                situacao= f.GetRandomStatus(),
            });

        }
    }
}
