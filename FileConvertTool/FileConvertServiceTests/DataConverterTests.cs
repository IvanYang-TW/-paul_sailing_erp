using FileConvertSerivce.Models.Product;
using FileConvertSerivce.Services;
using System.Reflection.Metadata;
using System.Text.RegularExpressions;

namespace FileConvertServiceTests
{
    public class DataConverterTests
    {
        [Fact]
        public void ConvertToNewProductData_ShouldConvertCorrectly()
        {
            // Arrange
            ProductService ps = new ProductService();
            IEnumerable<DosProduct> oldProduct = ps.GetDosData("D:\\瑋瑋服飾企業有限公司\\ErpStudio\\-paul_sailing_erp\\FileConvertTool\\FileConvertTool\\bin\\Debug\\net7.0-windows\\dbfFiles\\input\\jjzitm.dbf");


            // Act
            var newProduct = ps.ConvertToNewSchemaData(oldProduct);
            FileService<Product>.ExportDataToExcel(newProduct,"Product", "D:\\瑋瑋服飾企業有限公司\\ErpStudio\\-paul_sailing_erp\\FileConvertTool\\FileConvertTool\\bin\\Debug\\net7.0-windows\\dbfFiles\\output");

            var DosOthersProduct = oldProduct
            .Where(x => !Regex.IsMatch(x.INO, @"^\d{4}-\d+\s*[A-Z]*"))
            .Select(x => x);
            FileService<DosProduct>.ExportDataToExcel(DosOthersProduct, "DosOthersProduct", "D:\\瑋瑋服飾企業有限公司\\ErpStudio\\-paul_sailing_erp\\FileConvertTool\\FileConvertTool\\bin\\Debug\\net7.0-windows\\dbfFiles\\output");

            // Assert
            //Assert.Equal(oldProduct.First().INO, newProduct.CODE);
        }

        [Fact]
        public void GetDbfFileData_ShouldWork()
        {
            // Arrange
            // Act
            var result = new ProductService().GetDosData("D:\\瑋瑋服飾企業有限公司\\ErpStudio\\-paul_sailing_erp\\FileConvertTool\\FileConvertTool\\bin\\Debug\\net7.0-windows\\dbfFiles\\input\\jjzitm.dbf");
            // Assert
            Assert.NotNull(result);

        }
    }
}