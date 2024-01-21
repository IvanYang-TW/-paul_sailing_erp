using FileConvertSerivce.Models.Product;
using FileConvertSerivce.Services;
using System.Reflection.Metadata;

namespace FileConvertServiceTests
{
    public class DataConverterTests
    {
        [Fact]
        public void ConvertToNewProductData_ShouldConvertCorrectly()
        {
            // Arrange
            IEnumerable<DosProduct> oldProduct = new List<DosProduct>{
                new DosProduct
                {
                    INO = "1951-7 A",
                    SPEC = "�l��Ʀ��u�SPOLO�m",
                    UNIT = "��",
                    COLOR = "�����",
                    SIZE = "S",
                    PRIC = 210.00M,
                    COST = 0,
                    QTY = 14,
                    DATE = "111.05.03",
                    REMK = "(S-4L)",
                    SAFE = 1050.00M,
                    REM1 = "�E��ֺ�   100%",
                    REM2 = "�ä[�Ʀ��ĪG"
                },
                new DosProduct
                {
                    INO = "1951-7 B",
                    SPEC = "�l��Ʀ��u�SPOLO�m",
                    UNIT = "��",
                    COLOR = "�����",
                    SIZE = "M",
                    PRIC = 210.00M,
                    COST = 0,
                    QTY = 99,
                    DATE = "111.05.03",
                    REMK = "(S-4L)",
                    SAFE = 1050.00M,
                    REM1 = "�E��ֺ�   100%",
                    REM2 = "�ä[�Ʀ��ĪG"
                },
                new DosProduct
                {
                    INO = "1951-9 A",
                    SPEC = "�l��Ʀ��u�SPOLO�m",
                    UNIT = "��",
                    COLOR = "������",
                    SIZE = "S",
                    PRIC = 210.00M,
                    COST = 0,
                    QTY = 22,
                    DATE = "109.09.03",
                    REMK = "(S-4L)",
                    SAFE = 1050.00M,
                    REM1 = "�E��ֺ�   100%",
                    REM2 = "�ä[�Ʀ��ĪG"
                }
            };
            oldProduct = ProductService.GetDosData("D:\\޳޳�A�����~�������q\\ErpStudio\\-paul_sailing_erp\\FileConvertTool\\FileConvertTool\\bin\\Debug\\net7.0-windows\\dbfFiles\\input\\jjzitm.dbf");


            // Act
            var newProduct = ProductService.ConvertToNewSchemaData(oldProduct);
            FileService<Product>.ExportDataToExcel(newProduct,"Product", "D:\\޳޳�A�����~�������q\\ErpStudio\\-paul_sailing_erp\\FileConvertTool\\FileConvertTool\\bin\\Debug\\net7.0-windows\\dbfFiles\\output");
            // Assert
            //Assert.Equal(oldProduct.First().INO, newProduct.CODE);
        }

        [Fact]
        public void GetDbfFileData_ShouldWork()
        {
            // Arrange
            // Act
            var result = ProductService.GetDosData("D:\\޳޳�A�����~�������q\\ErpStudio\\-paul_sailing_erp\\FileConvertTool\\FileConvertTool\\bin\\Debug\\net7.0-windows\\dbfFiles\\input\\jjzitm.dbf");
            // Assert
            Assert.NotNull(result);

        }
    }
}