using DBinz.Data.Models.Enums;

namespace DBinz.Data.Models
{
    public class ColumnDetails
    {
        public string Name { get; set; }
        public SqlDataType SQLDataType { get; set; }
        public int? Length { get; set; }
    }
}