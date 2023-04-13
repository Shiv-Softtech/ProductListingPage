myApp.controller('productController', ['$scope', '$http', '$cookies', function ($scope, $http,$cookies, $location, $window) {

    var loginDetail = $cookies.get('loginDetails');
    if (typeof (loginDetail) != "undefined") {
        var loginData = JSON.parse(loginDetail);
        $scope.name = "Hi " + loginData.Name;
        $scope.Logout = "Logout";
        $scope.hide = "hide";
        //alert("hello product" + $scope.name);
    }
    //logout function
    $scope.logoutUser = function () {
        $cookies.remove("loginDetails", { path: "/" });
        $scope.hide = "";
        $scope.Logout = "";
        $scope.name = "";
    }
    $scope.Products = [];
    $http.get('/Products/GetProduct').then(function (result) {
        $scope.Products = result.data;

        //$scope.Product = [{ Title: $scope.dataList[0].Title, Rating: "5", Price: "$" + $scope.dataList[0].Price, Image: $scope.dataList[0].Image }];
    });
    $scope.ProductCategory = [];
   
    $http.get('/Products/GetProductFilter').then(function (result) {
        $scope.ProductCategory = result.data;
    });
 
    $scope.lowTohigh = function () {
        var featureValue = $scope.features.select;
        if (featureValue != "") {
            $http.post('/Products/GetLowHighPrice', { FeatureValue: featureValue }).then(function (response) {
                $scope.Products = response.data;
            });
        }
    }
   // $scope.productPageDetail;
    $scope.productDeatil = function (div) {
        var productID = div.Product.Id;
        window.location.href = "/Products/ProductDetails?name=" + productID;
    }
   var addtocart = [];
    $scope.AddToCart = function (ProductId) {
        addtocart.push(ProductId);
        $cookies.put('AddToCart', addtocart.join(","), { path: '/' });
       // window.location.href = "/Products/ProductDetails?name=" + productID;
    }


}]);