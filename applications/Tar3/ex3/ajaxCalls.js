//---------------------------------------------------------------------------
// get the distance from your current position to a point to the server
//---------------------------------------------------------------------------
function getDistance(request, successCB, failureCB) {

    dataString = JSON.stringify(request);
    $.ajax({ // ajax call starts
        url: 'TreasureAjax.asmx/getDistance',   // JQuery call to the server side method
        data: dataString,    // the parameters sent to the server
        type: 'POST',        // can be post or get
        dataType: 'json',    // Choosing a JSON datatype
        contentType: 'application/json; charset = utf-8', // of the data received
        timeout: 5000, // timeout in miliseconds
        success: successCB, // 
        error: failureCB 
        })// end of ajax call
}

//-----------------------------------------------------------------------
// Send the path point to the server
//-----------------------------------------------------------------------
function setPathPoint(request,successCB,failureCB) {
        dataString = JSON.stringify(request);
        $.ajax({ // ajax call starts
            url: 'TreasureAjax.asmx/setPathPoint',   // server side method
            data: dataString,    // name without the xml extension
            type: 'POST',
            dataType: 'json', // Choosing a JSON datatype
            contentType: 'application/json; charset = utf-8',
            timeout: 5000, // timeout in miliseconds
            success: successCB, // Variable data contains the data we get from serverside
            error: failureCB
            }) // end of ajax call
}

//-----------------------------------------------------------------------
// get the list of the path points
//-----------------------------------------------------------------------
function getPathList(request,successCB,failureCB) {
  //  var groupName = document.getElementById("groupNameTB").value;
    dataString = JSON.stringify(request);

    $.ajax({ // ajax call starts
        url: 'TreasureAjax.asmx/getPathList',   // server side method
        data: dataString,    // the parameters sent to the server
        type: 'POST',
        dataType: 'json', // Choosing a JSON datatype
        contentType: 'application/json; charset = utf-8',
        timeout: 5000, // timeout in miliseconds
        success: successCB,
        error: failureCB
    }) // end of ajax call
}

//-----------------------------------------------------------------------
// get the target point
//-----------------------------------------------------------------------
function getTarget(request,successCB,failureCB) {

    dataString = JSON.stringify(request);
    $.ajax({ // ajax call starts
        url: 'TreasureAjax.asmx/getTarget',   // server side method
        data: dataString, // the data sent to the server  
        type: 'POST',
        dataType: 'json', // Choosing a JSON datatype
        contentType: 'application/json; charset = utf-8',
        timeout: 5000, // timeout in miliseconds
        success: successCB,
        error: failureCB
    }) // end of ajax call
}

//-----------------------------------------------------------------------
// Send the target point to the server
//-----------------------------------------------------------------------
function setTarget(request, successCB, failureCB) {

    dataString = JSON.stringify(request);

    $.ajax({ // ajax call starts
        url: 'TreasureAjax.asmx/setTarget',   // server side method
        data: dataString,    // name without the xml extension
        type: 'POST',
        dataType: 'json', // Choosing a JSON datatype
        contentType: 'application/json; charset = utf-8',
        timeout: 5000, // timeout in miliseconds
        success: successCB,
        error: failureCB
    }) // end of ajax call
}


//-----------------------------------------------------------------------
// Send the Point Of Interst (POI) to the server
//-----------------------------------------------------------------------
function setPOI(request,successCB,failureCB) {

    dataString = JSON.stringify(request);

    $.ajax({ // ajax call starts
        url: 'TreasureAjax.asmx/setPOI',   // server side method
        data: dataString,    // the parameters sent to the server
        type: 'POST',
        dataType: 'json', // Choosing a JSON datatype
        contentType: 'application/json; charset = utf-8',
        timeout: 5000, // timeout in miliseconds
        success: successCB,
        error: failureCB
    }) // end of ajax call
}

//-----------------------------------------------------------------------
// get the point of interst (POI)  list
//-----------------------------------------------------------------------
function getPOIList(request,successCB, failureCB) {

    dataString = JSON.stringify(request);

    $.ajax({ // ajax call starts
        url: 'TreasureAjax.asmx/getPOIList',   // server side method
        data: dataString,    // parameters passed to the server
        type: 'POST',
        dataType: 'json', // Choosing a JSON datatype
        contentType: 'application/json; charset = utf-8',
        timeout: 10000, // timeout in miliseconds
        success: successCB, 
        error: failureCB
    }) // end of ajax call
}

function getChallenge(request, successCB, errorCB) {

    var dataString = JSON.stringify(request);

    $.ajax({
        url: 'TreasureAjax.asmx/GetChallenge',   // server side web service method
        data: dataString,                          // the parameters sent to the server
        type: 'POST',                              // can be also GET
        dataType: 'json',                          // expecting JSON datatype from the server     
        contentType: 'application/json; charset = utf-8', // sent to the server
        timeout: 5000, // timeout in miliseconds
        success: successCB,
        error: function (request, error, xhr) {
            errorCB(request.responseText);
        }
    });
}

