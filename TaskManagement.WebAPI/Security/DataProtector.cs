using Microsoft.AspNetCore.DataProtection;

namespace TaskManagement.WebAPI.Security
{
    public class DataProtector
    {
        private readonly IDataProtector _protector;

        public DataProtector(IDataProtectionProvider provider)
        {
            _protector = provider.CreateProtector("ProtectCritical");
        }

        public string Protect(string plainText)
        {
            string protectedText = _protector.Protect(plainText);
            return protectedText;
        }
        public string UnProtect(string protectedText)
        {
            string plainText = _protector.Unprotect(protectedText);
            return plainText;
        }
    }
}
