var StockViewModel = function () {
    var self = this;

    //base url
    var base_url = '/stock';

    //Stocks
    self.Stocks = ko.observableArray([]);    
    self.Stock = ko.observable({ id: 0, name: '', address: '' });
    loadStocks();

    //functions for Stocks
    function loadStocks() {
        $.get(`${base_url}/Read`, function (data, status) {
            if (status != 'success') {
                alert("error");
                return;
            }
            self.Stocks(data)
        })
            .fail(function () {
                alert("error");
            }
        );
    }

    self.deleteStocks = function (id) {
        $.ajax({
            url: `${base_url}/Delete`,
            type: "DELETE",
            data: {
                "key": id
            },
            success: function () {
                self.Stocks.remove(
                    function (item) {
                        return item.id == id;
                    }
                );
            },
            error: function () {
                alert("error");
            }
        })

    }

    self.updateStocks = function (id) {
        var match = ko.utils.arrayFirst(self.Stocks(), function (item) {
            return item.id == id;
        });
        $.ajax({
            url: `${base_url}/Update`,
            type: 'PUT',
            data: {
                "obj": match
            },
            error: function () {
                alert("error");
            }
        });
    }

    self.addStocks = function () {
        $.post(`${base_url}/Create`,
            {
                obj: self.Stock()
            },
            function (data, status) {
                if (status != "success") {
                    alert("error");
                    return;
                }
                self.Stocks.push(data);
                self.Stock({ id: 0, name: '', address: '' });
                
            }, "json")
            .fail(function () {
                alert("error");
            });
    }
} // StockViewModel
$(function () {
    ko.applyBindings(new StockViewModel(), $('#StocksGroup')[0]);
});