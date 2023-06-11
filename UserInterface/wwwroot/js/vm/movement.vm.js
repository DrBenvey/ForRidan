
var MovementViewModel = function () {
    var self = this;

    //base url
    var base_url = '/movement';

    //Movements
    self.Movements = ko.observableArray([]);
    self.MovementReport = ko.observable({
        id_stock: 0,
        id_product: 0,
        сreated: formatDate(),
        balance: 0
    });
    self.MovementMove = ko.observable({
        id_stock: 0,
        id_product: 0,
        сreated: formatDate(),
        balance: 0
    });
    loadMovements();

    //functions for Movements
    self.reloadMovements = function () {
        loadMovements();
    }

    function loadMovements() {
        $.get(`${base_url}/Read`, function (data, status) {
            if (status != 'success') {
                alert("error");
                return;
            }
            self.Movements(data)
        })
            .fail(function () {
                alert("error");
            }
        );
    }

    function actionMovement(tmp) {
        $.post(`${base_url}/Create`,
            {
                obj: Object.create(tmp)
            },
            function (data, status) {
                if (status != "success") {
                    alert("error");
                    return;
                }
                loadMovements();               
                self.MovementMove({
                    id_stock: 0,
                    id_product: 0,
                    сreated: formatDate(),
                    balance: 0
                });
            }, "json")
            .fail(function () {
                alert("error");
            });
    }

    function CheckBalance(balance) {
        if (balance <= 0) {
            return false;
        }
        else {
            return true;
        }
    }

    self.plusMovement = function () {
        if (CheckBalance(self.MovementMove().balance)) {
            var tmp = {
                id_stock: self.MovementMove().id_stock,
                id_product: self.MovementMove().id_product,
                сreated: (dateFormat($('#MoveTime').val())).toJSON(),
                balance: self.MovementMove().balance
            }
            actionMovement(tmp);
        }
        else {
            alert("error");
        }
    }

    self.minusMovement = function () {
        if (CheckBalance(self.MovementMove().balance)) {
            var tmp = {
                id_stock: self.MovementMove().id_stock,
                id_product: self.MovementMove().id_product,
                сreated: (dateFormat($('#MoveTime').val())).toJSON(),
                balance: -1 * self.MovementMove().balance
            }
            actionMovement(tmp);
        }
        else {
            alert("error");
        }
    }

    self.getReport = function () {
        var tmp = {
            id_stock: self.MovementReport().id_stock,
            id_product: self.MovementReport().id_product,
            сreated: (dateFormat($('#ReportTime').val())).toJSON(),
            balance: 0
        }
        $.post(`${base_url}/GetReport`,
            {
                obj: Object.create(tmp)
            },
            function (data, status) {
                if (status != "success") {
                    alert("error");
                    return;
                }
                self.MovementReport({
                    id_stock: self.MovementReport().id_stock,
                    id_product: self.MovementReport().id_product,
                    сreated: self.MovementReport().сreated,
                    balance: data });
            }, "json")
            .fail(function () {
                alert("error");
            });
    }
    
} // MovementViewModel
$(function () {
    ko.applyBindings(new MovementViewModel(), $('#MovementsGroup')[0]);
});