using NUnit;
using NUnit.Framework;


namespace SirenValidity;
[TestFixture]
public class SirenValidatorTests
{
    private IAmTheTest _validator;

    [SetUp]
    public void Setup()
    {
        _validator = new SirenValidator();
    }

    [Test]
    [TestCase("123456782", true)]  // Numéro SIREN valide
    [TestCase("123456789", false)] // Numéro SIREN invalide
    public void CheckSirenValidity_ReturnsCorrectResult(string siren, bool expectedValidity)
    {
        var result = _validator.CheckSirenValidity(siren);
        Assert.AreEqual(expectedValidity, result);
    }

    [Test]
    [TestCase("12345678", "123456782")] // Numéro SIREN sans chiffre de contrôle avec le résultat attendu
    public void ComputeFullSiren_ReturnsCorrectSiren(string sirenWithoutControlNumber, string expectedFullSiren)
    {
        var result = _validator.ComputeFullSiren(sirenWithoutControlNumber);
        Assert.AreEqual(expectedFullSiren, result);
    }

    [Test]
    public void ComputeFullSiren_ThrowsArgumentExceptionForInvalidInput()
    {
        var invalidSiren = "1234567"; // Moins de 8 chiffres
        Assert.Throws<ArgumentException>(() => _validator.ComputeFullSiren(invalidSiren));
    }
}