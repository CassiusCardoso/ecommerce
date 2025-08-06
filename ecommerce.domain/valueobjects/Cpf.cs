using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.domain.valueobjects
{
    public class Cpf
    {
        private string CpfField { get; }
        private static string RegexCpf = @"^\d{3}\.\d{3}\.\d{3}-\d{2}$"; // Formato: 123.456.789-01

        public Cpf(String CpfField) 
        {
            if (!CpfField.Equals(RegexCpf))
            {
                throw new Exception("CPF inválido. O formato deve ser 123.456.789-01.");
            }
            if (string.IsNullOrWhiteSpace(CpfField))
            {
                throw new ArgumentException("CPF não pode ser vazio.");
            }

            string cpfLimpo = CpfField.Replace(".", "").Replace("-", "");

            this.CpfField = cpfLimpo;
        }

        public string GetCpf() => CpfField;
  

        public bool IsValid()
        {
            // Implementar a lógica de validação do CPF, se necessário
            // Por enquanto, apenas retorna true se o formato estiver correto
            return System.Text.RegularExpressions.Regex.IsMatch(CpfField, RegexCpf);
        }

        public static void ValidarFormato(string cpf)
        {
            throw new NotImplementedException();
        }
    }
}
