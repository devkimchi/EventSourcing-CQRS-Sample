/// <reference path="../../../Scripts/typings/angularjs/angular.d.ts" />
/// <reference path="../../factories/salutationsFactory.ts" />
/// <reference path="../../factories/replayViewFactory.ts" />

"use strict";

module app.angular.Directives {
    import SalutationCollectionDataModel = angular.Models.SalutationCollectionDataModel;
    import SalutationChangeRequestModel = angular.Models.SalutationChangeRequestModel;

    export interface IUserSalutationScope extends ng.IScope {
        model: angular.Models.SalutationCollectionDataModel;
        change: Function;
    }

    export class UserSalutation implements ng.IDirective {
        replace = true;
        restrict = "EA";
        scope = {};
        templateUrl = "/App/components/userSalutation/userSalutation.html";

        link($scope: IUserSalutationScope, element: JQuery, attributes: ng.IAttributes) {
            var $select = element.find("select");
            $select.on("change", () => {
                var streamId = element.data("stream-id");
                var value = $scope.model.value;
                $scope.change($select.attr("id"), $select.attr("name"), value, streamId);
            });
        }

        controller($scope: IUserSalutationScope, salutationsFactory: angular.Factories.SalutationsFactory, replayViewFactory: angular.Factories.ReplayViewFactory) {
            $scope.model = new SalutationCollectionDataModel();

            salutationsFactory.getSalutations()
                .success((response: angular.Models.SalutationResoponseModel) => {
                    $scope.model.salutations = response.data;
                    console.log($scope.model);
                });

            $scope.change = (id, name, value, streamId) => {
                var request = new SalutationChangeRequestModel(id, name, value, streamId);

                salutationsFactory.postSalutationChange(request)
                    .success((response: angular.Models.SalutationChangeResponseModel) => {
                        replayViewFactory.setSalutation(response.data.value);
                        console.log(response);
                    })
                    .error((response: angular.Models.SalutationChangeResponseModel) => {
                        console.log(response);
                    });
            }
        }
    }
}

angular.module("app")
    .directive("userSalutation", () => new app.angular.Directives.UserSalutation());

