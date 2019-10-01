using System;
using System.Linq;
using PasswordGenerator.Enums;

namespace PasswordGenerator {
    public static class Generator {
        static Random Random = new Random();

        public static string Generate(PasswordType type) {
            var chars = GetAvailableChars(type);
            var password = string.Empty;
            for(var i = 0; i < 16; i++) {
                password += chars[Random.Next(chars.Length)];
            }
            return password;
        }

        static char[] GetAvailableChars(PasswordType type) {
            switch(type) {
                case PasswordType.Low:
                    return "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWYX1234567890".ToCharArray();
                case PasswordType.High:
                    return GetAvailableChars(PasswordType.Low).Concat("!@#$%^&*()_+-=".ToCharArray()).ToArray();
                default:
                    throw new NotImplementedException();
            }
        }
    }
}