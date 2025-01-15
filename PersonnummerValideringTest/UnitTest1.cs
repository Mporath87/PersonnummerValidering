using NUnit.Framework;
namespace PersonnummerValidationTests
{
    [Test]
    public class ProgramTests
    {
        [Test]
        public void ValideraPersonnummer_ShouldReturnFalse_WhenPersonnummerIsTooShort()
        {
            // Arrange
            string shortPersonnummer = "1974567-890";
            //Act
            bool result = Program.ValideraPersonnummer(shortPersonnummer);
            // Assert
            Assert.IsFalse(result);
        }
        [Test]
        public void ValideraPersonnummer_ShouldReturnFalse_WhenPersonnummerIsTooLong()
        {
            // Arrange

            string longPersonnummer = "1988567890123-4567";
            // Act

            bool result = Program.ValideraPersonnummer(longPersonnummer);

            // Assert
            Assert.IsFalse(result);
        }
