using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.application.interfaces;

public interface ISenhaService
{
    string GerarHash(string senhaPura);

    bool VerificarSenha(string senhaPura, string hash);
}
