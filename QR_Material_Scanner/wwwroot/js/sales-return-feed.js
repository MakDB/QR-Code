var SubmitButtonSalesReturn = document.querySelector('#btnSalesReturnSubmit');
var SubmitSRButton = document.querySelector('#btnSubmitSalesReturn');
var txtSalesReturnNo = document.querySelector('#txtSalesReturnNo');
var txtSalesReturnNoFetch = document.querySelector('#txtSalesReturnFetch');
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


spanTotalQty.textContent = 0;
spanTotalScanQty.textContent = 0;
var SalesReturnDataArray = [];
var SalesReturnFetchRecord = false;
SubmitButtonScan.style.display = "none";

var objSalesReturn = {};
function openModalFetchSalesReturn() {

    SalesReturnDataArray = [];
    var URL = "/api/P20551/C_Get_GR_Details/" + txtSalesReturnNoFetch.value.trim() + "/SR";
    if (txtSalesReturnNoFetch.value.trim() === '') return;

    fetch(URL)
        .then(function (res) {
            return res.json();
        })
        .then(function (data) {
            console.log('From web', data);
            clearAllData('sales-return-material-details');
            if (data.length <= 0) {
                $('#actionSheetForm').modal('hide');
                $("#DialogAlert").modal();
                $("#DialogAlert").find('.modal-title').html("Alert!");
                $("#DialogAlert").find('.modal-body').html("Sales Return Number:<strong>" + txtSalesReturnNoFetch.value.trim() + "</strong> is Not found");
                SubmitButtonScan.style.display = 'none';
                return;
            }
            
            for (var key in data) {
                console.log('Array Single', key);
                //writeData('sales-return-material-details', data[key]);
                //SalesReturnFetchRecord = true;

                if (data[key].Quantity <= 0) {
                    GRAlreadyDone = true;
                    SubmitButtonScan.style.display = 'none';
                    $('#actionSheetForm').modal('hide');
                    $("#DialogAlert").modal();
                    $("#DialogAlert").find('.modal-title').html("Error!");
                    $("#DialogAlert").find('.modal-body').html("Sales Return Number:<strong>" + txtSalesReturnNoFetch.value.trim() + "</strong> scan data is already submitted");
                    return;
                }
                else {
                    writeData('sales-return-material-details', data[key]);
                    SalesReturnFetchRecord = true;
                    SubmitButtonScan.style.display = 'block';
                }
            }
            readSalesReturnAllData();
        });
    SalesReturnFetchRecord = false;

}
SubmitButtonSalesReturn.addEventListener('click', openModalFetchSalesReturn);

function openModalSalesReturn(event) {

    $("#actionSheetForm").modal();

}




OpenModelButton.addEventListener('click', openModalSalesReturn);


function readSalesReturnAllData() {
    readAllData('sales-return-material-details')
        .then(function (data) {
            console.log(data);
            SalesReturnFetchTable(data);
            //return data;
        });
}
function readSalesReturnScanAllData() {
    readIndexData('scan-sales-return-material', 'Document_No', txtSalesReturnNo.value)
        .then(function (data) {
            console.log(data);
            //Scantable(data);
            console.log(data.sort((a, b) => b.Capturing_Date > a.Capturing_Date) ? 1 : (b.Capturing_Date < a.Capturing_Date) ? -1 : 0);
            spanTotalScanQty.textContent = parseInt(data.length);  //Do the math!

            SalesReturnScantable(data.sort((a, b) => b.Capturing_Date > a.Capturing_Date ? 1 : (b.Capturing_Date < a.Capturing_Date) ? -1 : 0));
            //return data.sort((a, b) => b.Capturing_Date > a.Capturing_Date ? 1 : (b.Capturing_Date < a.Capturing_Date) ? -1 : 0);
        });
}

// create dynamic table
function SalesReturnFetchTable(data) {

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
            objSalesReturn = SortObj(key);
            txtSalesReturnNo.value = objSalesReturn.GR_Number;
            TotalQty += parseInt(objSalesReturn.Quantity);

            spanTotalQty.textContent = TotalQty;
            createEle("tr", tbody, tr => {
                for (const value in objSalesReturn) {
                    createEle("td", tr, td => {
                        //td.textContent = key.id === key[value] ? `$ ${key[value]}` : key[value];
                        td.textContent = objSalesReturn.id === objSalesReturn[value] ? objSalesReturn[value] : objSalesReturn[value];
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
function SalesReturnScantable(data) {

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
            var Scanobj = SortScanObj(key);

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
    deleteItemFromData('scan-sales-return-material', id);

    readSalesReturnScanAllData();
    $('#DialogBasic').modal('hide');
});








function openSalesReturnScanMaterial(event) {

    if (txtSalesReturnNo.value.trim() !== "") {

        //modal.style.display = 'none';
        var elem = document.querySelector(".modal-backdrop");
        elem.remove();
        txtScan.focus();
    }
    event.preventDefault();
}
SubmitButtonScan.addEventListener('click', openSalesReturnScanMaterial, false);





document.addEventListener('keypress', function (e) {
    if (e.keyCode === 13) {
        //txtScan.onkeydown = txtScan.onkeypress = function () { return false };
        txtScan.focus();
        //setTimeout(function () { history.go(-1); }, 3000);



    }
});

document.addEventListener('textInput', function (e) {

    if (SalesReturnDataArray.length === 0) {
        readAllData('sales-return-material-details')
            .then(function (data) {
                //var SalesReturnDataArray = [];
                for (var key in data) {
                    SalesReturnDataArray.push(data[key]);
                }
            }).then(function (d) {

                if (e.data.length >= 10) {
                    console.log('IR scan textInput', e.data);
                    // var ScanObj = ScanMaterialObj(e.data + "," + txtfetchGRNO.value.trim());
                    if (txtSalesReturnNo.value.trim() !== "") {
                        ValidationSalesReturnScanCode(e.data);
                        //writeData('scan-material', ScanObj);
                    }
                    else {
                        $("body").append(
                            "<div id='sales-return-toast' class='toast-box toast-top bg-warning tap-to-close'>"
                            +
                            "<div class='in'><ion-icon name='alert' class='text-light md hydrated' role='img' aria-label='alert'></ion-icon><div class='text'>"
                            +
                            "Sales Return Number can not be blank!"
                            +
                            "</div></div></div>"
                        );
                        toastbox('sales-return-toast', 3000);
                    }
                    //readSalesReturnScanAllData();

                }
            });
    }
    else {
        if (e.data.length >= 10) {
            console.log('IR scan textInput', e.data);
            // var ScanObj = ScanMaterialObj(e.data + "," + txtfetchGRNO.value.trim());
            if (txtSalesReturnNo.value.trim() !== "") {
                ValidationSalesReturnScanCode(e.data);
                //writeData('scan-material', ScanObj);
            }
            else {
                $("body").append(
                    "<div id='sales-return-toast' class='toast-box toast-top bg-warning tap-to-close'>"
                    +
                    "<div class='in'><ion-icon name='alert' class='text-light md hydrated' role='img' aria-label='alert'></ion-icon><div class='text'>"
                    +
                    "Sales Return Number can not be blank!"
                    +
                    "</div></div></div>"
                );
                toastbox('sales-return-toast', 3000);
            }
            //readSalesReturnScanAllData();

        }
    }

    //txtScan.onkeydown = txtScan.onkeypress = function () { return false };
});



function ValidationSalesReturnScanCode(input) {

    if (SalesReturnDataArray.length !== 0) {
        var ScanArr = input.split(',');
        let MaterialCode = ScanArr[0];
        let ScanData = [];
        var SalesReturnScanCount = 0;
        var SalesReturnfind = SalesReturnDataArray.filter(e => e.Material_Number.indexOf(MaterialCode) >= 0);

        readIndexData('scan-sales-return-material', 'Document_No', txtSalesReturnNo.value)
            .then(function (data) {
                console.log(data);
                //Scantable(data);

                ScanData = UniqArrayCount(data);
            })
            .then(function (data) {
                if (SalesReturnfind.length > 0) {
                    for (var i = 0; i < SalesReturnfind.length; i++) {
                        var SalesReturnScanfind = ScanData.filter(e => e.Material_Number.indexOf(SalesReturnfind[i].Material_Number) >= 0);
                        if ("undefined" != typeof SalesReturnScanfind[0]) {
                            //array value is not there...
                            SalesReturnScanCount = SalesReturnScanfind[0].Count
                        }
                        if (SalesReturnScanCount < SalesReturnfind[i].Quantity) {

                            var SalesReturnScanObj = ScanSalesReturnMaterialObj(input + "," + SalesReturnfind[i].GR_Number + "," + SalesReturnfind[i].Line_Item_Number + "," + SalesReturnfind[i].Plant + "," + SalesReturnfind[i].Storage_Location + "," + SalesReturnfind[i].Vendor + "," + SalesReturnfind[i].PO_Number + "," + "SR");
                            writeData('scan-sales-return-material', SalesReturnScanObj);
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
                        "<div id='sales-return-wrong-scan-toast' class='toast-box toast-top bg-secondary  tap-to-close'>"
                        +
                        "<div class='in'><ion-icon name='alert-circle' class='text-light md hydrated' role='img' aria-label='alert'></ion-icon><div class='text'>"
                        +
                        "Wrong material scanned!"
                        +
                        "</div></div></div>"
                    );
                    toastbox('sales-return-wrong-scan-toast', 3000);
                }

            })
            .then(function () {

                readSalesReturnScanAllData();
            });
    }
}


SubmitSRButton.addEventListener('click', function (event) {
    event.preventDefault();
    var ScandataArray = [];
    //ScandataArray = ReadQRCodeScanner()
    readIndexData('scan-sales-return-material', 'Document_No', txtSalesReturnNo.value)
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
                $("#DialogAlert").modal();
                $("#DialogAlert").find('.modal-title').html("Error!");
                $("#DialogAlert").find('.modal-body').html("Scan quantity is less than total quantity");
                return;
            }

            if ('serviceWorker' in navigator && 'SyncManager' in window) {
                navigator.serviceWorker.ready
                    .then(function (sw) {
                        //for (var i = 0; i < data.length; i++) {
                        BulkwriteData('sync-sales-return-aws', data)
                            .then(function () {
                                return sw.sync.register('sync-sales-return-aws');
                            })
                            .then(function () {
                                //alert("Sync Started");

                                console.log("Sync Success");
                                //location.reload();
                                ClearData();
                            })
                            .then(function () {
                                $("body").append(
                                    "<div id='sales-return-success-toast' class='toast-box toast-top bg-success  tap-to-close'>"
                                    +
                                    "<div class='in'><ion-icon name='checkmark-circle' class='text-light md hydrated' role='img' aria-label='success'></ion-icon><div class='text'>"
                                    +
                                    "Added Successfull"
                                    +
                                    "</div></div></div>"
                                );
                                toastbox('sales-return-success-toast', 4000);
                            })
                            .catch(function (err) {
                                console.log(err);
                                alert("Backround Sync failed" + err);

                            });
                    });
            }

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
    txtSalesReturnNo.value = '';
    txtScan.value = '';
    txtSalesReturnNoFetch.value = '';
    SubmitButtonScan.style.display = 'none';
    clearAllData('sales-return-material-details');
    SalesReturnDataArray = [];

    spanTotalQty.textContent = 0;
    spanTotalScanQty.textContent = 0;
}


txtSalesReturnNoFetch.oninput = handleInput;

function handleInput(e) {
    clearAllData('sales-return-material-details');
    const tbody = document.getElementById("tbody");
    const notfound = document.getElementById("notfound");
    notfound.textContent = "";
    // remove all childs from the dom first
    while (tbody.hasChildNodes()) {
        tbody.removeChild(tbody.firstChild);
    }
    txtSalesReturnNo.value = '';
    txtScan.value = '';
    SubmitButtonScan.style.display = 'none';
    e.preventDefault();
}


ScannedMaterial.addEventListener('click', function () {

    var listScanMatrial = document.querySelector('#listScanMatrial');
    let ScanData = {};
    $("#PanelRight").modal();
    readIndexData('scan-sales-return-material', 'Document_No', txtSalesReturnNo.value)
        .then(function (data) {
            console.log(data);
            //Scantable(data);

            ScanData = UniqArrayCount(data);

            //$("listScanMatrial").append(createListView(ScanData))
            listScanMatrial.innerHTML = createListView(ScanData);


        });


});
