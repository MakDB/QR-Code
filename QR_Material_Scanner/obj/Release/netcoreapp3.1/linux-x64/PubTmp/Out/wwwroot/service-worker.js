importScripts('https://storage.googleapis.com/workbox-cdn/releases/5.1.2/workbox-sw.js');
importScripts('/js/idb.js');
importScripts('/js/utility.js');

//workbox.loadModule('workbox-strategies');


const { registerRoute } = workbox.routing;
const { StaleWhileRevalidate, CacheFirst, NetworkFirst } = workbox.strategies;
const { CacheableResponse } = workbox.cacheableResponse;

const { ExpirationPlugin } = workbox.expiration;

if (workbox) {
    console.log(`Yay! Workbox is loaded 🎉`);
} else {
    console.log(`Boo! Workbox didn't load 😬`);
}
const version = "V.1.2.0";



//var checkVersionApp = localStorage.getItem("AppVersion");

//if (checkVersionApp != version) {
//    localStorage.setItem("AppVersion", version);
//}

workbox.precaching.precacheAndRoute([
//workbox.precaching.precacheAndRoute(self.__precacheManifest || [
    { url: '/Goods_Receipts', revision: version },
    { url: '/delivery', revision: version },
    { url: '/home', revision: version },
    //{ url: '/Logout', revision: version },
    { url: '/Sales_Return', revision: version },
    { url: '/offline', revision: version },
    { url: '/svg/qr-code-outline.svg', revision: version }




]);




//registerRoute(
//    // Cache style resources, i.e. CSS files.
//    ({ request }) => request.destination === /.*(?:googleapis|gstatic)\.com.*$/,
//    // Use cache but update in the background.
//    new StaleWhileRevalidate({
//        // Use a custom cache name.
//        cacheName: 'google-fonts',
//    })
//);


registerRoute(
    // Cache style resources, i.e. CSS files.
    ({ request }) => request.destination === 'style',
    // Use cache but update in the background.
    new StaleWhileRevalidate({
        // Use a custom cache name.
        cacheName: 'css-cache',
    })
);

registerRoute(
    // Cache image files.
    ({ request }) => request.destination === 'image',
    // Use the cache if it's available.
    new StaleWhileRevalidate ({
        // Use a custom cache name.
        cacheName: 'image-cache',
        //plugins: [
        //    new ExpirationPlugin({
        //        // Cache only 20 image
        //        // Cache for a maximum of a week.
        //        maxAgeSeconds: 7 * 24 * 60 * 60,
        //    })
        //],
    })
);

registerRoute(
    // Cache image files.
    ({ request}) => request.destination === 'script',
    // Use the cache if it's available.
    new StaleWhileRevalidate({
        // Use a custom cache name.
        cacheName: 'script-cache',
        plugins: [
            new ExpirationPlugin({
                // Cache for a maximum of a week.
                maxAgeSeconds: 7 * 24 * 60 * 60,
            })
        ],
    })
);


registerRoute(function (routeData) {
    return (routeData.event.request.headers.get('accept').includes('text/html'));
}, function (args) {
    return caches.match(args.event.request)
        .then(function (response) {
            if (response) {
                return response;
            } else {
                return fetch(args.event.request)
                    .then(function (res) {
                        return caches.open('dynamic')
                            .then(function (cache) {

                                //console.log(args.event.request.url.indexOf('/login/'));
                                if ((args.url.pathname != '/login') && (args.url.pathname != '/Login') && (args.url.pathname != '/Logout') && (args.url.pathname != '/ForgotPassword') && (args.url.pathname != '/ChangePassword') && (args.url.pathname != '/ResetPassword') && (args.url.pathname != '/StoreLocator'))
                                {
                                    cache.put(args.event.request.url, res.clone());
                                }
                                return res;
                            })
                    })
                    .catch(function (err) {
                        return caches.match('/offline')
                            .then(function (res) {
                                return res;
                            });
                    })
            }
        })
});

//workbox.precache([]);


self.addEventListener('sync', function (event) {
    console.log('[Service Worker] Background syncing', event);
    if (event.tag === 'sync-goods-aws') {
        console.log('[Service Worker] Syncing new Posts - Goods');
        event.waitUntil(
            readAllData('sync-goods-aws')
                .then(function (data) {
                    for (var dt of data) {
                        fetch('/api/P20551/C_Insert_Goods_Receipt', {
                            method: 'POST',
                            headers: {
                                'Content-Type': 'application/json',
                                'Accept': 'application/json'
                            },
                            body: JSON.stringify(dt)
                        })
                            .then(function (datas) {
                                if (datas.ok) {
                                    return datas.json();
                                }
                            })
                            .then(function (res) { 
                                console.log('Sent data', res);
                                if (res.Status_Code === "200") {
                                    deleteItemFromData('sync-goods-aws', res.Serial_Number); // Isn't working correctly!
                                    deleteItemFromData('scan-goods-material', res.Serial_Number); //
                                
                                }
                            })
                            .catch(function (err) {
                                console.log('Error while sending data', err);
                            });
                    }

                })
        );
    }



    if (event.tag === 'sync-delivery-aws') {
        console.log('[Service Worker] Syncing new Posts - Delivery');
        event.waitUntil(
            readAllData('sync-delivery-aws')
                .then(function (data) {
                    for (var dt of data) {
                        fetch('/api/P20551/C_Insert_Material_Transaction', {
                            method: 'POST',
                            headers: {
                                'Content-Type': 'application/json',
                                'Accept': 'application/json'
                            },
                            body: JSON.stringify(dt)
                        })
                            .then(function (datas) {
                                if (datas.ok) {
                                    return datas.json();
                                }
                            })
                            .then(function (res) {
                                console.log('Sent data', res);
                                if (res.Status_Code === "200") {
                                    deleteItemFromData('sync-delivery-aws', res.Serial_Number); // Isn't working correctly!
                                    deleteItemFromData('scan-delivery-material', res.Serial_Number); //

                                }
                            })
                            .catch(function (err) {
                                console.log('Error while sending data', err);
                            });
                    }

                })
        );
    }

    if (event.tag === 'sync-sales-return-aws') {
        console.log('[Service Worker] Syncing new Posts - Sales Return');
        event.waitUntil(
            readAllData('sync-sales-return-aws')
                .then(function (data) {
                    for (var dt of data) {
                        fetch('/api/P20551/C_Insert_Material_Transaction', {
                            method: 'POST',
                            headers: {
                                'Content-Type': 'application/json',
                                'Accept': 'application/json'
                            },
                            body: JSON.stringify(dt)
                        })
                            .then(function (datas) {
                                if (datas.ok) {
                                    return datas.json();
                                }
                            })
                            .then(function (res) {
                                console.log('Sent data', res);
                                if (res.Status_Code === "200") {
                                    deleteItemFromData('sync-sales-return-aws', res.Serial_Number); // Isn't working correctly!
                                    deleteItemFromData('scan-sales-return-material', res.Serial_Number); //

                                }
                            })
                            .catch(function (err) {
                                console.log('Error while sending data', err);
                            });
                    }

                })
        );
    }
});



self.addEventListener('notificationclick', function (event) {
    var notification = event.notification;
    var action = event.action;

    console.log(notification);

    if (action === 'confirm') {
        console.log('Confirm was chosen');
        notification.close();
    } else {
        console.log(action);
        event.waitUntil(
            clients.matchAll()
                .then(function (clis) {
                    var client = clis.find(function (c) {
                        return c.visibilityState === 'visible';
                    });

                    if (client !== undefined) {
                        client.navigate(notification.data.url);
                        client.focus();
                    } else {
                        clients.openWindow(notification.data.url);
                    }
                    notification.close();
                })
        );
    }
});

self.addEventListener('notificationclose', function (event) {
    console.log('Notification was closed', event);
});

self.addEventListener('push', function (event) {
    console.log('Push Notification received', event);

    var data = { title: 'New!', content: 'Something new happened!', openUrl: '/' };

    if (event.data) {
        data = JSON.parse(event.data.text());
    }

    var options = {
        body: data.content,
        icon: '/images/icons/icon-96x96-notification.png',
        badge: '/images/icons/icon-96x96-notification.png',
        vibrate: [200, 100, 200],
        data: {
            url: data.openUrl
        }
    };

    event.waitUntil(
        self.registration.showNotification(data.title, options)
    );
});

