
using SirenValidity;

IAmTheTest validator = new SirenValidator();
bool tryAgain = true;
while (tryAgain)
{
    Console.WriteLine("Enter SIREN (9 digits) (or SIREN without control number (8 digits):");
    string sirenNumber = Console.ReadLine();
    bool isValid = validator.CheckSirenValidity(sirenNumber);
    Console.WriteLine($"Is the SIREN number valid? {isValid}");
    if (sirenNumber.Length == 8)
    { 
        string fullSiren = validator.ComputeFullSiren(sirenNumber);
    Console.WriteLine($"The full SIREN number is {fullSiren}");
}
    Console.WriteLine("Try again (y/n)?");
    tryAgain = (Console.ReadKey().KeyChar.ToString().ToLower() == "y");
    Console.WriteLine();
}