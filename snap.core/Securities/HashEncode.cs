﻿using System;
using System.Collections.Generic;
using System.Text;

using System.Security.Cryptography;

namespace Snapp.Core.Securities
{
    public static class HashEncode
    {
        public static string GetHashCode(string password)
        {
            Byte[] mainBytes;
            Byte[] encodeBytes;

            MD5 md5;

            md5 = new MD5CryptoServiceProvider();

            mainBytes = ASCIIEncoding.Default.GetBytes(password);
            encodeBytes = md5.ComputeHash(mainBytes);

            return BitConverter.ToString(encodeBytes);
        }
    }
}
