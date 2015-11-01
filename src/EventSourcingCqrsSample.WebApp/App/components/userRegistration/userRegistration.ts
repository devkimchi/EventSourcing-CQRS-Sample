/// <reference path="../../../Scripts/typings/angularjs/angular.d.ts" />
/// <reference path="../../models/registrationModel.ts" />
/// <reference path="../../factories/salutationsFactory.ts" />

"use strict";

module app.angular.Directives {
    import RegistrationModel = angular.Models.RegistrationModel;

    export interface IMainContentScope extends ng.IScope {
        model: angular.Models.RegistrationModel;
    }

    export class UserRegistration implements ng.IDirective {
        replace = true;
        restrict = "EA";
        scope = {};
        templateUrl = "/App/components/userRegistration/userRegistration.html";

        controller($scope: IMainContentScope, salutationsFactory: angular.Factories.SalutationsFactory) {
            $scope.model = new RegistrationModel();

            salutationsFactory.getResponse()
                .success((salutations: Array<angular.Models.Salutation>) => {
                    $scope.model.salutations = salutations;
                    console.log($scope.model);
                });
        }
    }
}

angular.module("app")
    .directive("userRegistration", () => new app.angular.Directives.UserRegistration());

