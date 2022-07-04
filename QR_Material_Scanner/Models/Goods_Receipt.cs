using Newtonsoft.Json;
using QR_Material_Scanner.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace QR_Material_Scanner.Models
{


    [Table("tran_GR_Information")]
    public class Goods_Receipt
    {
      
        [JsonProperty(PropertyName = "GR_Number")]
        [Column("GR_Number")]
        public string belnr { get; set; }
   
        [JsonProperty(PropertyName = "Line_Item_Number")]
        [Column("Line_Item_Number")]
        public string ebelp { get; set; }

        [JsonProperty(PropertyName = "Material_Number")]
        [Column("Material_Number")]
        public string matnr { get; set; }

        [JsonProperty(PropertyName = "Plant")]
        [Column("Plant")]
        public string werks { get; set; }

        [JsonProperty(PropertyName = "Storage_Location")]
        [Column("Storage_Location")]
        public string lgort { get; set; }

        [JsonProperty(PropertyName = "Vendor")]
        [Column("Vendor")]
        public string lifnr { get; set; }

        [JsonProperty(PropertyName = "PO_Number")]
        [Column("PO_Number")]
        public string ebeln { get; set; }

        [JsonProperty(PropertyName = "Quantity")]
        [Column("Quantity", TypeName = "decimal(18,2)")]
        public decimal menge { get; set; }

        [JsonProperty(PropertyName = "GR_Date")]
        [Column("GR_Date")]
        [JsonConverter(typeof(CustomDateTimeConverter), new object[] { "yyyy-MM-dd" })]
        public DateTime budat { get; set; }

        [JsonProperty(PropertyName = "Document_Date")]
        [Column("Document_Date")]
        [JsonConverter(typeof(CustomDateTimeConverter), new object[] { "yyyy-MM-dd" })]
        public DateTime bedat { get; set; }

       

        [JsonProperty(PropertyName = "Reference_Doc_No")]
        [Column("Reference_Doc_No")]
        public string xblnr { get; set; }
        [JsonProperty(PropertyName = "Movement_Type")]
        [Column("Movement_Type")]
        public string bwart { get; set; }

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




    //public class Goods_Receipt
    //{
        
    //    [JsonProperty(PropertyName = "belnr")]
    //    [Key]
    //    public string GR_Number { get; set; }

    //    [JsonProperty(PropertyName = "Line_Item_Number")]
    //    public string ebelp { get; set; }

    //    [JsonProperty(PropertyName = "Material_Number")]
    //    public string matnr { get; set; }

    //    [JsonProperty(PropertyName = "Plant")]
    //    public string werks { get; set; }

    //    [JsonProperty(PropertyName = "Storage_Location")]
    //    public string lgort { get; set; }

    //    [JsonProperty(PropertyName = "Vendor")]
    //    public string lifnr { get; set; }

    //    [JsonProperty(PropertyName = "PO_Number")]
    //    public string ebeln { get; set; }

    //    [JsonProperty(PropertyName = "Quantity")]
    //    //public decimal menge { get; set; }
    //    public string menge { get; set; }

    //    [JsonProperty(PropertyName = "GR_Date")]
    //    //public DateTime budat { get; set; }
    //    public string budat { get; set; }

    //    [JsonProperty(PropertyName = "Document_Date")]
    //    //public DateTime bedat { get; set; }
    //    public string bedat { get; set; }


    //    public string Created_By { get; set; } = "SAP";

    //    public DateTime Creation_Date { get; set; } = DateTime.Now;

    //    [NotMapped]
    //    public string Modified_By { get; set; }
    //    [NotMapped]
    //    public DateTime? Modification_Date { get; set; }

    //}
    public class Result_Goods_Receipt
    { 
        public string Status_Code { get; set; }
        public string Status { get; set; }
    }
}
