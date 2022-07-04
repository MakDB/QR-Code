var SubmitButtonDelivery = document.querySelector('#btnDeliverySubmit');
var SubmitButton = document.querySelector('#btnSubmit');
var txtDeliveryChallanNo = document.querySelector('#txtDeliveryChallanNo');
var txtDeliveryChallanNoFetch = document.querySelector('#txtDeliveryChallanNoFetch');
var txtScan = document.querySelector('#txtQrCode');
var form = document.querySelector('form');
var SubmitButtonScan = document.querySelector('#btnScanMaterial');
//var modalFade = document.querySelector('modal-backdrop fade show');
var elem = document.querySelector(".modal-backdrop");
//var modal = document.querySelector('#actionSheetForm');
var OpenModelButton = document.querySelector('#open-model-button');

var spanTotalQty = document.querySelector('#spanTotalQty');
var spanTotalScanQty = document.querySelector('#spanTotalScanQty');

var ScannedMaterial = document.querySelector('#hylScanMaterial');
var PanelRight = document.querySelector('#PanelRight');

const queryString = window.location.search;
console.log(queryString);
const urlParams = new URLSearchParams(queryString);


if (urlParams.has('document_no')) {

    const document_no = urlParams.get('document_no');
    console.log(document_no);
    openModal('click');
    txtDeliveryChallanNoFetch.value = document_no;

    openModalFetchDelivery();
}



spanTotalQty.textContent = 0;
spanTotalScanQty.textContent = 0;
var dataArray = [];
var DeliveryFetchRecord = false;
SubmitButtonScan.style.display = "none";
var Remain_Quantity = 0;

var objDelivery = {};
function openModalFetchDelivery() {
    
    dataArray = [];
    var URL = "/api/P20551/C_Get_Delivery_Details/" + txtDeliveryChallanNoFetch.value.trim();
    if (txtDeliveryChallanNoFetch.value.trim() === '') return;

    fetch(URL)
        .then(function (res) {
            return res.json();
        })
        .then(function (data) {
            console.log('From web', data);
            clearAllData('delivery-material-details');
            if (data.length <= 0) {
                $('#actionSheetForm').modal('hide');
                $("#DialogAlert").modal();
                $("#DialogAlert").find('.modal-title').html("Alert!");
                $("#DialogAlert").find('.modal-body').html("Delivery Number:<strong>" + txtDeliveryChallanNoFetch.value.trim() + "</strong> is Not found");
                SubmitButtonScan.style.display = 'none';
                return;
            }

            Remain_Quantity = 0;
            for (var key in data) {
                //console.log('Array Single', key);
                //writeData('delivery-material-details', data[key]);
                //DeliveryFetchRecord = true;
                Remain_Quantity += data[key].Quantity_To_Be_Picked;
            }
            if (Remain_Quantity <= 0) {
                    GRAlreadyDone = true;
                    SubmitButtonScan.style.display = 'none';
                    $('#actionSheetForm').modal('hide');
                    $("#DialogAlert").modal();
                    $("#DialogAlert").find('.modal-title').html("Error!");
                    $("#DialogAlert").find('.modal-body').html("Delivery number:<strong>" + txtDeliveryChallanNoFetch.value.trim() + "</strong> scan data is already submitted");
                    return;
                }
                else {
                    writeData('delivery-material-details', data[key]);
                    DeliveryFetchRecord = true;
                    SubmitButtonScan.style.display = 'block';
                }



            
            readDeliveryAllData();
        });
    DeliveryFetchRecord = false;
 


}
SubmitButtonDelivery.addEventListener('click', openModalFetchDelivery);

function openModal(event) {

    $("#actionSheetForm").modal();

}




OpenModelButton.addEventListener('click', openModal);


function readDeliveryAllData() {
    readAllData('delivery-material-details')
        .then(function (data) {
            console.log(data);
            DeliveryFetchTable(data);
            //return data;
        });
}
function readDeliveryScanAllData() {
    readIndexData('scan-delivery-material', 'Document_No', txtDeliveryChallanNo.value)
        .then(function (data) {
            console.log(data);
            //Scantable(data);
            console.log(data.sort((a, b) => b.Capturing_Date > a.Capturing_Date) ? 1 : (b.Capturing_Date < a.Capturing_Date) ? -1 : 0);
            spanTotalScanQty.textContent = parseInt(data.length);  //Do the math!

            DeliveryScantable(data.sort((a, b) => b.Capturing_Date > a.Capturing_Date ? 1 : (b.Capturing_Date < a.Capturing_Date) ? -1 : 0));
            //return data.sort((a, b) => b.Capturing_Date > a.Capturing_Date ? 1 : (b.Capturing_Date < a.Capturing_Date) ? -1 : 0);
        });
}

// create dynamic table
function DeliveryFetchTable(data) {

    //var data = readGRAllData();
    const tbody = document.getElementById("tbody");
    const notfound = document.getElementById("notfound");
    let TotalQty = 0;
    notfound.textContent = "";
    // remove all childs from the dom first
    while (tbody.hasChildNodes()) {
        tbody.removeChild(tbody.firstChild);
    }
    if (data.length > 0) {
        for (let key of data) {
            objDelivery = SortDeliveryObj(key);
            txtDeliveryChallanNo.value = objDelivery.Delivery_Number;
            TotalQty += parseInt(objDelivery.Quantity); 

            spanTotalQty.textContent = TotalQty; 
            createEle("tr", tbody, tr => {
                for (const value in objDelivery) {
                    createEle("td", tr, td => {
                        //td.textContent = key.id === key[value] ? `$ ${key[value]}` : key[value];
                        td.textContent = objDelivery.id === objDelivery[value] ? objDelivery[value] : objDelivery[value];
                    });
                }

            });
        }
        SubmitButtonScan.style.display = "block";
    }
    else {
        notfound.textContent = "No record found in the database...!";
        SubmitButtonScan.style.display = "none";
    }

}


// create scan dynamic table
function DeliveryScantable(data) {

    //var data = readGRScanAllData();
    const tbodyScan = document.getElementById("tbodyScan");
    //const notfoundScan = document.getElementById("notfoundScan");
    //notfoundScan.textContent = "";
    // remove all childs from the dom first
    while (tbodyScan.hasChildNodes()) {
        tbodyScan.removeChild(tbodyScan.firstChild);
    }
    if (data) {
        for (let key of data) {
            var Scanobj = SortScanDeliveryObj(key);

            createEle("tr", tbodyScan, tr => {
                for (const value in Scanobj) {
                    createEle("td", tr, td => {
                        //td.textContent = key.id === key[value] ? `$ ${key[value]}` : key[value];
                        td.textContent = Scanobj.Serial_Number === Scanobj[value] ? Scanobj[value] : Scanobj[value];
                    });
                }

                createEle("td", tr, td => {
                    createEle("i", td, i => {
                       
                        //i.className += "fas fa-trash-alt btndelete";
                        i.setAttribute('data-Serial_Number', Scanobj.Serial_Number);
                        i.innerHTML = " <span class='iconedbox-sm text-danger'><ion-icon name='trash-outline'></ion-icon></span>";
                        // store number of edit buttons
                        i.onclick = deletebtn;

                    });
                })

            });
        }
    }
    else {
        notfound.textContent = "No record found in the database...!";
    }

}


const deletebtn = event => {
    let id = event.currentTarget.getAttribute('data-Serial_Number');


    $("#DialogBasic").data('id', id).modal('show');
    event.preventDefault();
    //deleteItemFromData('scan-material',id);
    //readGRScanAllData();
}

$('#btnDeleteYesNo').click(function () {
    let id = $('#DialogBasic').data('id');
    deleteItemFromData('scan-delivery-material', id);

    readDeliveryScanAllData();
    $('#DialogBasic').modal('hide');
});


$('#btnOkConfirmation').click(function () {
   var data = $('#DialogBasicConfirmation').data('data');
    ServiceRegister(data);
    $('#DialogBasicConfirmation').modal('hide');
});






function openScanMaterial(event) {

    if (txtDeliveryChallanNo.value.trim() !== "") {
    
        //modal.style.display = 'none';
        var elem = document.querySelector(".modal-backdrop");
        elem.remove();
        txtScan.focus();
    }
    event.preventDefault();
}
SubmitButtonScan.addEventListener('click', openScanMaterial, false);





document.addEventListener('keypress', function (e) {
    if (e.keyCode === 13) {
        //txtScan.onkeydown = txtScan.onkeypress = function () { return false };
        txtScan.focus();
        //setTimeout(function () { history.go(-1); }, 3000);



    }
});

document.addEventListener('textInput', function (e) {

    if (dataArray.length === 0) {
        readAllData('delivery-material-details')
            .then(function (data) {
                //var dataArray = [];
                for (var key in data) {
                    dataArray.push(data[key]);
                }
            }).then(function (d) {
                if (e.data.length >= 10) {
                    console.log('IR scan textInput', e.data);
                    // var ScanObj = ScanMaterialObj(e.data + "," + txtfetchGRNO.value.trim());
                    if (txtDeliveryChallanNo.value.trim() !== "") {
                        ValidationDeliveryScanCode(e.data);
                        //writeData('scan-material', ScanObj);
                    }
                    else {
                        $("body").append(
                            "<div id='delivery-toast' class='toast-box toast-top bg-warning tap-to-close'>"
                            +
                            "<div class='in'><ion-icon name='alert' class='text-light md hydrated' role='img' aria-label='alert'></ion-icon><div class='text'>"
                            +
                            "Delivery Number can not be blank!"
                            +
                            "</div></div></div>"
                        );
                        toastbox('delivery-toast', 3000);
                    }
                    //readDeliveryScanAllData();

                }

            });
    }
    else {
        if (e.data.length >= 10) {
            console.log('IR scan textInput', e.data);
            // var ScanObj = ScanMaterialObj(e.data + "," + txtfetchGRNO.value.trim());
            if (txtDeliveryChallanNo.value.trim() !== "") {
                ValidationDeliveryScanCode(e.data);
                //writeData('scan-material', ScanObj);
            }
            else {
                $("body").append(
                    "<div id='delivery-toast' class='toast-box toast-top bg-warning tap-to-close'>"
                    +
                    "<div class='in'><ion-icon name='alert' class='text-light md hydrated' role='img' aria-label='alert'></ion-icon><div class='text'>"
                    +
                    "Delivery Number can not be blank!"
                    +
                    "</div></div></div>"
                );
                toastbox('delivery-toast', 3000);
            }
            //readDeliveryScanAllData();

        }

    }
    //txtScan.onkeydown = txtScan.onkeypress = function () { return false };
});



function ValidationDeliveryScanCode(input) {

    if (dataArray.length !== 0) {
        var ScanArr = input.split(',');
        let MaterialCode = ScanArr[0];
        var deliveryfind = dataArray.filter(e => e.Material_Number.indexOf(MaterialCode) >= 0);

        let ScanData = [];
        var deliveryScanCount = 0;
        readIndexData('scan-delivery-material', 'Document_No', txtDeliveryChallanNo.value)
            .then(function (data) {
                console.log(data);
                //Scantable(data);

                ScanData = UniqArrayCount(data);
            })
            .then(function (data) {
                if (deliveryfind.length > 0) {
                    for (var i = 0; i < deliveryfind.length; i++) {
                        var deliveryScanfind = ScanData.filter(e => e.Material_Number.indexOf(deliveryfind[i].Material_Number) >= 0);
                        if ("undefined" != typeof deliveryScanfind[0]) {
                            //array value is not there...
                            deliveryScanCount = deliveryScanfind[0].Count
                        }
                        if (deliveryScanCount < deliveryfind[i].Quantity_To_Be_Picked) {

                            var DeliveryScanObj = ScanDeliveryMaterialObj(input + "," + deliveryfind[i].Delivery_Number + "," + deliveryfind[i].Line_Item_Number + "," + deliveryfind[i].Plant + "," + deliveryfind[i].Storage_Location + "," + deliveryfind[i].Customer_Number + "," + "DL");
                            writeData('scan-delivery-material', DeliveryScanObj);
                        }
                        else {
                            $("body").append(
                                "<div id='material-scan-qty-toast' class='toast-box toast-top bg-secondary  tap-to-close'>"
                                +
                                "<div class='in'><ion-icon name='alert-circle' class='text-light md hydrated' role='img' aria-label='alert'></ion-icon><div class='text'>"
                                +
                                "Material scanned Quantity exceed!"
                                +
                                "</div></div></div>"
                            );
                            toastbox('material-scan-qty-toast', 3000);
                            return;
                           
                        }


                      
                        //alert(GRfnd[i].GR_Number);
                    }
                }
                else {

                    $("body").append(
                        "<div id='GR-wrong-scan-toast' class='toast-box toast-top bg-secondary  tap-to-close'>"
                        +
                        "<div class='in'><ion-icon name='alert-circle' class='text-light md hydrated' role='img' aria-label='alert'></ion-icon><div class='text'>"
                        +
                        "Wrong material scanned!"
                        +
                        "</div></div></div>"
                    );
                    toastbox('GR-wrong-scan-toast', 3000);
                }

            })
            .then(function () {

                readDeliveryScanAllData();
            });
    }
}


SubmitButton.addEventListener('click', function (event) {
    event.preventDefault();
    var ScandataArray = [];
    //ScandataArray = ReadQRCodeScanner()
    readIndexData('scan-delivery-material', 'Document_No', txtDeliveryChallanNo.value)
        .then(function (data) {
            //.then(function (result) {
            console.log(data);
            if (data.length <= 0) {
                $("#DialogAlert").modal();
                $("#DialogAlert").find('.modal-title').html("Error!");
                $("#DialogAlert").find('.modal-body').html("You don't have scan data to submit");
                return;
            }
            if (parseInt(spanTotalQty.innerText) < parseInt(spanTotalScanQty.innerText)) {
                $("#DialogAlert").modal();
                $("#DialogAlert").find('.modal-title').html("Error!");
                $("#DialogAlert").find('.modal-body').html("Scan quantity is greater than total quantity");
              
                return;
            }
            if (parseInt(spanTotalQty.innerText) > parseInt(spanTotalScanQty.innerText)) {
                $("#DialogBasicConfirmation").data('data', data).modal('show');
                //$("#DialogBasicConfirmation").modal();
                $("#DialogBasicConfirmation").find('.modal-title').html("Alert!");
                $("#DialogBasicConfirmation").find('.modal-body').html("Scan quantity is less than total quantity <br/> Do you want to continue? ");
                return;
            }
            // Registered Service process
            ServiceRegister(data); 
            //if ('serviceWorker' in navigator && 'SyncManager' in window) {
            //    navigator.serviceWorker.ready
            //        .then(function (sw) {
            //            //for (var i = 0; i < data.length; i++) {
            //            BulkwriteData('sync-delivery-aws', data)
            //                .then(function () {
            //                    return sw.sync.register('sync-delivery-aws');
            //                })
            //                .then(function () {
            //                    //alert("Sync Started");

            //                    console.log("Sync Success");
            //                    //location.reload();
            //                    ClearData();
            //                })
            //                .then(function () {
            //                    $("body").append(
            //                        "<div id='delivery-success-toast' class='toast-box toast-top bg-success  tap-to-close'>"
            //                        +
            //                        "<div class='in'><ion-icon name='checkmark-circle' class='text-light md hydrated' role='img' aria-label='success'></ion-icon><div class='text'>"
            //                        +
            //                        "Added Successfull"
            //                        +
            //                        "</div></div></div>"
            //                    );
            //                    toastbox('delivery-success-toast', 4000);
            //                })
            //                .catch(function (err) {
            //                    console.log(err);
            //                    alert("Backround Sync failed" + err);
                          
            //                });
            //        });
            //}

        });


});



function ClearData() {
    const tbodyScan = document.getElementById("tbodyScan");
    while (tbodyScan.hasChildNodes()) {
        tbodyScan.removeChild(tbodyScan.firstChild);
    }

    const tbody = document.getElementById("tbody");
    const notfound = document.getElementById("notfound");
    notfound.textContent = "";
    // remove all childs from the dom first
    while (tbody.hasChildNodes()) {
        tbody.removeChild(tbody.firstChild);
    }
    txtDeliveryChallanNo.value = '';
    txtScan.value = '';
    txtDeliveryChallanNoFetch.value = '';
    SubmitButtonScan.style.display = 'none';
    clearAllData('delivery-material-details');
    dataArray = [];

    spanTotalQty.textContent = 0;
    spanTotalScanQty.textContent = 0;
}


txtDeliveryChallanNoFetch.oninput = handleInput;

function handleInput(e) {
    clearAllData('delivery-material-details');
    const tbody = document.getElementById("tbody");
    const notfound = document.getElementById("notfound");
    notfound.textContent = "";
    // remove all childs from the dom first
    while (tbody.hasChildNodes()) {
        tbody.removeChild(tbody.firstChild);
    }
    txtDeliveryChallanNo.value = '';
    txtScan.value = '';
    SubmitButtonScan.style.display = 'none';
    e.preventDefault();
}


ScannedMaterial.addEventListener('click', function () {

    var listScanMatrial = document.querySelector('#listScanMatrial');
    let ScanData = {};
    $("#PanelRight").modal();
    readIndexData('scan-delivery-material', 'Document_No', txtDeliveryChallanNo.value)
        .then(function (data) {
            console.log(data);
            //Scantable(data);

            ScanData = UniqArrayCount(data);

            //$("listScanMatrial").append(createListView(ScanData))
            listScanMatrial.innerHTML = createListView(ScanData);


        });


});


function ServiceRegister(data) {

    if ('serviceWorker' in navigator && 'SyncManager' in window) {
        navigator.serviceWorker.ready
            .then(function (sw) {
                //for (var i = 0; i < data.length; i++) {
                BulkwriteData('sync-delivery-aws', data)
                    .then(function () {
                        return sw.sync.register('sync-delivery-aws');
                    })
                    .then(function () {
                        //alert("Sync Started");

                        console.log("Sync Success");
                        //location.reload();
                        ClearData();
                    })
                    .then(function () {
                        $("body").append(
                            "<div id='delivery-success-toast' class='toast-box toast-top bg-success  tap-to-close'>"
                            +
                            "<div class='in'><ion-icon name='checkmark-circle' class='text-light md hydrated' role='img' aria-label='success'></ion-icon><div class='text'>"
                            +
                            "Added Successfull"
                            +
                            "</div></div></div>"
                        );
                        toastbox('delivery-success-toast', 4000);
                    })
                    .catch(function (err) {
                        console.log(err);
                        alert("Backround Sync failed" + err);

                    });
            });
    }
}