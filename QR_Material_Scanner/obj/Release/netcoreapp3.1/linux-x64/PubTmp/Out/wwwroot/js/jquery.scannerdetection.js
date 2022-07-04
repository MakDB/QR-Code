var OpenModelButton = document.querySelector('#open-model-button');

var SubmitButtonGR = document.querySelector('#btnGRSubmit');
var SubmitButton = document.querySelector('#btnSubmit');
var txtGRNoSearch = document.querySelector('#txtGRNo');
var txtfetchGRNO = document.querySelector('#txtfetchGRNO');
var txtScan = document.querySelector('#txtQrCode');
var form = document.querySelector('form');
var SubmitButtonScan = document.querySelector('#btnScanMaterial');
var elem = document.querySelector(".modal-backdrop");

function openModal(event) {

    $("#actionSheetForm").modal();

}

OpenModelButton.addEventListener('click', openModal);


function openModalFetchGR() {
    var GRFetchRecord = false;
    dataArray = [];
    var URL = "/api/P20551/C_Get_GR_Details/" + txtGRNoSearch.value.trim();
    if (txtGRNoSearch.value.trim() === '') return;

    fetch(URL)
        .then(function (res) {
            return res.json();
        })
        .then(function (data) {
            console.log('From web', data);

            clearAllData('posts');
            for (var key in data) {
                console.log('Array Single', key);
                writeData('posts', data[key]);
                GRFetchRecord = true;
            }
            readGRAllData();
        });
    GRFetchRecord = false;
    if (GRFetchRecord === false || GRFetchRecord === true) {

        SubmitButtonScan.style.display = "block";
    }
}
SubmitButtonGR.addEventListener('click', openModalFetchGR);



function readGRAllData() {
    readAllData('posts')
        .then(function (data) {
            console.log(data);
            Fetchtable(data);
            //return data;
        });
}

// create dynamic table
function Fetchtable(data) {

    //var data = readGRAllData();
    const tbody = document.getElementById("tbody");
    const notfound = document.getElementById("notfound");
    notfound.textContent = "";
    // remove all childs from the dom first
    while (tbody.hasChildNodes()) {
        tbody.removeChild(tbody.firstChild);
    }
    if (data) {
        for (let key of data) {
            obj = SortObj(key);
            txtGRNoSearch.textContent = obj.GR_Number;
            createEle("tr", tbody, tr => {
                for (const value in obj) {
                    createEle("td", tr, td => {
                        //td.textContent = key.id === key[value] ? `$ ${key[value]}` : key[value];
                        td.textContent = obj.id === obj[value] ? obj[value] : obj[value];
                    });
                }

            });
        }
    }
    else {
        notfound.textContent = "No record found in the database...!";
    }

}


function openScanMaterial(event) {

    if (txtGRNoSearch.value.trim() !== "") {
        txtfetchGRNO.value = txtGRNoSearch.value;
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
    }
});

document.addEventListener('textInput', function (e) {

    if (dataArray.length === 0) {
        readAllData('posts')
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
            //ValidationScanCode(e.data);
            //writeData('scan-material', ScanObj);
        }
        else {
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
        //readGRScanAllData();
    }


    //txtScan.onkeydown = txtScan.onkeypress = function () { return false };
});