using Microsoft.VisualStudio.TestTools.UnitTesting;
using PersonnummerValidering;

namespace PersonnummerValideringTest
{
    [TestClass]
    public class PersonnummerValidatorTests
    {
        [TestMethod]
        public void Validera_KorrektPersonnummer_ReturnerarTrue()
        {
            string korrektPersonnummer = "8507099805";
            bool resultat = PersonnummerValidator.ValideraPersonnummer(korrektPersonnummer);
            Assert.IsTrue(resultat, "Ett korrekt personnummer borde returnera true.");
        }

        [TestMethod]
        public void Validera_FelaktigtPersonnummer_ReturnerarFalse()
        {
            string felaktigtPersonnummer = "8507099804";
            bool resultat = PersonnummerValidator.ValideraPersonnummer(felaktigtPersonnummer);
            Assert.IsFalse(resultat, "Ett felaktigt personnummer borde returnera false.");
        }

        [TestMethod]
        public void Validera_FörKortPersonnummer_ReturnerarFalse()
        {
            string kortPersonnummer = "85070998";
            bool resultat = PersonnummerValidator.ValideraPersonnummer(kortPersonnummer);
            Assert.IsFalse(resultat, "Ett för kort personnummer borde returnera false.");
        }

        [TestMethod]
        public void Validera_PersonnummerMedBindestreck_ReturnerarTrue()
        {
            string personnummerMedBindestreck = "850709-9805";
            bool resultat = PersonnummerValidator.ValideraPersonnummer(personnummerMedBindestreck);
            Assert.IsTrue(resultat, "Ett korrekt personnummer med bindestreck borde returnera true.");
        }

        [TestMethod]
        public void Validera_PersonnummerMedTolvSiffror_ReturnerarTrue()
        {
            string personnummerMedTolvSiffror = "198507099805";
            bool resultat = PersonnummerValidator.ValideraPersonnummer(personnummerMedTolvSiffror);
            Assert.IsTrue(resultat, "Ett korrekt tolvsiffrigt personnummer borde returnera true.");
        }
    }
}
