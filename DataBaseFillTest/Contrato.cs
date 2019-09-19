using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseFillTest
{
    public class Contrato
    {
       public List<String> fields = new List<String>(new string[] {
           "numeroProcesso", "anoProcesso", "numeroContrato",
           "anoContrato", "dataInicio", "dataFim",
           "situacao",
           "modalidade", "idSecretaria", "idEmpresa",
           "objeto",  "observacao",  "valor",
           "custoPrevisto"
        });
        protected int id { get;  set; }
        public int numeroProcesso { get; set; }
        public int anoProcesso { get; set; }
        public int numeroContrato { get; set; }
        public int anoContrato { get; set; }
        public DateTime dataInicio { get; set; }
        public DateTime dataFim { get; set; }
        public String valor { get; set; }
        public String custoPrevisto { get; set; }
        public String modalidade { get; set; }
        public int idSecretaria { get; set; }
        public int idEmpresa { get; set; }
        public String objeto { get; set; }
        public String observacao { get; set; }
        public String situacao { get; set; }
    }
}
