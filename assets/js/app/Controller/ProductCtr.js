
myApp.controller('productDetailController', ['$scope', '$http', '$cookies', function ($scope, $http, $cookies, $location, $window) {
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
    const params = new Proxy(new URLSearchParams(window.location.search), {
        get: (searchParams, prop) => searchParams.get(prop),
    });
    var productID = params.name;
    $http.post('/Products/ProductDetails', { productID: productID }).then(function (response) {
        $scope.productDetail = response.data;
        $scope.productPageDetail = { Title: $scope.productDetail[0].Title, Rating: "5", Price: $scope.productDetail[0].Price, Image: $scope.productDetail[0].Image };

    });
    $scope.Products = [];
    $http.get('/Products/GetProduct').then(function (result) {
        $scope.Products = result.data;

        //$scope.Product = [{ Title: $scope.dataList[0].Title, Rating: "5", Price: "$" + $scope.dataList[0].Price, Image: $scope.dataList[0].Image }];
    });
}]);


myApp.controller('addToCartController', ['$scope', '$http', '$cookies', function ($scope, $http, $cookies) {
    var addToCartId = $cookies.get('AddToCart');
   
  
    var arrayaddtocart = addToCartId.split(",");
    const addtocartallid = [];
    arrayaddtocart.forEach(str => {
        addtocartallid.push(Number(str));
    });

    if (typeof (addToCartId) != "undefined") {
        //angular.forEach(addtocartallid, function (value) {
        //    if (value.isSelected) {
        //        selectedHobbies.push(value.hobbyname);
        //    }
        //});
        $scope.addToCartData = [];
        for (let i = 0; i < addtocartallid.length; i++) {
            var pid = addtocartallid[i];
            $http.post('/Products/ProductDetails', { productID: pid }).then(function (response) {
                $scope.addToCartData.push(response.data);
               // $scope.productPageDetail = { Title: $scope.productDetail[0].Title, Rating: "5", Price: $scope.productDetail[0].Price, Image: $scope.productDetail[0].Image };
            });
        }
        //$http.post('/Products/ProductDetails', { productID: addToCartId }).then(function (response) {
        //    $scope.productDetail = response.data;
        //    $scope.productPageDetail = { Title: $scope.productDetail[0].Title, Rating: "5", Price: $scope.productDetail[0].Price, Image: $scope.productDetail[0].Image };

        //});
    }
  

}]);