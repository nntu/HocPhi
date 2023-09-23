using System;
using System.Text.RegularExpressions;

namespace HocPhi
{
    static public class StringEx
    {
        /// <summary>
        /// Method deletes all non numeric characters from passed text
        /// </summary>
        /// <param name="text">string text</param>
        /// <returns>string text without non-numeric characters</returns>
        public static string RemoveNonNumeric(string text)
        {
            string newText = "";

            if (String.IsNullOrEmpty(text))
            {
                return newText;
            }

            newText = Regex.Replace(text, "[^0-9]", "");

            return newText;
        }
        //xoa ky tu dac biet
        public static string RemoveSpecialChars(string input)
        {
            return Regex.Replace(input, @"[^0-9a-zA-Z\., ]", string.Empty);
        }
        public static string RemoveVietnameseTone(string text)
        {
            string result = text.ToLower();
            result = Regex.Replace(result, "à|á|ạ|ả|ã|â|ầ|ấ|ậ|ẩ|ẫ|ă|ằ|ắ|ặ|ẳ|ẵ|/g", "a");
            result = Regex.Replace(result, "è|é|ẹ|ẻ|ẽ|ê|ề|ế|ệ|ể|ễ|ễ|/g", "e");
            result = Regex.Replace(result, "ì|í|ị|ỉ|ĩ|/g", "i");
            result = Regex.Replace(result, "ò|ó|ọ|ỏ|õ|ô|ồ|ố|ộ|ổ|ỗ|ơ|ờ|ớ|ợ|ở|ỡ|ọ|/g", "o");
            result = Regex.Replace(result, "ù|ú|ụ|ủ|ũ|ư|ừ|ứ|ự|ử|ữ|/g", "u");
            result = Regex.Replace(result, "ỳ|ý|ỵ|ỷ|ỹ|/g", "y");
            result = Regex.Replace(result, "đ", "d");
            return result;
        }
    }
}
