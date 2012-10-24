using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Net;
using System.Net.Security;

namespace ReadCer
{
    public class CertPolicy : ICertificatePolicy
    {
        // Methods
        public bool CheckValidationResult(ServicePoint sp, X509Certificate cert, WebRequest request, int problem)
        {
            return true;
        }
    }

 

}
