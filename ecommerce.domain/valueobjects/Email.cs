using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.domain.valueobjects;

public class Email
{
    private string EmailField { get;}

    private static string RegexEmail = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
    
    public Email(string EmailField)
    {
        if (string.IsNullOrWhiteSpace(EmailField))
            throw new ArgumentException("Email não pode ser vazio.");
        if (!System.Text.RegularExpressions.Regex.IsMatch(EmailField, RegexEmail))
            throw new ArgumentException("Email inválido.");
        EmailField = EmailField;
    }

    public string GetEmail() => EmailField;

    public static void ValidarFormato(string email)
    {
        throw new NotImplementedException();
    }
}
