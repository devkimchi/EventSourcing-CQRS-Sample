/// <reference path="../../../Scripts/typings/angularjs/angular.d.ts" />
/// <reference path="../../factories/materialViewFactory.ts" />

"use strict";

module app.angular.Directives {
    export interface IUserMaterialisedScope extends ng.IScope {
        model: angular.Models.MaterialViewModel;
    }

    export class UserMaterialised implements ng.IDirective {
        replace = true;
        restrict = "EA";
        scope = {};
        templateUrl = "/App/components/userMaterialised/userMaterialised.html";

        controller($scope: IUserMaterialisedScope, materialViewFactory: angular.Factories.MaterialViewFactory) {
            $scope.model = materialViewFactory.getMaterialisedView();
        }
    }
}

angular.module("app")
    .directive("userMaterialised", () => new app.angular.Directives.UserMaterialised());

