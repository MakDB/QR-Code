
//var dbPromise = idb.open('posts-store', 1, function (db) {
//  if (!db.objectStoreNames.contains('posts')) {
//      //db.createObjectStore('posts', { keyPath: 'GR_Number'});
//      db.createObjectStore('posts', { keyPath: 'id', autoIncrement: true });
//      db.createIndex('GR_Number', 'GR_Number', { unique: false });
     
//  }
//});

// Created and  Modified By Abhijeet Dhuri
/// GR
var dbPromise = idb.open('db-qr-matrial', 1, function (db) {
    if (!db.objectStoreNames.contains('goods-material-details')) {
        //db.createObjectStore('posts', { keyPath: 'GR_Number'});
        var store = db.createObjectStore('goods-material-details', { keyPath: 'id', autoIncrement: true });
        store.createIndex('Document_No', 'Document_No', { unique: false });
     
        if (!db.objectStoreNames.contains('scan-goods-material')) {
        //db.createObjectStore('posts', { keyPath: 'GR_Number'});
        var store = db.createObjectStore('scan-goods-material', { keyPath: 'Serial_Number'});
        store.createIndex('Material_Number', 'Material_Number', { unique: false });
            store.createIndex('Document_No', 'Document_No', { unique: false });
    }
        if (!db.objectStoreNames.contains('sync-goods-aws')) {
            db.createObjectStore('sync-goods-aws', { keyPath: 'Serial_Number' });
        }

//------------------------- Delivery------------------------------------------
    if (!db.objectStoreNames.contains('delivery-material-details')) {
        //db.createObjectStore('posts', { keyPath: 'GR_Number'});
        var store = db.createObjectStore('delivery-material-details', { keyPath: 'id', autoIncrement: true });
        store.createIndex('Document_No', 'Document_No', { unique: false });
        }

        if (!db.objectStoreNames.contains('scan-delivery-material')) {
            //db.createObjectStore('posts', { keyPath: 'GR_Number'});
            var store = db.createObjectStore('scan-delivery-material', { keyPath: 'Serial_Number' });
            store.createIndex('Material_Number', 'Material_Number', { unique: false });
            store.createIndex('Document_No', 'Document_No', { unique: false });
            //store.createIndex('MaterLine_No', ['Material_Number', 'Line_Item_Number'], { unique: true });
        }

        if (!db.objectStoreNames.contains('sync-delivery-aws')) {
            db.createObjectStore('sync-delivery-aws', { keyPath: 'Serial_Number' });
        }

//------------------------- Sales Retun------------------------------------------
        if (!db.objectStoreNames.contains('sales-return-material-details')) {
            //db.createObjectStore('posts', { keyPath: 'GR_Number'});
            var store = db.createObjectStore('sales-return-material-details', { keyPath: 'id', autoIncrement: true });
            store.createIndex('Document_No', 'Document_No', { unique: false });
        }

        if (!db.objectStoreNames.contains('scan-sales-return-material')) {
            //db.createObjectStore('posts', { keyPath: 'GR_Number'});
            var store = db.createObjectStore('scan-sales-return-material', { keyPath: 'Serial_Number' });
            store.createIndex('Material_Number', 'Material_Number', { unique: false });
            store.createIndex('Document_No', 'Document_No', { unique: false });
            //store.createIndex('MaterLine_No', ['Material_Number', 'Line_Item_Number'], { unique: true });
        }

        if (!db.objectStoreNames.contains('sync-sales-return-aws')) {
            db.createObjectStore('sync-sales-return-aws', { keyPath: 'Serial_Number' });
        }

    }
});



function writeData(st, data) {
  return dbPromise
    .then(function(db) {
      var tx = db.transaction(st, 'readwrite');
      var store = tx.objectStore(st);
      store.put(data);
      return tx.complete;
    });
}


function BulkwriteData(st, data) {
    return dbPromise
        .then(function (db) {
            var tx = db.transaction(st, 'readwrite');
            var store = tx.objectStore(st);
            for (var i = 0; i < data.length; i++) {
                store.put(data[i]);
            }
            return tx.complete;
        });
}

function readAllData(st) {
  return dbPromise
    .then(function(db) {
      var tx = db.transaction(st, 'readonly');
      var store = tx.objectStore(st);
      return store.getAll();
    });
}


function readIndexData(st,index,value) {
    return dbPromise
        .then(function (db) {
            var tx = db.transaction(st, 'readonly');

            var store = tx.objectStore(st);
            var req = store.index(index);
            return req.getAll(value)
          
        });
}

function clearAllData(st) {
    return dbPromise
        .then(function (db) {
            var tx = db.transaction(st, 'readwrite');
            var store = tx.objectStore(st);
            store.clear();
            return tx.complete;
        });
}

function deleteItemFromData(st, id) {
    return dbPromise
        .then(function (db) {
            var tx = db.transaction(st, 'readwrite');
            var store = tx.objectStore(st);
            store.delete(id);
            return tx.complete;
        })
        .then(function () {
            console.log('Item deleted!');
        });
}




// create dynamic elements
const createEle = (tagname, appendTo, fn) => {
    const element = document.createElement(tagname);
    if (appendTo) appendTo.appendChild(element);
    if (fn) fn(element);
};

// create dynamic ListView
const createListView = (Array) => {
    let element = "<ul class='listview image-listview text'>";
    for (i = 0; i < Array.length; i++) {
        element += "<li><a href='#' class='item'><div class='in'> <div>" + Array[i].Material_Number + "</div><span class='badge badge-primary'>" + Array[i].Count + "</span> </div> </a> </li>";
    }
   return element += "</ul>";
};

// create dynamic ListView
const UniqArrayCount = (array) => {
    //let b = [];
    //Array.forEach(el => {
    //    b.push({
    //        Material_Number: el.Material_Number,
    //        Count: el.Material_Number = (el.Material_Number || 0 + 1)
    //    });

    //});
    const result = Array.from(new Set(array.map(s => s.Material_Number)))
        .map(Material_Number => {
            return {
                Material_Number: Material_Number,
                Count: array.filter(s => s.Material_Number === Material_Number).length

            };

        });

    return result;
};
// create dynamic ListView
const UniqArrayCountNew = (array) => {
    //let b = [];
    //Array.forEach(el => {
    //    b.push({
    //        Material_Number: el.Material_Number,
    //        Count: el.Material_Number = (el.Material_Number || 0 + 1)
    //    });

    //});
    const result = Array.from(new Set(array.map(s => s.Material_Number)))
        .map(Material_Number => {
            return {
                Material_Number: Material_Number,
                Line_Item_Number: Line_Item_Number,
                Count: array.filter(s => s.Material_Number === Material_Number && s.Line_Item_Number === Line_Item_Number ).length

            };

        });

    return result;
};
// create dynamic ListView
//const UniqArrayCount = (Array) => {
//    const result = [];
//    const map = new Map();
//    for (const item of Array) {
//        if (!map.has(item.Material_Number)) {
//            map.set(item.Material_Number, true);    // set any value to Map
//            result.push({
//                Material_Number: item.Material_Number,
//                Count: result[item.Material_Number] = (result[item.Material_Number] || 0) + 1
//            });
//        }
//    }
//    console.log(result)
//    return result;
//};


const SortObj = (sortobj) => {
    let obj = {};
    obj = {
        id: sortobj.id,
        GR_Number: sortobj.GR_Number,
        Material_Number: sortobj.Material_Number,
        Quantity: sortobj.Quantity
    };
    return obj;
}

const SortDeliveryObj = (sortobj) => {
    let obj = {};
    obj = {
        id: sortobj.id,
        Delivery_Number: sortobj.Delivery_Number,
        Material_Number: sortobj.Material_Number,
        Quantity: sortobj.Quantity_To_Be_Picked
    };
    return obj;
}





const SortScanObj = (sortscanobj) => {
 
    let obj = {};
    obj = {
        Serial_Number: sortscanobj.Serial_Number,
        Material_Number: sortscanobj.Material_Number,
        GR_Number: sortscanobj.Document_No
    };
    return obj;
}

const SortScanDeliveryObj = (sortscanobj) => {

    let obj = {};
    obj = {
        Serial_Number: sortscanobj.Serial_Number,
        Material_Number: sortscanobj.Material_Number,
        Delivery_Number: sortscanobj.Document_No
    };
    return obj;
}
const ScanMaterialObj = (Scanobj) => {
    var ScanArr = Scanobj.split(',');
    var d = new Date();
    let obj = {};
    let addobj = {};
    if (ScanArr.length == 12) {
        var BreakProductKeyArr = ScanArr[4].split(' ');
        obj = {
            Serial_Number: ScanArr[4],
            Material_Number: ScanArr[0],
            Product_Description: ScanArr[1],
            MRP: ScanArr[3],
            Machine_ID: getCookie("Plant"),
           // Capturing_Date: d.getFullYear() + "-" + Get_Month(d) + "-" + Get_Day(d) + "T" + d.getHours() + ":" + d.getMinutes() + ":" + d.getSeconds(),
            Capturing_Date: ISODateString(d),
            Year: "20" + BreakProductKeyArr[1],
            Month: BreakProductKeyArr[2],
            Document_No: ScanArr[5],
            Line_Item_Number: ScanArr[6],
            Plant: ScanArr[7],
            Storage_Location: ScanArr[8],
            Vendor: ScanArr[9],
            PO_Number: ScanArr[10],
            GR_Flag: ScanArr[11],
            Created_By: getCookie("UserName")


        };

       
    }
    return obj;
}



const ScanDeliveryMaterialObj = (Scanobj) => {
    var ScanArr = Scanobj.split(',');
    var d = new Date();
    let obj = {};
    let addobj = {};
    if (ScanArr.length == 11) {
        var BreakProductKeyArr = ScanArr[4].split(' ');
        obj = {
            Serial_Number: ScanArr[4],
            Material_Number: ScanArr[0],
            Product_Description: ScanArr[1],
            MRP: ScanArr[3],
            Machine_ID: getCookie("Plant"),
            // Capturing_Date: d.getFullYear() + "-" + Get_Month(d) + "-" + Get_Day(d) + "T" + d.getHours() + ":" + d.getMinutes() + ":" + d.getSeconds(),
            Capturing_Date: ISODateString(d),
            Year: "20" + BreakProductKeyArr[1],
            Month: BreakProductKeyArr[2],
            Document_No: ScanArr[5],
            Line_Item_Number: ScanArr[6],
            Plant: ScanArr[7],
            Storage_Location: ScanArr[8],
            Vendor: ScanArr[9],
            Transaction_Type: ScanArr[10],
            Created_By: getCookie("UserName")
        };
    }
    return obj;
}

const ScanSalesReturnMaterialObj = (Scanobj) => {
    var ScanArr = Scanobj.split(',');
    var d = new Date();
    let obj = {};
    let addobj = {};
    if (ScanArr.length == 12) {
        var BreakProductKeyArr = ScanArr[4].split(' ');
        obj = {
            Serial_Number: ScanArr[4],
            Material_Number: ScanArr[0],
            Product_Description: ScanArr[1],
            MRP: ScanArr[3],
            Machine_ID: getCookie("Plant"),
            // Capturing_Date: d.getFullYear() + "-" + Get_Month(d) + "-" + Get_Day(d) + "T" + d.getHours() + ":" + d.getMinutes() + ":" + d.getSeconds(),
            Capturing_Date: ISODateString(d),
            Year: "20" + BreakProductKeyArr[1],
            Month: BreakProductKeyArr[2],
            Document_No: ScanArr[5],
            Line_Item_Number: ScanArr[6],
            Plant: ScanArr[7],
            Storage_Location: ScanArr[8],
            Vendor: ScanArr[9],
            Transaction_Type: ScanArr[11],
            Created_By: getCookie("UserName")
        };
    }
    return obj;
}

function ISODateString(d) {
    function pad(n) { return n < 10 ? '0' + n : n }
    return d.getFullYear() + '-'
        + pad(d.getMonth() + 1) + '-'
        + pad(d.getDate()) + 'T'
        + pad(d.getHours()) + ':'
        + pad(d.getMinutes()) + ':'
        + pad(d.getSeconds()) + 'Z'
}

function getCookie(cname) {
    var name = cname + "=";
    var ca = document.cookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) == ' ') {
            c = c.substring(1);
        }
        if (c.indexOf(name) == 0) {
          //  return c.substring(name.length, c.length);
            return  atob(decodeURIComponent(c.substring(name.length, c.length)));
        }
    }
    return "";
}


function GetDashboardChart(Type,Plant) {
    var dataArray = [];
    var URL = "/api/P20551/C_Get_Dashboard_Chart/" + Type+"/" + Plant;

    fetch(URL)
        .then(function (res) {
            return res.json();
        })
        .then(function (data) {
            console.log(data);
           // return data;
            
            for (var key in data) {
                dataArray.push(data[key]);
            }
        });
    return dataArray
}



function urlBase64ToUint8Array(base64String) {
    var padding = '='.repeat((4 - base64String.length % 4) % 4);
    var base64 = (base64String + padding)
        .replace(/\-/g, '+')
        .replace(/_/g, '/');

    var rawData = window.atob(base64);
    var outputArray = new Uint8Array(rawData.length);

    for (var i = 0; i < rawData.length; ++i) {
        outputArray[i] = rawData.charCodeAt(i);
    }
    return outputArray;
}

function base64Encode(arrayBuffer) {
    return btoa(String.fromCharCode.apply(null, new Uint8Array(arrayBuffer)));
}