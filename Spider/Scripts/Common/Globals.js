var Globals = {};

Globals.CheckCommonErrorByStr = function (repStr) {

    var repObj = JSON.parse(repStr);

    if (repObj != null && repObj != undefined) {
        if (repObj.success == false) {
            alert(repObj.message);
            return false;
        }
    }

    return true;
}