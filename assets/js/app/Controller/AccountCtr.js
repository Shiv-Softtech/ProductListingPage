myApp.controller('registerController', ['$scope', '$http', '$cookies', function ($scope, $http,$cookies) {

    $scope.hobbylist = [{ hobbyname: "chess", isSelected:false },
    { hobbyname: "cricket", isSelected:false },
    { hobbyname: "Badminton", isSelected:false },
    { hobbyname: "Football", isSelected:false }];

    $scope.validation = function () {
      
       // hobbies validation
        var selectedHobbies = [];
        angular.forEach($scope.hobbylist, function (value) {
            if (value.isSelected) {
                selectedHobbies.push(value.hobbyname);
            }
        });
        
        if (selectedHobbies.length < 2) {
            return $scope.hobbyerr = '*Please choose two hobbies';
        }
       // breack hobbies into ""a","b","c"" to "a,b,c," 
        var selectHobbies = selectedHobbies.join(",");
       
        //password and confirm pass check
        if ($scope.user.password == $scope.user.confirmpassword)
        {
            $scope.err ="";
        } else
        {
            return $scope.err ="*password not matched";
        }
        if (typeof ($scope.user.password) != "undefined" && typeof ($scope.user.name) != "undefined" && typeof ($scope.user.email) != "undefined" && typeof ($scope.user.mobilenumber) != "undefined" && selectHobbies != "" && typeof ($scope.user.department) != "undefined" && typeof ($scope.user.gender) != "undefined" ) {
          
                //new register json file
                var user = { "Name": $scope.user.name, "Email": $scope.user.email, "Mobile": $scope.user.mobilenumber, "Gender": $scope.user.gender, "Department": $scope.user.department, "Hobbies": selectHobbies, "password": $scope.user.password };
              
            $http.post('/Account/InsertUser', { UserData: user }).then(function (response) {
                if (response.data) {
                    alert("Email is already registered plz! SignIn");
                    return false;
                } else {
                    window.location.href = "/Account/Login";
                }
            });
 
        } else {
            //return alert("Enter invalid fields");
            return false;
           
        }
        return false;
    }
  
   
    $scope.checkhobby = function () {
        var selectedHobbies = [];
        angular.forEach($scope.hobbylist, function (value) {
            if (value.isSelected) {
                selectedHobbies.push(value.hobbyname);
            }
        });
        if (selectedHobbies.length < 2) {
            return $scope.hobbyerr = '*Please choose two hobbies';

        }
        else {
            return $scope.hobbyerr = '';
        }
     }
   
   
}]);

myApp.controller('loginController', ['$scope','$http', '$cookies', function ($scope,$http, $cookies) {
    $scope.rememberme = false
    var loginDetail = $cookies.get('loginDetails');
    if (typeof (loginDetail) != "undefined") {
        var loginData = JSON.parse(loginDetail);
        $scope.email = loginData.Email;
        $scope.password = loginData.Password;
        //alert("hello product" + $scope.name);
    }
    // function to submit the form after all validation has occurred 
    $scope.submitloginForm = function () {
        // Set the 'submitted' flag to true
        $scope.submitted = true;
        if ($scope.loginForm.$valid) {
            var ismatched = false;
            var userLogin = { "Email": $scope.email, "password": $scope.password };
            $http.post('/Account/LoginAuth', { LoginData: userLogin }).then(function (response) {
               // $scope.Products = response.data;
                if (response.data.length > 0) {
                    ismatched = true;
                    if ($scope.rememberme) {
                        var loginUser = { "Name": response.data[0].Name, "Email": response.data[0].Email, "Password": response.data[0].Password };
                        var loginDetails = JSON.stringify(loginUser);
                        $cookies.put('loginDetails', loginDetails, { path: '/' });
                        window.location.href = "/Products/Products";
                        alert("Login success");
                    } else {
                        var loginUser = { "Name": response.data[0].Name };
                        var loginDetails = JSON.stringify(loginUser);
                        $cookies.put('loginDetails', loginDetails, { path: '/' });
                        window.location.href = "/Products/Products";
                        alert("Login success");
                    }
                }
                else if (!ismatched) {
                    alert("Invalid email and password");
                    return false;
                }
            });
        }
        else {
            /* alert("Please correct errors!");*/
            return false;
        }
    }
}]);