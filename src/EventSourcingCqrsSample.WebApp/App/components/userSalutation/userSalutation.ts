/// <reference path="../../../Scripts/typings/angularjs/angular.d.ts" />
/// <reference path="../../factories/salutationsFactory.ts" />

"use strict";

module app.angular.Directives {
    import SalutationCollectionDataModel = angular.Models.SalutationCollectionDataModel;

    export interface IUserSalutationScope extends ng.IScope {
        model: angular.Models.SalutationCollectionDataModel;
        change: Function;
    }

    export class UserSalutation implements ng.IDirective {
        replace = true;
        restrict = "EA";
        scope = {};
        templateUrl = "/App/components/userSalutation/userSalutation.html";

        controller($scope: IUserSalutationScope, salutationsFactory: angular.Factories.SalutationsFactory) {
            $scope.model = new SalutationCollectionDataModel();

            salutationsFactory.getSalutations()
                .success((response: angular.Models.SalutationResoponseModel) => {
                    $scope.model.id = "salutation";
                    $scope.model.name = "salutation";
                    $scope.model.salutations = response.data;
                    console.log($scope.model);
                });

            $scope.change = $event => {
                var streamId = $(`#${$scope.model.id}`).parent().data("stream-id");
                var value = $scope.model.value;
                console.log(streamId + "::::::" + value);
                
            }
        }
    }
}

angular.module("app")
    .directive("userSalutation", () => new app.angular.Directives.UserSalutation());

