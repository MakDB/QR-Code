using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using QR_Material_Scanner.Models;
using QR_Material_Scanner.Helpers;
using Microsoft.Extensions.Configuration;
using QR_Material_Scanner.Services;
using System.Web;

namespace QR_Material_Scanner.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class P20551Controller : ControllerBase
    {
    private readonly IRepository repository;
        private readonly IConfiguration configuration;
        private readonly IMailService emailSender;

        public P20551Controller(IRepository repository, IConfiguration _configuration, IMailService _emailSender)
        {
            this.repository = repository;
            this.configuration = _configuration;
            this.emailSender = _emailSender;

        }
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
      

        [HttpGet]
        public string[]  Get()
        {

         return   Summaries.ToArray();
        }


        [HttpPost("/api/[controller]/z_GR_Details")]
        public ContentResult z_GR_Details(List<Goods_Receipt> goods_Receipt)
        {
            Result_Goods_Receipt result_Goods_Receipt = new Result_Goods_Receipt();
            SendPushNotification sendPushNotification = new SendPushNotification(repository, configuration);
            result_Goods_Receipt = repository.Add_Goods_Receipt(goods_Receipt);

            if (result_Goods_Receipt.Status_Code == "200")
            {
                for (int i = 0; i < goods_Receipt.Count; i++)
                {
                    Notification noti = new Notification();
                    if (goods_Receipt[i].bwart == "651")
                    {
                        noti.title = "😊 New Sales Return 🔙";
                        noti.content = "New Sales Return Added 👉 " + goods_Receipt[i].belnr;
                        noti.openUrl = "/Sales_Return";
                    }
                    else
                    {
                        noti.title = "😊 New Goods Receipt 📦";
                        noti.content = "New Goods Receipt Added 👉 " + goods_Receipt[i].belnr;
                        noti.openUrl = "/Goods_Receipts"; 


                    }

                    sendPushNotification.SendNotificationOnPlant(goods_Receipt[i].werks, noti);
                }

            }
            

            return Content(JsonConvert.SerializeObject(result_Goods_Receipt), "application / json");

        }

        [HttpPost("/api/[controller]/z_Sales_Order")]
        public ContentResult z_Sales_Order(List<Delivery_Receipt> delivery_Receipt)
        {
            Result_Delivery_Receipt result_Delivery_Receipt = new Result_Delivery_Receipt();
            SendPushNotification sendPushNotification = new SendPushNotification(repository, configuration);
            result_Delivery_Receipt = repository.Add_Delivery_Receipt(delivery_Receipt);

            if (result_Delivery_Receipt.Status_Code == "200")
            {
                for (int i = 0; i < delivery_Receipt.Count; i++)
                {
                    Notification noti = new Notification();
                    noti.title = "😊 New Delivery Challan 🚚";
                    noti.content = "New Delivery Receipt Added 👉 " + delivery_Receipt[i].vbeln;
                    noti.openUrl = "/delivery";
                    sendPushNotification.SendNotificationOnPlant(delivery_Receipt[i].werks, noti);

                }

            }


            return Content(JsonConvert.SerializeObject(result_Delivery_Receipt), "application / json");

        }

        [HttpGet("/api/[controller]/z_Serial_Details/{SyncDateTime}/{Type}")]

        public ContentResult z_Serial_Details(DateTime SyncDateTime, string Type)
        {
            //List<Material_Master> material_Master = new List<Material_Master>();
            //List<Material_Transaction> material_Transaction = new List<Material_Transaction>();
            Material material = new Material();
            material.material_Masters = repository.Get_Material_Master(SyncDateTime);
            material.material_Transaction = repository.Get_Material_Transaction(SyncDateTime, Type);
         
            return Content(JsonConvert.SerializeObject(material), "application / json");

        }


        [HttpGet("/api/[controller]/C_Get_GR_Details/{GR_Number}/{Type}")]

        public ContentResult C_Get_GR_Details(string GR_Number, string Type)

        {
            List<Goods_Receipt> goods_Receipts = new List<Goods_Receipt>();

            var gr = HttpUtility.UrlDecode(GR_Number);

            goods_Receipts = repository.Get_Goods_Receipt(gr, Type);
            return Content(JsonConvert.SerializeObject(goods_Receipts), "application / json");

        }


        [HttpPost("/api/[controller]/C_Insert_Goods_Receipt")]
        public ContentResult C_Insert_Goods_Receipt(Material_Single material)
        {
            Result_Material result_Material = new Result_Material();


            material.Transaction_Type = "GR";
            //var nu = "'"+ material.Serial_Number + "','" + material.Material_Number + "','" + material.Vendor + "','" + material.Year + "','" + material.Month + "','" + material.Product_Description + "','" + Convert.ToDecimal(material.MRP) + "','" + material.Machine_ID + "','" + Convert.ToDateTime(material.Capturing_Date).ToString("yyyy-MM-dd HH:mm:ss") + "','" + material.Created_By + "','" + material.Cancelled + "','" + material.Transaction_Type + "','" + material.Document_No + "','" + material.Line_Item_Number + "','" + material.Plant + "','" + material.Storage_Location + "','" + material.Ref_Doc_No + "','" + material.Status + "','" + material.QA_Status + "','" + material.Scrap + "','" + material.Cancellation_Indicator + "','" + material.GR_Flag + "'";
            result_Material = repository.Insert_Material(material);

            if (result_Material.Status_Code == "500")
            {
                var MailMessage = $"<p>Greetings from Ariston Thermo!</p><p>We received an error while scanned process. </br> Please find below details </br>Serial No: "+ result_Material.Serial_Number + " </br>Status: " + result_Material.Status + " </br> </p><p>Regards,<br>Ariston Thermo India Pvt Ltd.</p>";
                //await emailSender.SendEmailAsync();
                EmailID email = repository.GetEmailId(material.Machine_ID);
                 emailSender.SendEmailAsync(
                  email.Email,
                   "QR Scanner App - Error Received",
                   MailMessage);
            }

            return Content(JsonConvert.SerializeObject(result_Material), "application / json");

        }


        [HttpPost("/api/[controller]/C_Insert_Material_Transaction")]
        public ContentResult C_Insert_Material_Transaction(Material_Single material)
        {
            Result_Material result_Material = new Result_Material();
            //var nu = "'"+ material.Serial_Number + "','" + material.Material_Number + "','" + material.Vendor + "','" + material.Year + "','" + material.Month + "','" + material.Product_Description + "','" + Convert.ToDecimal(material.MRP) + "','" + material.Machine_ID + "','" + Convert.ToDateTime(material.Capturing_Date).ToString("yyyy-MM-dd HH:mm:ss") + "','" + material.Created_By + "','" + material.Cancelled + "','" + material.Transaction_Type + "','" + material.Document_No + "','" + material.Line_Item_Number + "','" + material.Plant + "','" + material.Storage_Location + "','" + material.Ref_Doc_No + "','" + material.Status + "','" + material.QA_Status + "','" + material.Scrap + "','" + material.Cancellation_Indicator + "','" + material.Transaction_Type + "'";
            result_Material = repository.Insert_Material_Transaction(material);
            if (result_Material.Status_Code == "500")
            {
                var MailMessage = $"<p>Greetings from Ariston Thermo!</p><p>We received an error while scanned process. </br> Please find below details </br>Serial No: " + result_Material.Serial_Number + " </br>Status: " + result_Material.Status + " </br> </p><p>Regards,<br>Ariston Thermo India Pvt Ltd.</p>";
                //await emailSender.SendEmailAsync();
                EmailID email = repository.GetEmailId(material.Machine_ID);
                emailSender.SendEmailAsync(
                 email.Email,
                  "QR Scanner App - Error Received",
                  MailMessage);
            }
            return Content(JsonConvert.SerializeObject(result_Material), "application / json");

        }


        [HttpGet("/api/[controller]/C_Get_Delivery_Details/{Delivery_No}")]
        public ContentResult C_Get_Delivery_Details(string Delivery_No)
        {
            List<Delivery_Receipt> delivery_Receipts = new List<Delivery_Receipt>();
            //delivery_Receipts = repository.Get_Delivery_Receipt(Delivery_No);
            delivery_Receipts = repository.Get_Delivery_Receipt(Delivery_No).Where(x =>  x.pstyv != "ZGR0").ToList();
            return Content(JsonConvert.SerializeObject(delivery_Receipts), "application / json");

        }

        [HttpGet("/api/[controller]/C_Get_FOC_Delivery_Details/{Delivery_No}")]
        public ContentResult C_Get_FOC_Delivery_Details(string Delivery_No)
        {
            List<Delivery_Receipt> delivery_Receipts = new List<Delivery_Receipt>();
            delivery_Receipts = repository.Get_Delivery_Receipt(Delivery_No).Where(x => x.pstyv == "ZGR0").ToList();
            return Content(JsonConvert.SerializeObject(delivery_Receipts), "application / json");

        }

        [HttpGet("/api/[controller]/C_Get_Dashboard_Chart/{Type}/{Plant}")]
        public ContentResult C_Get_Dashboard_Chart(string Type, string Plant)
        {
            List<Dashboard_Chart> dashboard_Chart = new List<Dashboard_Chart>();
            dashboard_Chart = repository.Get_Dashboard_Count(Type, Plant);
            return Content(JsonConvert.SerializeObject(dashboard_Chart), "application / json");

        }





        // Notification

        [HttpPost("/api/[controller]/C_Insert_PushSubscription")]
        public ContentResult C_Insert_PushSubscription(PushSubscription push)
        {
            Return_PushSubscription return_Push = new Return_PushSubscription();
            return_Push = repository.Insert_Update_PushSubscription(push);
            return Content(JsonConvert.SerializeObject(return_Push), "application / json");

        }




        // Sync Flag
        [HttpPost("/api/[controller]/UpdateSyncFlag")]
        public ContentResult UpdateSyncFlag(Material material)
        {
            Status staus = new Status();
            for (int i = 0; i < material.material_Masters.Count; i++)
            {
                staus = repository.UpdateSyncFlagMaster(material.material_Masters[i]);
            }
            for (int j = 0; j < material.material_Transaction.Count; j++)
            {
                staus = repository.UpdateSyncFlagTransaction(material.material_Transaction[j]);
            }

            Return_PushSubscription return_Push = new Return_PushSubscription();
        
            return Content(JsonConvert.SerializeObject(staus), "application / json");

        }
    }
}