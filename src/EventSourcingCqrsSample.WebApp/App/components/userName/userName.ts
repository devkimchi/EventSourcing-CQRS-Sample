/// <reference path="../../../Scripts/typings/angularjs/angular.d.ts" />
/// <reference path="../../factories/usernameFactory.ts" />

"use strict";

module app.angular.Directives {
    import UsernameDataModel = angular.Models.UsernameDataModel;
    import UsernameChangeRequestModel = angular.Models.UsernameChangeRequestModel;

    export interface IUserNameScope extends ng.IScope {
        model: angular.Models.UsernameDataModel;
        change: Function;
    }

    export class UserName implements ng.IDirective {
        replace = true;
        restrict = "EA";
        scope = {};
        templateUrl = "/App/components/userName/userName.html";

        link($scope: IUserNameScope, element: JQuery, attributes: ng.IAttributes) {
            var $select = element.find("input");
            $select.on("change", () => {
                var streamId = element.data("stream-id");
                var value = $scope.model.value;
                $scope.change($select.attr("id"), $select.attr("name"), value, streamId);
            });
        }

        controller($scope: IUserNameScope, usernameFactory: angular.Factories.UsernameFactory, materialViewFactory: angular.Factories.MaterialViewFactory) {
            $scope.model = new UsernameDataModel();

            $scope.change = (id, name, value, streamId) => {
                var request = new UsernameChangeRequestModel(id, name, value, streamId);

                usernameFactory.postUsernameChange(request)
                    .success((response: angular.Models.UsernameChangeResponseModel) => {
                        materialViewFactory.setUsername(response.data.value);
                        console.log(response);
                    })
                    .error((response: angular.Models.UsernameChangeResponseModel) => {
                        console.log(response);
                    });
            }
        }
    }
}

angular.module("app")
    .directive("userName", () => new app.angular.Directives.UserName());

