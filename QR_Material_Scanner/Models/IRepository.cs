using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QR_Material_Scanner.Models
{
   public interface IRepository
    {
        Result_Goods_Receipt Add_Goods_Receipt(List<Goods_Receipt> goods_Receipt);

        Result_Delivery_Receipt Add_Delivery_Receipt(List<Delivery_Receipt> delivery_Receipt);

        List<Goods_Receipt> Get_Goods_Receipt(string GR_Number, string Type);

        List<Delivery_Receipt> Get_Delivery_Receipt(string Delivery_No);

        List<Material_Master> Get_Material_Master(DateTime SyncDateTime);

        List<Material_Transaction> Get_Material_Transaction(DateTime SyncDateTime, string Type);


        Result_Material Insert_Material(Material_Single material);

        Result_Material Insert_Material_Transaction(Material_Single material);

        List<Dashboard_Chart> Get_Dashboard_Count(string Type, string Plant);

        Return_PushSubscription Insert_Update_PushSubscription(PushSubscription push);

        List<PushSubscription> GetPushSubscription();


        Retailer_Status InsertStoreLocator(Middleware_Retailer retailer);

        Retailer_Status UpdateStoreLocator(Middleware_Retailer retailer);

        Middleware_Retailer GetRetailer(int Id);

        EmailID GetEmailId(string machine_ID);

        Status UpdateSyncFlagMaster(Material_Master master);

        Status UpdateSyncFlagTransaction(Material_Transaction material_transaction);


    }
}
