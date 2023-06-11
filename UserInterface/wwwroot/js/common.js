function padTo2Digits(num) {
    return num.toString().padStart(2, '0');
}

function notPadTo2Digits(string) {
    if (string.indexOf('0') == 0) {
        return string[1];
    }
    else {
        return string;
    }
}

function formatDate(date = new Date()) {
    var str_date = [
        date.getFullYear(),
        padTo2Digits(date.getMonth() + 1),
        padTo2Digits(date.getDate()),
    ].join('-');
    var str_time = [
        padTo2Digits(date.getHours()),
        padTo2Digits(date.getMinutes()),
        padTo2Digits(date.getSeconds())
    ].join(':');
    return str_date + 'T' + str_time;
}

function dateFormat(string) {
    var datetimearr = string.split('T');
    var datearr = datetimearr[0].split('-');
    datearr[1] = notPadTo2Digits(datearr[1]);
    datearr[2] = notPadTo2Digits(datearr[2]);
    var timearr = datetimearr[1].split(':');
    timearr[0] = notPadTo2Digits(timearr[0]);
    timearr[1] = notPadTo2Digits(timearr[1]);
    timearr[2] = notPadTo2Digits(timearr[2]);
    var date = new Date();
    date.setFullYear(parseInt(datearr[0]));
    date.setMonth(parseInt(datearr[1]) - 1)
    date.setDate(parseInt(datearr[2]));
    date.setHours(timearr[0]);
    date.setMinutes(timearr[1]);
    date.setSeconds(timearr[2]);
    return date;
}