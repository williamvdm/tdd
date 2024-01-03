using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace tdd.Server.Extensions
{
    public static class ExtensionClass
    {
        public static int CalculateAge(this DateTime birth)
        {
            // TODO: Waarschijnlijk een bug, kijk ernaar Laurens want ik ben niet goed in wiskunde en rekenen en dat soort shit.
            DateTime today = DateTime.Today;

            int age = today.Year - birth.Year;

            // leap year check
            if (birth.Date > today.AddYears(-age))
            {
                age--;
            }

            return age;
        }
    }
}
