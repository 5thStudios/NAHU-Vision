angular.module("umbraco.resources")
    .factory("testResource", function ($http) {
        return {
            //methods to return when calling this.
            getById: function (id) {
                return $http.get("backoffice/RelationalData/TestApi/GetById?id=" + id);
            },
            save: function (test) {
                return $http.post("backoffice/RelationalData/TestApi/PostSave", angular.toJson(test));
            },
            deleteById: function (id) {
                return $http.delete("backoffice/RelationalData/TestApi/DeleteById?id=" + id);
            }
        }
    });