using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseFillTest
{
    public class FakeGenerate
    {
        Random random;
        double old_price = 2806.59;
        public FakeGenerate() {
            random = new Random();
        }

        public int GetRandomNumber()
        {
            int month = random.Next(1, 5800);
            return month;
        }

        public string GetRandomStatus()
        {
            List<string> status = new List<string> { "Aberto", "Rescindido", "Andamento", "Anulado",
                "Concluido", "Paralisado"};
            int index = random.Next(status.Count);
            return status[index];
        }

        public int GetRandomIdSecretaria()
        {
            List<int> idSecretaria = new List<int> { 1, 2, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 128, 129 };
            int index = random.Next(idSecretaria.Count);
            return idSecretaria[index];
        }

        public DateTime GetRandomPastDate()
        {
            int range = 5 * 365; //5 years          
            DateTime randomDate = DateTime.Today.AddDays(-random.Next(range));
            return randomDate;
        }

        public string GetRandomPrices()
        {

            double rnd = random.NextDouble(); // generate number, 0 <= x < 1.0
            double volatility = 11;
            double change_percent = 2 * volatility * rnd;
            if (change_percent > volatility)
                change_percent -= (2 * volatility);
            double change_amount = old_price * change_percent;
            double new_price = old_price + change_amount;
            old_price = new_price;
            return "R$ " + Math.Abs(new_price).ToString();
        }

        public string GetLoremIpsum(int minWords = 3, int maxWords = 10,
            int minSentences = 1, int maxSentences = 6,
            int numParagraphs = 2)
        {

            var words = new[]{"Constitui", "objeto", "presente", "prestação", "serviços", "assessoria",
                "comercial", "busca", "negócios", "oportunidades", "informática", "nibh", "euismod",
                "legítima", "constituído", "laoreet", "As", "na", "de", "fizerem",
                "atividades", "ut", "mediante", "As", "na", "de", "fizerem",
                "O", "contrato", "tem", "como", "objeto", "a aquisição de", "visando",
                "atender", "às", "do", "As", "seus Anexos", "de", "Edital",
                "atividades", "conforme", "especificações", "quantitativos", "estabelecidos", "Termo", "Referência",

                    };

            var rand = new Random();
            int numSentences = rand.Next(maxSentences - minSentences)
                + minSentences + 1;
            int numWords = rand.Next(maxWords - minWords) + minWords + 1;

            StringBuilder result = new StringBuilder();

            for (int p = 0; p < numParagraphs; p++)
            {
                result.Append("");//"<p>"
                for (int s = 0; s < numSentences; s++)
                {
                    for (int w = 0; w < numWords; w++)
                    {
                        if (w > 0) { result.Append(" "); }
                        result.Append(words[rand.Next(words.Length)]);
                    }
                    result.Append(". ");
                }
                result.Append("/r/n ");//"</p>"
            }

            return result.ToString();
        }

        public DateTime GetRandomFutureDate()
        {
            int range = 5 * 365; //5 years          
            DateTime randomDate = DateTime.Today.AddDays(random.Next(range));
            return randomDate;
        }


    }
}
