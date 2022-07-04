using Newtonsoft.Json;
using QR_Material_Scanner.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace QR_Material_Scanner.Models
{
    [Table("tran_Delivery_Information")]
    public class Delivery_Receipt
    {
        [JsonProperty(PropertyName = "Delivery_Number")]
        [Column("Delivery_Number")]
        public string vbeln { get; set; }

        [JsonProperty(PropertyName = "Line_Item_Number")]
        [Column("Line_Item_Number")]
        public string posnr { get; set; }
        [JsonProperty(PropertyName = "Customer_Number")]
        [Column("Customer_Number")]
        public string kunnr { get; set; }

        [JsonProperty(PropertyName = "Plant")]
        [Column("Plant")]
        public string werks { get; set; }

        [JsonProperty(PropertyName = "Shipping_Point")]
        [Column("Shipping_Point")]
        public string vstel { get; set; }

        [JsonProperty(PropertyName = "Storage_Location")]
        [Column("Storage_Location")]
        public string lgort { get; set; }

        [JsonProperty(PropertyName = "Material_Number")]
        [Column("Material_Number")]
        public string matnr { get; set; }

        [JsonProperty(PropertyName = "Quantity_To_Be_Picked")]
        [Column("Quantity_To_Be_Picked", TypeName = "decimal(18,2)")]
        public decimal lfimg { get; set; }

        [JsonProperty(PropertyName = "Sales_Order_Number")]
        [Column("Sales_Order_Number")]
        public string kdauf { get; set; }

        [JsonProperty(PropertyName = "Document_Date")]
        [Column("Document_Date")]
        [JsonConverter(typeof(CustomDateTimeConverter), new object[] { "yyyy-MM-dd" })]
        public DateTime bldat { get; set; }

        [JsonProperty(PropertyName = "Item_Category")]
        [Column("Item_Category")]
        public string pstyv { get; set; }

        [JsonProperty(PropertyName = "System_Id")]
        [Column("System_Id")]
        public string sysid { get; set; }
        public string Created_By { get; set; } = "SAP";

        public DateTime Creation_Date { get; set; } = DateTime.Now;

        [NotMapped]
        public string Modified_By { get; set; }
        [NotMapped]
        public DateTime? Modification_Date { get; set; }

    }


    public class Result_Delivery_Receipt
    {
        public string Status_Code { get; set; }
        public string Status { get; set; }

    }
}
