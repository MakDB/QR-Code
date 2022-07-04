//var enableNotificationsButtons = document.querySelector('.enable-notifications');


function displayConfirmNotification() {
    if ('serviceWorker' in navigator) {
        var options = {
            body: 'You successfully subscribed to our Notification service!',
            icon: '/images/icons/icon-96x96-notification.png',
            image: '/images/photo/superbrand.jpg',
            dir: 'ltr',
            lang: 'en-US', // BCP 47,
            vibrate: [200, 100, 200],
            badge: '/images/icons/icon-96x96-notification.png',
            tag: 'confirm-notification',
            renotify: true,
           
            actions: [
                { action: 'confirm', title: 'Okay'/*, icon: '/images/icons/icon-96x96-notification.png'*/ },
                { action: 'cancel', title: 'Cancel'/*, icon: '/images/icons/icon-96x96-notification.png'*/ }
            ]
        };

        navigator.serviceWorker.ready
            .then(function (swreg) {
                swreg.showNotification('Successfully subscribed!', options);
            });
    }
}

function configurePushSub() {
    if (!('serviceWorker' in navigator)) {
        return;
    }

    var reg;
    navigator.serviceWorker.ready
        .then(function (swreg) {
            reg = swreg;
            return swreg.pushManager.getSubscription();
        })
        .then(function (sub) {
            if (sub === null) {
                // Create a new subscription
                var vapidPublicKey = 'BI6TBKXgh8xWSAxhiIKKBiJkklVl8BN18xOwjZ1VQELqcxsQjSdfXkvR4WcEH8Bwt5qGzaEyuGPtMheL4NLg2jU';
                var convertedVapidPublicKey = urlBase64ToUint8Array(vapidPublicKey);
                return reg.pushManager.subscribe({
                    userVisibleOnly: true,
                    applicationServerKey: convertedVapidPublicKey
                });
            } else {
                // We have a subscription
            }
        })
        .then(function (newSub) {
            var PushNotificationParam = {
                UserName: getCookie("UserName"),
                Endpoint: newSub.endpoint,
                ExpirationTime: newSub.expirationTime,
                P256Dh: base64Encode(newSub.getKey('p256dh')),
                Auth: base64Encode(newSub.getKey('auth')),
                Plant: getCookie("Plant")
            };

            //var URL = "/api/P20551/C_Get_Delivery_Details/" + txtDeliveryChallanNoFetch.value.trim();
            //return fetch('https://pwagram-fdb21.firebaseio.com/subscriptions.json', {
            return fetch('/api/P20551/C_Insert_PushSubscription', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                    'Accept': 'application/json'
                },
                body: JSON.stringify(PushNotificationParam)
            })
        })
        .then(function (res) {
            if (res.ok) {
                displayConfirmNotification();
            }
        })
        .catch(function (err) {
            console.log(err);
        });
}

function askForNotificationPermission() {
    Notification.requestPermission(function (result) {
        console.log('User Choice', result);
        if (result !== 'granted') {
            console.log('No notification permission granted!');
        } else {
            configurePushSub();
            // displayConfirmNotification();
        }
    });
}

if ('Notification' in window && 'serviceWorker' in navigator) {
    //for (var i = 0; i < enableNotificationsButtons.length; i++) {
    //    enableNotificationsButtons[i].style.display = 'inline-block';
    //    enableNotificationsButtons[i].addEventListener('click', askForNotificationPermission);
    //}
    //enableNotificationsButtons.style.display = 'inline-block';
    //enableNotificationsButtons.addEventListener('click', askForNotificationPermission);
    // Notificationswitch
    $('#enable-notifications').change(function () {
        //$("#enable-notifications").trigger('#enable-notifications');
        var checkNotificationStatusCheck = localStorage.getItem("NotificationActive");

        if (checkNotificationStatusCheck === 1 || checkNotificationStatusCheck === "1") {
            //localStorage.setItem("NotificationActive", "0");
            //$("#enable-notifications").attr('checked', false);
            $("#enable-notifications").attr('checked', true);
            $('#enable-notifications').attr("disabled", true);
        }
        else {
            $("#enable-notifications").attr('checked', true);
            localStorage.setItem("NotificationActive", "1");
            $('#enable-notifications').attr("disabled", true);
           
            askForNotificationPermission();
        }
    });
    //var dmswitch = $("#enable-notifications");
    //dmswitch.on('change', function () {
    //    dmswitch.prop('checked', this.checked);

    //});
}






//------------------------------------------------------------------------------------------------------------------

var checkNotificationStatus = localStorage.getItem("NotificationActive");
// if dark mode on
if (checkNotificationStatus === 1 || checkNotificationStatus === "1") {
    $("#enable-notifications").attr('checked', true);
 
    $('#enable-notifications').attr("disabled", true);
}
else {
    $("#enable-notifications").attr('checked', false);
}

