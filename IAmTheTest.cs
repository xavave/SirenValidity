using System.Globalization;

namespace SirenValidity
{
    interface IAmTheTest
    {
        bool CheckSirenValidity(string siren);
        // Returns the full siren from the sirenWithoutControlNumber
        string ComputeFullSiren(string sirenWithoutControlNumber);
    }

    public class SirenValidator : IAmTheTest
    {
        public bool CheckSirenValidity(string siren)
        {
            if (siren.Length != 9 || !long.TryParse(siren, out _))
            {
                return false;
            }

            int sum = CalcChecksum(siren);

            return sum % 10 == 0;
        }

        private static int CalcChecksum(string siren)
        {
            int sum = 0;
            for (int i = 0; i < siren.Length; i++)
            {
                int digit = int.Parse(siren[i].ToString());
                if (i % 2 == 1) // Remember to adjust the index for 0-based array
                {
                    digit *= 2;
                    if (digit > 9)
                    {
                        digit -= 9;
                    }
                }

                sum += digit;
            }

            return sum;
        }

        public string ComputeFullSiren(string sirenWithoutControlNumber)
        {
            if (sirenWithoutControlNumber.Length != 8 || !long.TryParse(sirenWithoutControlNumber, out _))
            {
                throw new ArgumentException("The SIREN without control number must be 8 digits long");
            }

            int sum = CalcChecksum(sirenWithoutControlNumber);

            // The control number is such that the sum of digits plus the control number
            // must be a multiple of 10. Hence, we compute the control number as follows:
            int controlNumber = (10 - (sum % 10)) % 10;

            return sirenWithoutControlNumber + controlNumber.ToString();
        }
    }
}
