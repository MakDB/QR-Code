var SubmitButtonGR = document.querySelector('#btnGRSubmit');
var SubmitButton = document.querySelector('#btnSubmit');
var txtGRNoSearch = document.querySelector('#txtGRNo');
var txtfetchGRNO = document.querySelector('#txtfetchGRNO');
var txtScan = document.querySelector('#txtQrCode');
var form = document.querySelector('form');
var SubmitButtonScan = document.querySelector('#btnScanMaterial');
//var modalFade = document.querySelector('modal-backdrop fade show');
var elem = document.querySelector(".modal-backdrop");
//var modal = document.querySelector('#actionSheetForm');
var OpenModelButton = document.querySelector('#open-model-button');

var spanTotalQty = document.querySelector('#spanTotalQty');
var spanTotalScanQty = document.querySelector('#spanTotalScanQty');
var btnDialogWarningOk = document.querySelector('#btnDialogWarningOk');

var ScannedMaterial = document.querySelector('#hylScanMaterial');
var PanelRight = document.querySelector('#PanelRight');

const queryString = window.location.search;
console.log(queryString);
const urlParams = new URLSearchParams(queryString);


if (urlParams.has('document_no')) {

    const document_no = urlParams.get('document_no');
    console.log(document_no);
    openModal('click');
    txtGRNoSearch.value = document_no;

    openModalFetchGR();
}



spanTotalQty.textContent = 0;
spanTotalScanQty.textContent = 0;
var dataArray = [];
SubmitButtonScan.style.display = "none";



var obj = {};
var GRFetchRecord = false;
var GRAlreadyDone = false;



readGRScanAllData();

function openModalFetchGR() {
    GRFetchRecord = false;
    GRAlreadyDone = false;
    dataArray = [];
    var URL = "/api/P20551/C_Get_GR_Details/" + encodeURIComponent(txtGRNoSearch.value.trim()) + "/GR";
    
    if (txtGRNoSearch.value.trim() === '') return;
    
    fetch(URL)
            .then(function (res) {
                return res.json();
            })
            .then(function (data) {
                console.log('From web', data);
                clearAllData('goods-material-details');
                if (data.length <= 0)
                {
                    $('#actionSheetForm').modal('hide');
                    $("#DialogWarningRefNo").data('GR', txtGRNoSearch.value.trim()).modal('show');
                    $("#DialogWarningRefNo").find('.modal-title').html("Alert!");
                    $("#DialogWarningRefNo").find('.modal-body').html("GR Number:<strong>" + txtGRNoSearch.value.trim()+"</strong> is Not found </br> Do you want to continue as a Reference Number?");
                    SubmitButtonScan.style.display = 'none';
                    return;
                }

                for (var key in data) {
                    console.log('Array Single - ', data[key]);
                    if (data[key].Quantity <= 0) {
                        GRAlreadyDone = true;
                        SubmitButtonScan.style.display = 'none';
                        $('#actionSheetForm').modal('hide');
                        $("#DialogAlert").modal();
                        $("#DialogAlert").find('.modal-title').html("Error!");
                        $("#DialogAlert").find('.modal-body').html("GR number:<strong>" + txtGRNoSearch.value.trim() + "</strong> scan data is already submitted");
                        return;
                    }
                    else {
                        writeData('goods-material-details', data[key]);
                        GRFetchRecord = true;
                        GRAlreadyDone = false;
                        SubmitButtonScan.style.display = 'block';
                    }

                }
                readGRAllData();
            });
    GRFetchRecord = false;
    //if (GRFetchRecord === false || GRFetchRecord === true)
    //{
    
    //    SubmitButtonScan.style.display = "block";
    //}

}
SubmitButtonGR.addEventListener('click', openModalFetchGR);

function openModal(event)
{
    
    $("#actionSheetForm").modal();

}

OpenModelButton.addEventListener('click', openModal);


function readGRAllData() {
    readAllData('goods-material-details')
        .then(function (data) {
            console.log(data);
            Fetchtable(data);
            //return data;
        });
}
function readGRScanAllData() {
    readIndexData('scan-goods-material','Document_No',txtfetchGRNO.value)
        .then(function (data) {
            console.log(data);
            //Scantable(data);
            console.log(data.sort((a, b) => b.Capturing_Date > a.Capturing_Date) ? 1 : (b.Capturing_Date < a.Capturing_Date) ? -1 : 0);
            spanTotalScanQty.textContent = parseInt(data.length);  //Do the math!
            Scantable(data.sort((a, b) => b.Capturing_Date > a.Capturing_Date ? 1 : (b.Capturing_Date < a.Capturing_Date) ? -1 : 0));
            //return data.sort((a, b) => b.Capturing_Date > a.Capturing_Date ? 1 : (b.Capturing_Date < a.Capturing_Date) ? -1 : 0);
        });
}

// create dynamic table
function Fetchtable(data) {

    //var data = readGRAllData();
    const tbody = document.getElementById("tbody");
    const notfound = document.getElementById("notfound");
    notfound.textContent = "";
    let TotalQty = 0;
    // remove all childs from the dom first
    while (tbody.hasChildNodes()) {
        tbody.removeChild(tbody.firstChild);
    }
    if (data.length > 0) {
        for (let key of data) {
            obj = SortObj(key);
            txtGRNoSearch.textContent = obj.GR_Number;

            TotalQty += parseInt(obj.Quantity);

            spanTotalQty.textContent = TotalQty; 

            createEle("tr", tbody, tr => {
                for (const value in obj) {
                    createEle("td", tr, td => {
                        //td.textContent = key.id === key[value] ? `$ ${key[value]}` : key[value];
                        td.textContent = obj.id === obj[value] ? obj[value] : obj[value] ;
                    });
                }

            });
        }
    }
    else {
        notfound.textContent = "No record found in the database...!";
    }

}



function Scantable(data) {

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
                        //i.textContent = "❌";
                        // store number of edit buttons
                        i.setAttribute('data-Serial_Number', Scanobj.Serial_Number);
                        i.innerHTML = " <span class='iconedbox-sm text-danger'><ion-icon name='trash-outline'></ion-icon></span>";

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
    //let id = event.target.getAttribute('data-Serial_Number');
    let id = event.currentTarget.getAttribute('data-Serial_Number');

    $("#DialogBasic").data('id', id).modal('show');
    event.preventDefault();
    //deleteItemFromData('scan-material',id);
    //readGRScanAllData();
}

$('#btnDeleteYesNo').click(function () {
    let id = $('#DialogBasic').data('id');
    deleteItemFromData('scan-goods-material',id);
    readGRScanAllData();
    $('#DialogBasic').modal('hide');
});

function openScanMaterial(event) {

    if (txtGRNoSearch.value.trim() !== "") {
        txtfetchGRNO.value = txtGRNoSearch.value;
        //modal.style.display = 'none';
        //var elem = document.querySelector(".modal-backdrop");
        //elem.remove();
        $('#actionSheetForm').modal('hide');
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
        readAllData('goods-material-details')
            .then(function (data) {
                //var dataArray = [];
                for (var key in data) {
                    dataArray.push(data[key]);
                }
            });
       }
        if (e.data.length >= 10) {
            console.log('IR scan textInput', e.data);
           // var ScanObj = ScanMaterialObj(e.data + "," + txtfetchGRNO.value.trim());
            if (txtfetchGRNO.value.trim() !== "") {
                ValidationScanCode(e.data);
                //writeData('scan-material', ScanObj);
            }
            else
            {
                $("body").append(
                    "<div id='GR-toast' class='toast-box toast-top bg-warning tap-to-close'>"
                    +
                    "<div class='in'><ion-icon name='alert' class='text-light md hydrated' role='img' aria-label='alert'></ion-icon><div class='text'>"
                    +
                    "GR / Document Number can not be blank!"
                    +
                    "</div></div></div>"
                );
                toastbox('GR-toast', 3000);
            }
            readGRScanAllData();
          
          

        
    }
   
   
    //txtScan.onkeydown = txtScan.onkeypress = function () { return false };
});


function ValidationScanCode(input) {

    if (dataArray.length !== 0) {
        var ScanArr = input.split(',');
        let MaterialCode = ScanArr[0];
        var GRfnd = dataArray.filter(e => e.Material_Number.indexOf(MaterialCode) >= 0);
        if (GRfnd.length > 0) {
            for (var i = 0; i < GRfnd.length; i++) {

                var ScanObj = ScanMaterialObj(input + "," + GRfnd[i].GR_Number + "," + GRfnd[i].Line_Item_Number + "," + GRfnd[i].Plant + "," + GRfnd[i].Storage_Location + "," + GRfnd[i].Vendor + "," + GRfnd[i].PO_Number+"," + "Y");
                writeData('scan-goods-material', ScanObj);
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
    }
    else
    {
        var ScanObj = ScanMaterialObj(input + "," + txtfetchGRNO.value.trim() + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + "N");
        writeData('scan-goods-material', ScanObj);

    }
}


SubmitButton.addEventListener('click', function (event) {
    event.preventDefault();
    
    var ScandataArray = [];
    //ScandataArray = ReadQRCodeScanner()
    readIndexData('scan-goods-material', 'Document_No', txtfetchGRNO.value)
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
                $("#DialogWarning").data('data', data).modal('show');
                //$("#DialogWarning").modal();
                $("#DialogWarning").find('.modal-title').html("Warning!");
                $("#DialogWarning").find('.modal-body').html("Scan quantity is greater than total quantity.<br/> Are you sure you want to continue?");
                return;
               
            }
            if (parseInt(spanTotalQty.innerText) > parseInt(spanTotalScanQty.innerText)) {
                $("#DialogWarning").data('data', data).modal('show');
               // $("#DialogWarning").modal();
                $("#DialogWarning").find('.modal-title').html("Warning!");
                $("#DialogWarning").find('.modal-body').html("Scan quantity is less than total quantity.<br/> Are you sure you want to continue?");
   
                return;
            }
            SendDataSyncManager(data);
            

        });
    

});


function ReadQRCodeScanner() {
    var ScandataArray = [];

    readIndexData('scan-goods-material', 'Document_No', txtfetchGRNO.value)
        .then(function (data) {

            for (var key in data) {
                ScandataArray.push(data[key]);
            }

            return ScandataArray;
        });
}

function SendDataSyncManager(data) {
    if (data.length > 0) 
    //if (data.length > 0)
    {
        if ('serviceWorker' in navigator && 'SyncManager' in window) {
            navigator.serviceWorker.ready
                .then(function (sw) {
                    //for (var i = 0; i < data.length; i++) {
                    BulkwriteData('sync-goods-aws', data)
                        .then(function () {
                            return sw.sync.register('sync-goods-aws');
                        })
                        .then(function () {
                            //alert("Sync Started");

                            console.log("Sync Success");
                            //location.reload();
                            ClearGRData();
                        })
                        .then(function () {
                           
                            $("body").append(
                                "<div id='GR-success-toast' class='toast-box toast-top bg-success  tap-to-close'>"
                                +
                                "<div class='in'><ion-icon name='checkmark-circle' class='text-light md hydrated' role='img' aria-label='success'></ion-icon><div class='text'>"
                                +
                                "Added Successfull"
                                +
                                "</div></div></div>"
                            );
                            toastbox('GR-success-toast', 4000);
                        })
                        .catch(function (err) {
                            console.log(err);
                            alert("Backround Sync failed" + err);
                            //return data;
                        });
                });
        }
        else {

            //SendData(data);
        }

    }
   
}

$('#btnDialogWarningOk').click(function () {

    let data = $('#DialogWarning').data('data');
    SendDataSyncManager(data);
   
    $('#DialogWarning').modal('hide');
});

$('#btnDialogWarningRefNoOk').click(function () {
    let GR = $('#DialogWarningRefNo').data('GR');
    if (GR !== "") {
        txtfetchGRNO.value = GR;
        //modal.style.display = 'none';
       
        txtScan.focus();
    }

    $('#DialogWarningRefNo').modal('hide');
});


function ClearGRData()
{
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
    txtGRNoSearch.value = '';
    txtScan.value = '';
    txtfetchGRNO.value = '';
    SubmitButtonScan.style.display = 'none';
    clearAllData('goods-material-details');
    dataArray = [];

    spanTotalQty.textContent = 0;
    spanTotalScanQty.textContent = 0;
}


txtGRNoSearch.oninput = handleInput;

function handleInput(e) {
    clearAllData('goods-material-details');
    const tbody = document.getElementById("tbody");
    const notfound = document.getElementById("notfound");
    notfound.textContent = "";
    // remove all childs from the dom first
    while (tbody.hasChildNodes()) {
        tbody.removeChild(tbody.firstChild);
    }
    txtScan.value = '';
    txtfetchGRNO.value = '';
    SubmitButtonScan.style.display = 'none';
    e.preventDefault();
}


ScannedMaterial.addEventListener('click', function () {
    
    var listScanMatrial = document.querySelector('#listScanMatrial');
    let ScanData = {};
    $("#PanelRight").modal();
     readIndexData('scan-goods-material', 'Document_No', txtfetchGRNO.value)
        .then(function (data) {
            console.log(data);
            //Scantable(data);

            ScanData = UniqArrayCount(data);

            //$("listScanMatrial").append(createListView(ScanData))
            listScanMatrial.innerHTML = createListView(ScanData);
            

        });


});


