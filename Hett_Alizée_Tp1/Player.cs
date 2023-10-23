using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hett_Alizée_Tp1
{
    internal class Player
    {
        private string FirstName { get; set; }
        private string LastName { get; set; }
        public string Alias { get; set; }
        public Spaceship? DefaultSpaceship { get; set; }

        public Player(string firstName, string lastName, string alias)
        {
            FirstName = FormatName(firstName);
            LastName = FormatName(lastName);
            Alias = alias;
        }

        private static string FormatName(string name)
        {
            if (string.IsNullOrEmpty(name)) return string.Empty;
            return $"{name.Substring(0, 1).ToUpper()}{name.Substring(1).ToLower()}";
        }

        public string Name => $"{FirstName} {LastName}";

        public override string ToString()
        {
            return $"{Alias} ({Name})";
        }

        public override bool Equals(object? obj)
        {
            if (obj is Player otherPlayer)
            {
                return Alias.Equals(otherPlayer.Alias);
            }
            return false;
        }
        public override int GetHashCode()
        {
            return Alias.GetHashCode();
        }
    }
}
