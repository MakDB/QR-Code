using EFCore.BulkExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QR_Material_Scanner.Models
{
    public class SQLRepository : IRepository
    {
        private readonly AppDbContext context;
        public SQLRepository(AppDbContext context)
        {
            this.context = context;
        }

       

        public Result_Delivery_Receipt Add_Delivery_Receipt(List<Delivery_Receipt> delivery_Receipt)
        {
            Result_Delivery_Receipt result_Delivery_Receipt = new Result_Delivery_Receipt();
            try
            {

                //context.goods_receipt.Add(goods_Receipt);
                //context.SaveChanges();

                context.BulkInsert(delivery_Receipt);
                result_Delivery_Receipt.Status_Code = "200";
                result_Delivery_Receipt.Status = "Successfully Inserted";

            }
            catch (Exception ex)
            {
                result_Delivery_Receipt.Status_Code = "400";
                result_Delivery_Receipt.Status = "Error! UnSuccessfully " + ex.Message;
            }
            return result_Delivery_Receipt;

        }

        public Result_Goods_Receipt Add_Goods_Receipt(List<Goods_Receipt> goods_Receipt)
        {
            Result_Goods_Receipt result_Goods_Receipt = new Result_Goods_Receipt();
            try
            {

                //context.goods_receipt.Add(goods_Receipt);
                //context.SaveChanges();
                foreach (var goods in goods_Receipt)
                {
                    context.tran_GR_Information.Add(goods);
                }
                context.SaveChanges();
               

               // context.BulkInsert(goods_Receipt);
                
                result_Goods_Receipt.Status_Code = "200";
                result_Goods_Receipt.Status = "Successfully Inserted";

            }
            catch (Exception ex)
            {
                result_Goods_Receipt.Status_Code = "400";
                result_Goods_Receipt.Status = "Error! UnSuccessfully " + ex.Message;
            }
            return result_Goods_Receipt;




        }

        public List<Goods_Receipt> Get_Goods_Receipt(string GR_Number, string Type)
        {
            return context.tran_GR_Information
               .FromSqlRaw<Goods_Receipt>("sp_GetGRDetailsByGrNo {0},{1}", GR_Number, Type)
               .ToList();

        }


        public List<Delivery_Receipt> Get_Delivery_Receipt(string Delivery_No)
        {
            return context.tran_Delivery_Information
               .FromSqlRaw<Delivery_Receipt>("sp_GetDeliveryDetailsByDeliveryNo {0}", Delivery_No)
               .ToList();

        }

        public List<Material_Master> Get_Material_Master(DateTime SyncDateTime)
        {
            return context.material_master
                .FromSqlRaw<Material_Master>("sp_GetMaterialMasterByDate {0}", SyncDateTime)
                .ToList();
        }

        public List<Material_Transaction> Get_Material_Transaction(DateTime SyncDateTime, string Type)
        {
            return context.material_transaction
               .FromSqlRaw<Material_Transaction>("sp_GetMaterialTransactionByDate {0},{1}", SyncDateTime, Type)
               .ToList();
        }

        public Result_Material Insert_Material(Material_Single material)
        {
            return context.result_Material
               .FromSqlRaw<Result_Material>("sp_Insert_Material {0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21}",
                material.Serial_Number.Trim(), material.Material_Number, material.Vendor, material.Year, material.Month, material.Product_Description, Convert.ToDecimal(material.MRP), material.Machine_ID, material.Capturing_Date, material.Created_By, material.Cancelled, material.Transaction_Type, material.Document_No, material.Line_Item_Number, material.Plant, material.Storage_Location, material.Ref_Doc_No, material.Status, material.QA_Status, material.Scrap, material.Cancellation_Indicator, material.GR_Flag
               )
               .ToList().FirstOrDefault();
        }

        public Result_Material Insert_Material_Transaction(Material_Single material)
        {
            return context.result_Material
               .FromSqlRaw<Result_Material>("sp_Insert_Material_Transaction " +
               "{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20}",
                material.Serial_Number.Trim(), material.Material_Number, material.Vendor, material.Year, material.Month, material.Product_Description, Convert.ToDecimal(material.MRP), material.Machine_ID, material.Capturing_Date, material.Created_By, material.Cancelled, material.Transaction_Type, material.Document_No, material.Line_Item_Number, material.Plant, material.Storage_Location, material.Ref_Doc_No, material.Status, material.QA_Status, material.Scrap, material.Cancellation_Indicator
               )
               .ToList().FirstOrDefault();
        }



        public List<Dashboard_Chart> Get_Dashboard_Count(string Type,string Plant)
        {
            return context.dashboard_chart
               .FromSqlRaw<Dashboard_Chart>("sp_GetDashboardDetailsByType {0},{1}", Type,Plant)
               .ToList();

        }

        public Return_PushSubscription Insert_Update_PushSubscription(PushSubscription push)
        {
            return context.return_push
               .FromSqlRaw<Return_PushSubscription>("sp_Insert_PushSubscription {0},{1},{2},{3},{4},{5}", push.UserName, push.Endpoint,push.ExpirationTime, push.P256Dh, push.Auth, push.Plant)
               .ToList().FirstOrDefault(); 

        }

        public List<PushSubscription> GetPushSubscription()
        {
            return context.push
               .FromSqlRaw<PushSubscription>("SELECT * FROM mst_PushSubscription WHERE ACTIVE = 'Y'")
               .ToList();

        }

        public Retailer_Status InsertStoreLocator(Middleware_Retailer retailer)
        {
            return context.retailer_Status
               .FromSqlRaw<Retailer_Status>("sp_Insert_Store_Locator {0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11}", retailer.Id, retailer.Business_Name, retailer.Address, retailer.City,retailer.State, retailer.Pincode, retailer.Mobile, retailer.Latitude, retailer.Longitude,retailer.Email,retailer.Id,retailer.GST)
               .ToList().FirstOrDefault();

        }
        public Retailer_Status UpdateStoreLocator(Middleware_Retailer retailer)
        {
            return context.retailer_Status
               .FromSqlRaw<Retailer_Status>("sp_Update_Store_Locator {0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11}", retailer.Id, retailer.Business_Name, retailer.Address, retailer.City, retailer.State, retailer.Pincode, retailer.Mobile, retailer.Latitude, retailer.Longitude, retailer.Email, retailer.Id, retailer.GST)
               .ToList().FirstOrDefault();

        }


        public EmailID GetEmailId(string Plant)
        {
            return context.GetEmailId
               .FromSqlRaw<EmailID>("select Email from AspNetUsers Where Plant = '" + Plant + "'")
               .ToList().FirstOrDefault();

        }
        public Middleware_Retailer GetRetailer(int Id)
        {

            return context.GetRetailer
               .FromSqlRaw<Middleware_Retailer>("select * from mst_Store_Locator Where Id =   '" + Id + "'")
               .ToList().FirstOrDefault();

        }

        public Status UpdateSyncFlagMaster(Material_Master master)
        {
            return context.UpdateFlagMaster
               .FromSqlRaw<Status>("sp_Update_Master_Sync_Flag {0},{1}", master.GERNR, master.Flag)
               .ToList().FirstOrDefault();
        }

        public Status UpdateSyncFlagTransaction(Material_Transaction material_transaction)
        {
            return context.UpdateFlagTransaction
              .FromSqlRaw<Status>("sp_Update_Transaction_Sync_Flag {0},{1},{2},{3},{4},{5}", material_transaction.GERNR, material_transaction.ESART, material_transaction.EBELN, material_transaction.DZETILE, material_transaction.WERKS, material_transaction.Flag)
              .ToList().FirstOrDefault();
        }
    }
}
