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
    public class Material
    {
        public List<Material_Master> material_Masters { get; set; }
        public List<Material_Transaction> material_Transaction { get; set; }

    }

    [Table("mst_Material_Information")]
    public class Material_Master
    {
      
        [Column("Serial_Number")]
        public string GERNR { get; set; }
        
        [Column("Material_Number")]
        public string MATNR { get; set; }
       
        [Column("Vendor_Number")]
        public string LIFNR { get; set; }
       
        [Column("Year")]
        public string GJHAR { get; set; }
       
        [Column("Month")]
        public string ZMONTH { get; set; }
     
        [Column("Product_Description")]
        public string MATKX { get; set; }
       
        [Column("MRP", TypeName = "decimal(18,2)")]
        public decimal NETPR { get; set; }
     
        [Column("Machine_ID")]
        public string RFCMACH { get; set; }

        [JsonConverter(typeof(CustomDateTimeConverter), new object[] { "yyyy-MM-dd" })]
        [Column("Capturing_Date")]
        public DateTime ERDAT { get; set; }
       
        [Column("Created_By")]
        public string ERNAM { get; set; }

        [JsonConverter(typeof(CustomDateTimeConverter), new object[] { "yyyy-MM-dd" })]
        [Column("Creation_Date")]
        public DateTime BUDAT { get; set; }

        
        [Column("Modified_By")]
        public string AENAM { get; set; }

        [JsonConverter(typeof(CustomDateTimeConverter), new object[] { "yyyy-MM-dd" })]
        [Column("Modification_Date")]
        public DateTime? AEDAT { get; set; }

        [Column("Cancelled")]
        public string CANCEL { get; set; }
        [NotMapped]
        public string Flag { get; set; } = "N";

    }

    [Table("tran_Material_Transaction")]
    public class Material_Transaction
    {
        [Column("Serial_Number")]
        public string GERNR { get; set; }

        [Column("Transaction_Type")]
        public string ESART { get; set; }

        [Column("Document_No")]
        public string EBELN { get; set; }

        [Column("Line_Item_Number")]
        public string DZETILE { get; set; }

        [Column("Plant")]
        public string WERKS { get; set; }

        [Column("Storage_Location")]
        public string LGORT { get; set; }

        [Column("Ref_Doc_No")]
        public string XBLNR { get; set; }

        [Column("Status")]
        public string STATUS { get; set; }

        [Column("QA_Status")]
        public string QA_STATUS { get; set; }

        [Column("Scrap")]
        public string Scrap { get; set; }

        [Column("Cancellation_Indicator")]
        public string CANCEL { get; set; }

        [Column("Created_By")]
        public string ERNAM { get; set; }
        [JsonConverter(typeof(CustomDateTimeConverter), new object[] { "yyyy-MM-dd" })]
        [Column("Creation_Date")]
        public DateTime ERDAT{ get; set; }


      
        [NotMapped]
        //public DateTime ERNAM { get; set; }
        public string UZEIT { get { return Convert.ToDateTime(ERDAT).ToString("HH:mm"); } }


        [Column("Modified_By")]
        public string AENAM { get; set; }

        [JsonConverter(typeof(CustomDateTimeConverter), new object[] { "yyyy-MM-dd" })]
        [Column("Modification_Date")]
        public DateTime? AEDAT { get; set; }
        [NotMapped]
        public string Flag { get; set; } = "N";

    }


    
     
    public class Material_Single
    {
     
        [Key]
        public string Serial_Number { get; set; }
        public string Material_Number { get; set; }
        public string Vendor { get; set; }
        public string Year { get; set; }
        public string Month { get; set; }
        public string Product_Description { get; set; }
        public string MRP { get; set; }
        public string Machine_ID { get; set; }

        [JsonConverter(typeof(CustomDateTimeConverter), new object[] { "yyyy-MM-dd" })]
        public DateTime Capturing_Date { get; set; }
        public string Created_By { get; set; } = "Auto";
        public string Cancelled { get; set; }
        public string Transaction_Type { get; set; }
        public string Document_No { get; set; }
        public string Line_Item_Number { get; set; }
        public string Plant { get; set; }
        public string Storage_Location { get; set; }
        public string Ref_Doc_No { get; set; }
        public string Status { get; set; }
        public string QA_Status { get; set; }
        public string Scrap { get; set; }
        public string Cancellation_Indicator { get; set; }
        public string GR_Flag { get; set; }
        



    }

    public class Result_Material
    {
        [Key]
        public string Serial_Number { get; set; }
        public string Status_Code { get; set; }
        public string Status { get; set; }

    }
    public class Status
    {
        [Key]
        public string Status_Code { get; set; }
        public string Messsage { get; set; }

    }

    public class Dashboard_Chart
    {
   
        public string Document_No { get; set; }
        public string Material_Number { get; set; }
        public decimal Count { get; set; }

    }


}


