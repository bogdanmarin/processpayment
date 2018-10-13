angular.module('paymentApp', [])
  .controller('PaymentsController', function($scope, $http) {

      var form = this;
      form.isValid = null;

      form.check = function () {
           var payment = form.payment;
            form.checking = true;
            form.isValid = false;
            $http.post('/api/payments', payment).then(function success(isValid){
                form.checking = false;
                form.errors = [];
                form.isValid = isValid.data;
            }, function failed(errors){
                form.checking = false;
                form.errors = [];
                form.isValid = null;
                errors = errors.data;
                for (var key in errors){
                    if (errors.hasOwnProperty(key)){
                         form.errors = form.errors.concat(errors[key]);
                    }
                };
            })
      };
     
  });