let GR = 0;
let DL = 0;
let Sync = 0;

var UserName = getCookie("UserName");
var Plant = getCookie("Plant");

if (UserName === '' || Plant === '') {
    //window.location.href = "./home";
    window.location = '/login';
}


if (navigator.onLine) {
    var URL = "/api/P20551/C_Get_Dashboard_Chart/GR/" + getCookie("Plant");

    fetch(URL)
        .then(function (res) {
            return res.json();
        })
        .then(function (data) {
            console.log(data);
            GR = [...new Set(data.map(x => x.Document_No))].length;
            $('#grpending').text(GR);
            $("#actionSheetContent").data('GRdata', data);
        });
    //return dataArray

   

    var URL_DL = "/api/P20551/C_Get_Dashboard_Chart/DL/" + getCookie("Plant");

    fetch(URL_DL)
        .then(function (res) {
            return res.json();
        })
        .then(function (data) {
            console.log(data);
            DL = [...new Set(data.map(x => x.Document_No))].length;
            $('#dlpending').text(DL);
            $("#actionSheetContent").data('DLdata', data);
        });

   

    var URL_Sync = "/api/P20551/C_Get_Dashboard_Chart/WGR/" + getCookie("Plant");

    fetch(URL_Sync)
        .then(function (res) {
            return res.json();
        })
        .then(function (data) {
            console.log(data);
            Sync = [...new Set(data.map(x => x.Document_No))].length;
            $('#syncpending').text(Sync);
            $("#actionSheetContent").data('Syncdata', data);
        });
}
else {
    $('#grpending').text(GR);
    $('#dlpending').text(DL);
    $('#syncpending').text(Sync);
}



$('#circle1').click(function () {
    $("#actionSheetContent").modal();
    let GR = $('#actionSheetContent').data('GRdata');
    $("#actionSheetContent").find('.modal-title').html("Goods Receipt Pending Details");
    FetchDashbaordTable(GR,"Goods_Receipts");
});

$('#circle2').click(function () {
    $("#actionSheetContent").modal();
    let DL = $('#actionSheetContent').data('DLdata');
    $("#actionSheetContent").find('.modal-title').html("Delivery Receipt Pending Details");
    FetchDashbaordTable(DL, "delivery");
});

$('#circle3').click(function () {
    $("#actionSheetContent").modal();
    let Sync = $('#actionSheetContent').data('Syncdata');
    $("#actionSheetContent").find('.modal-title').html("Reference No Sync Pending Details");
    FetchDashbaordTable(Sync);
});

function FetchDashbaordTable(data , page) {
    const tbody = document.getElementById("dashboardtbody");
    const notfound = document.getElementById("notfound");
    notfound.textContent = "";
    
    while (tbody.hasChildNodes()) {
        tbody.removeChild(tbody.firstChild);
    }
    if (data.length > 0) {
        for (let key of data) {
            
          
            createEle("tr", tbody, tr => {
               
                for (const value in key) {
                    createEle("td", tr, td => {
                     
                        //td.textContent = key.id === key[value] ? `$ ${key[value]}` : key[value];
                        //td.innerHTML =  '<a href="https://google.com">'
                    
                        td.innerHTML = key.Document_No === key[value] ? "<a href='/" + page +"?document_no=" + key[value]+" '>" + key[value] + "</a>" : key[value];
                        
                    });
                }

            });
        }
    }
    else {
        notfound.textContent = "No record found in the database...!";
    }

}