using AppControleFinanceiro.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace AppControleFinanceiro.Libraries.Converters
{
    public class ConverterTransacao : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Transacao transaction = (Transacao)value;
            if (transaction == null)
            {
                return "";
            }
            if (transaction.Tipo == TransacaoTipo.Entrada)
            {
                return transaction.Valor.ToString("C");
            }
            else
            {
                return $"- {transaction.Valor.ToString("C")}";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
