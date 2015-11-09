/// <reference path="../../../Scripts/typings/angularjs/angular.d.ts" />
/// <reference path="../../factories/storageViewFactory.ts" />

"use strict";

module app.angular.Directives {
    export interface IUserRegisteredScope extends ng.IScope {
        model: angular.Models.StorageViewModel;
    }

    export class UserRegistered implements ng.IDirective {
        replace = true;
        restrict = "EA";
        scope = {};
        templateUrl = "/App/components/userRegistered/userRegistered.html";

        controller($scope: IUserRegisteredScope, storageViewFactory: angular.Factories.StorageViewFactory) {
            $scope.model = storageViewFactory.geStorageView();
        }
    }
}

angular.module("app")
    .directive("userRegistered", () => new app.angular.Directives.UserRegistered());

