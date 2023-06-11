var ProductViewModel = function () {
    var self = this;

    //base url
    var base_url = '/product';

    //Products
    self.Products = ko.observableArray([]);
    self.Product = ko.observable({ id: 0, name: '', weight: 0.0 });
    loadProducts();

    //functions for Products
    function loadProducts() {
        $.get(`${base_url}/Read`, function (data, status)
            {
                if (status != 'success') {
                    alert("error");
                    return;
                }
                self.Products(data)
            })            
            .fail(function () {
                alert("error");
            }
        );
    }

    self.deleteProducts = function (id) {
        $.ajax({
            url: `${base_url}/Delete`,
            type: "DELETE",
            data: {
                "key": id
            },
            success: function () {
                self.Products.remove(
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

    self.updateProducts = function (id) {        
        var match = ko.utils.arrayFirst(self.Products(), function (item) {
            return item.id == id;
        });        
        $.ajax({
            url: `${base_url}/Update`,
            type: 'PUT',
            data: {
                "obj": JSON.stringify(match)
            },
            error: function () {
                alert("error");
            }
        });
    }

    self.addProducts = function () {
        $.post(`${base_url}/Create`,
            {
                obj: JSON.stringify(self.Product())
            },
            function (data, status) {
                if (status != "success") {
                    alert("error");
                    return;
                }
                self.Products.push(data);
                self.Product({ id: 0, name: '', weight: 0.0 });
            }, "json")
            .fail(function () {
                alert("error");
            });
    }
} // ProductViewModel
$(function () {
    ko.applyBindings(new ProductViewModel(), $('#ProductsGroup')[0]);
});