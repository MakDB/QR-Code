using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using QR_Material_Scanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebPush;


namespace QR_Material_Scanner.Helpers
{
    public class SendPushNotification
    {

        private readonly IRepository _repository;
        private readonly WebPushClient _client;
        private readonly VapidDetails _vapidDetails;

        public SendPushNotification(IRepository repository, IConfiguration _configuration)
        {
            _repository = repository;
            _client = new WebPushClient();

            var vapidSubject = _configuration.GetSection("VapidKeys")["Subject"];
            var vapidPublicKey = _configuration.GetSection("VapidKeys")["PublicKey"];
            var vapidPrivateKey = _configuration.GetSection("VapidKeys")["PrivateKey"];
            _vapidDetails = new VapidDetails(vapidSubject, vapidPublicKey, vapidPrivateKey);
        }

        public void SendNotificationOnPlant(string Plant, Notification noti)
        {
            var GetSubscriptionPlant = _repository.GetPushSubscription().Where(x => x.Plant == Plant);
            foreach (var subscription in GetSubscriptionPlant)
                try
                {
                    var _pushSubscription = new WebPush.PushSubscription(subscription.Endpoint, subscription.P256Dh, subscription.Auth);
                    _client.SendNotification(_pushSubscription, JsonConvert.SerializeObject(noti), _vapidDetails);
                }
                catch (WebPushException exception)
                {
                    var statusCode = exception.StatusCode;
                }
        }
    }
}
