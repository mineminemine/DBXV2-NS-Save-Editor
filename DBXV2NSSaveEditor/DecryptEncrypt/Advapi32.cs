using System;
using System.Runtime.InteropServices;

namespace DBXV2NSSaveEditor
{
    class Advapi32
    {
        #region CONSTS

        public const int PROV_RSA_FULL = 1;
        public const uint CRYPT_VERIFYCONTEXT = 0xF0000000;

        #endregion

        #region FUNCTIONS (IMPORTS)

        [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool CryptAcquireContext(
            ref IntPtr phProv,
            string pszContainer,
            string pszProvider,
            uint dwProvType,
            uint dwFlags
        );

        [DllImport("advapi32.dll", SetLastError = true)]
        public static extern bool CryptGenRandom(
            IntPtr hProv,
            uint dwLen,
            byte[] pbBuffer
        );

        [DllImport("Advapi32.dll", EntryPoint = "CryptReleaseContext", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern bool CryptReleaseContext(
            IntPtr hProv,
            Int32 dwFlags
        );

        #endregion
    }
}