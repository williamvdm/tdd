using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace tdd.Server.Extensions
{
    public static class ExtensionClass
    {
        public static int CalculateAge(this DateTime birth)
        {
            // Geen bug, maar een incorrecte comment
            DateTime today = DateTime.Today;

            int age = today.Year - birth.Year;

            // Check of de verjaardag al is geweest dit jaar, zo nee, dan moeten we 1 jaar er vanaf halen.
            if (birth.Date > today.AddYears(-age))
            {
                age--;
            }

            return age;
        }
    }
}
