using System.Data;

namespace Tests
{
    [TestClass]
    public class FileServiceTest
    {
        [TestMethod]
        public void ReadQueryFromFileTest()
        {
            // Arrange
            var testPath = $"{Environment.CurrentDirectory}\\example_input.txt";
            var expectedQuery = "SELECT P.ProductName, C.CategoryName\r\nFROM Products P\r\nLEFT JOIN ProductCategory PC ON P.ProductID = PC.ProductID\r\nLEFT JOIN Categories C ON PC.CategoryID = C.CategoryID;";

            // Act
            var result =  FileService.ReadQueryFromFile(testPath);

            // Assert
            Assert.AreEqual(expectedQuery, result);
        }

        [TestMethod]
        public void WriteResultToCsvTest()
        {
            // Arrange
            var testQuery = "SELECT P.ProductName, C.CategoryName\r\nFROM Products P\r\nLEFT JOIN ProductCategory PC ON P.ProductID = PC.ProductID\r\nLEFT JOIN Categories C ON PC.CategoryID = C.CategoryID;";
            var testConStr = $"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFileName={Environment.CurrentDirectory}\\Data\\Database.mdf;integrated security=true;database=Database;TrustServerCertificate=True";
            var queryResult = QueryExecutor.ExecuteQuery(testQuery, testConStr);
            var testPath = $"{Environment.CurrentDirectory}\\test_output.csv";
            var expectedResult = File.ReadAllText($"{Environment.CurrentDirectory}\\example_output.csv");

            // Act
            FileService.WriteResultToCsv(queryResult, testPath);
            var result = File.ReadAllText(testPath);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedResult, result);
            File.Delete(testPath);
        }
    }
}