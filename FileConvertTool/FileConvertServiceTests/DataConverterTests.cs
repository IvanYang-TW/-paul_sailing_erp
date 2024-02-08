using FileConvertSerivce.Models.Product;
using FileConvertSerivce.Services;
using FileConvertService.Models.Customer;
using FileConvertService.Models.Supplier;
using FileConvertService.Services;
using System.Reflection.Metadata;
using System.Text.RegularExpressions;

namespace FileConvertServiceTests
{
    public class DataConverterTests
    {
        string DirPath = "D:\\瑋瑋服飾企業有限公司\\ErpStudio\\-paul_sailing_erp\\FileConvertTool\\FileConvertTool\\bin\\Debug\\net7.0-windows\\dbfFiles";

        [Fact]
        public void ConvertToNewProductData_ShouldConvertCorrectly()
        {
            // Arrange
            ProductService ps = new ProductService();
            IEnumerable<DosProduct> oldProduct = ps.GetDosData(Path.Combine(DirPath, "input\\jjzitm.dbf"));
            ps.GetCommentsDataAndExportToCsv(oldProduct, Path.Combine(DirPath, "output\\NewSystemSchema"));

            // Act
            var newProduct = ps.ConvertToNewSchemaData(oldProduct);
            FileService<Product>.ExportDataToExcel(newProduct,"Product", Path.Combine(DirPath, "output\\NewSystemSchema"));

            var DosOthersProduct = oldProduct
            .Where(x => !Regex.IsMatch(x.INO, @"^\d{4}-\d+\s*[A-Z]*"))
            .Select(x => x);
            FileService<DosProduct>.ExportDataToExcel(DosOthersProduct, "DosOthersProduct", Path.Combine(DirPath, "output\\NewSystemSchema"));

            // Assert
            //Assert.Equal(oldProduct.First().INO, newProduct.CODE);
        }

        [Fact]
        public void ConvertToNewCustomerData_ShouldConvertCorrectly()
        {
            // Arrange
            CustomerService cs = new CustomerService();
            IEnumerable<DosCustomer> oldProduct = cs.GetDosData(Path.Combine(DirPath, "input\\jjzbuy.dbf"));


            // Act
            var newProduct = cs.ConvertToNewSchemaData(oldProduct);
            FileService<Customer>.ExportDataToExcel(newProduct, "Customer", Path.Combine(DirPath, "output\\NewSystemSchema"));

            // Assert
        }

        [Fact]
        public void ConvertToNewSupplierData_ShouldConvertCorrectly()
        {
            // Arrange
            SupplierService ss = new SupplierService();
            IEnumerable<DosSupplier> oldProduct = ss.GetDosData(Path.Combine(DirPath, "input\\jjzsup.dbf"));


            // Act
            var newProduct = ss.ConvertToNewSchemaData(oldProduct);
            FileService<Supplier>.ExportDataToExcel(newProduct, "Supplier", Path.Combine(DirPath, "output\\NewSystemSchema"));

            // Assert
        }

        [Fact]
        public void GetDbfFileData_ShouldWork()
        {
            // Arrange
            // Act
            var result = new ProductService().GetDosData(Path.Combine(DirPath,"input\\jjzitm.dbf"));
            // Assert
            Assert.NotNull(result);

        }
    }

    public class ProductIngredientTests
    {
        string DirPath = "D:\\瑋瑋服飾企業有限公司\\ErpStudio\\-paul_sailing_erp\\FileConvertTool\\FileConvertTool\\bin\\Debug\\net7.0-windows\\dbfFiles";

        [Fact]
        public void GetDataFromCsvFile_ShouldWork()
        {
            // Arrange
            // Act
            var result = new IngredientService().GetDataFromCsvFile(Path.Combine(DirPath, "Sample\\Ingredient.csv"));
            // Assert
            Assert.NotNull(result);

        }

    }
}