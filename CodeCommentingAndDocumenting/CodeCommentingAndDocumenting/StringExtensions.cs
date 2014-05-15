namespace Telerik.ILS.Common
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Text.RegularExpressions;

    /// <summary>
    /// This class adds some useful extensions for working with strings in .NET
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Following method returns MD5 hash code
        /// </summary>
        /// <param name="input">String parameter for input</param>
        /// <returns>Hexadecimal string</returns>
        public static string ToMd5Hash(this string input)
        {
            var md5Hash = MD5.Create();

            // Convert the input string to a byte array and compute the hash.
            var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new StringBuilder to collect the bytes
            // and create a string.
            var builder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                builder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return builder.ToString();
        }

        /// <summary>
        /// This method checks whether a string can be considered as 'true' or 'false'
        /// </summary>
        /// <param name="input">String parameter to input</param>
        /// <returns>Boolean value</returns>
        public static bool ToBoolean(this string input)
        {
            var stringTrueValues = new[] { "true", "ok", "yes", "1", "да" };

            return stringTrueValues.Contains(input.ToLower());
        }

        /// <summary>
        /// This method converts string to short data type, if possible
        /// </summary>
        /// <param name="input">String parameter</param>
        /// <returns>Short data type parameter</returns>
        public static short ToShort(this string input)
        {
            short shortValue;
            short.TryParse(input, out shortValue);

            return shortValue;
        }

        /// <summary>
        /// This method converts string to integer, if possible
        /// </summary>
        /// <param name="input">String parameter to input</param>
        /// <returns>Integer data type parameter</returns>
        public static int ToInteger(this string input)
        {
            int integerValue;
            int.TryParse(input, out integerValue);

            return integerValue;
        }

        /// <summary>
        /// This method converts string to long, if possible
        /// </summary>
        /// <param name="input">String parameter to input</param>
        /// <returns>Long data type parameter</returns>
        public static long ToLong(this string input)
        {
            long longValue;
            long.TryParse(input, out longValue);

            return longValue;
        }

        /// <summary>
        /// This method converts string to DateTime, if possible
        /// </summary>
        /// <param name="input">String parameter to input</param>
        /// <returns>DateTime data type parameter</returns>
        public static DateTime ToDateTime(this string input)
        {
            DateTime dateTimeValue;
            DateTime.TryParse(input, out dateTimeValue);

            return dateTimeValue;
        }

        /// <summary>
        /// This method makes the first letter of a string capital.
        /// </summary>
        /// <param name="input">String parameter to input</param>
        /// <returns>String with a capital first letter</returns>
        public static string CapitalizeFirstLetter(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            return input.Substring(0, 1).ToUpper(CultureInfo.CurrentCulture) + input.Substring(1, input.Length - 1);
        }

        /// <summary>
        /// This method returns a string starting end ending with given strings
        /// </summary>
        /// <param name="input">String input to be searched</param>
        /// <param name="startString">Substring the result should starts with</param>
        /// <param name="endString">Substring the result should ends with</param>
        /// <param name="startFrom">Starting index</param>
        /// <returns>String between starting and ending strings</returns>
        public static string GetStringBetween(this string input, string startString, string endString, int startFrom = 0)
        {
            input = input.Substring(startFrom);
            startFrom = 0;

            if (!input.Contains(startString) || !input.Contains(endString))
            {
                return string.Empty;
            }

            var startPosition = input.IndexOf(startString, startFrom, StringComparison.Ordinal) + startString.Length;

            if (startPosition == -1)
            {
                return string.Empty;
            }

            var endPosition = input.IndexOf(endString, startPosition, StringComparison.Ordinal);

            if (endPosition == -1)
            {
                return string.Empty;
            }

            return input.Substring(startPosition, endPosition - startPosition);
        }

        /// <summary>
        /// This method converts Cyrillic to Latin letters
        /// </summary>
        /// <param name="input">String input parameter</param>
        /// <returns>String representing Cyrillic text with Latin letters</returns>
        public static string ConvertCyrillicToLatinLetters(this string input)
        {
            var bulgarianLetters = new[]
                                       {
                                           "а", "б", "в", "г", "д", "е", "ж", "з", "и", "й", "к", "л", "м", "н", "о", "п",
                                           "р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ь", "ю", "я"
                                       };

            var latinRepresentationsOfBulgarianLetters = new[]
                                                             {
                                                                 "a", "b", "v", "g", "d", "e", "j", "z", "i", "y", "k",
                                                                 "l", "m", "n", "o", "p", "r", "s", "t", "u", "f", "h",
                                                                 "c", "ch", "sh", "sht", "u", "i", "yu", "ya"
                                                             };

            for (var i = 0; i < bulgarianLetters.Length; i++)
            {
                input = input.Replace(bulgarianLetters[i], latinRepresentationsOfBulgarianLetters[i]);
                input = input.Replace(bulgarianLetters[i].ToUpper(), latinRepresentationsOfBulgarianLetters[i].CapitalizeFirstLetter());
            }

            return input;
        }

        /// <summary>
        /// This method converts Latin to Cyrillic letters
        /// </summary>
        /// <param name="input">String input parameter</param>
        /// <returns>String representing Latin text with Cyrillic letters</returns>
        public static string ConvertLatinToCyrillicKeyboard(this string input)
        {
            var latinLetters = new[]
                                   {
                                       "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p",
                                       "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"
                                   };

            var bulgarianRepresentationOfLatinKeyboard = new[]
                                                             {
                                                                 "а", "б", "ц", "д", "е", "ф", "г", "х", "и", "й", "к",
                                                                 "л", "м", "н", "о", "п", "я", "р", "с", "т", "у", "ж",
                                                                 "в", "ь", "ъ", "з"
                                                             };

            for (int i = 0; i < latinLetters.Length; i++)
            {
                input = input.Replace(latinLetters[i], bulgarianRepresentationOfLatinKeyboard[i]);
                input = input.Replace(latinLetters[i].ToUpper(), bulgarianRepresentationOfLatinKeyboard[i].ToUpper());
            }

            return input;
        }

        /// <summary>
        /// This method turns username written with Cyrillic letters to a valid username written with Latin letters
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string ToValidUsername(this string input)
        {
            input = input.ConvertCyrillicToLatinLetters();

            return Regex.Replace(input, @"[^a-zA-z0-9_\.]+", string.Empty);
        }

        /// <summary>
        /// This method turns filename written with Cyrillic letters to a valid filename written with Latin letters
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string ToValidLatinFileName(this string input)
        {
            input = input.Replace(" ", "-").ConvertCyrillicToLatinLetters();

            return Regex.Replace(input, @"[^a-zA-z0-9_\.\-]+", string.Empty);
        }

        /// <summary>
        /// This method return given count of the first string chars
        /// </summary>
        /// <param name="input">String input parameter</param>
        /// <param name="charsCount">Chars count parameter</param>
        /// <returns>Specific count of the first string characters</returns>
        public static string GetFirstCharacters(this string input, int charsCount)
        {
            return input.Substring(0, Math.Min(input.Length, charsCount));
        }

        /// <summary>
        /// This method return the file extension of a given filename
        /// </summary>
        /// <param name="fileName">String input parameter</param>
        /// <returns>File extension</returns>
        public static string GetFileExtension(this string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                return string.Empty;
            }

            string[] fileParts = fileName.Split(new[] { "." }, StringSplitOptions.None);

            if (fileParts.Count() == 1 || string.IsNullOrEmpty(fileParts.Last()))
            {
                return string.Empty;
            }

            return fileParts.Last().Trim().ToLower();
        }

        /// <summary>
        /// This method return the type of file content considering the file extension
        /// </summary>
        /// <param name="fileExtension">String input as file extension</param>
        /// <returns>Content type according the the file extension</returns>
        public static string ToContentType(this string fileExtension)
        {
            var fileExtensionToContentType = new Dictionary<string, string>
                                                 {
                                                     { "jpg", "image/jpeg" },
                                                     { "jpeg", "image/jpeg" },
                                                     { "png", "image/x-png" },
                                                     {
                                                         "docx",
                                                         "application/vnd.openxmlformats-officedocument.wordprocessingml.document"
                                                     },
                                                     { "doc", "application/msword" },
                                                     { "pdf", "application/pdf" },
                                                     { "txt", "text/plain" },
                                                     { "rtf", "application/rtf" }
                                                 };

            if (fileExtensionToContentType.ContainsKey(fileExtension.Trim()))
            {
                return fileExtensionToContentType[fileExtension.Trim()];
            }

            return "application/octet-stream";
        }

        /// <summary>
        /// This method converts string to a byte[] array 
        /// /// </summary>
        /// <param name="input">String input parameter</param>
        /// <returns>Byte array</returns>
        public static byte[] ToByteArray(this string input)
        {
            var bytesArray = new byte[input.Length * sizeof(char)];
            Buffer.BlockCopy(input.ToCharArray(), 0, bytesArray, 0, bytesArray.Length);

            return bytesArray;
        }
    }
}
