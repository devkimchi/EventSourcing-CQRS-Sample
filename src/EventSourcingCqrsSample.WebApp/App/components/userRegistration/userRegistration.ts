/// <reference path="../../../Scripts/typings/angularjs/angular.d.ts" />
/// <reference path="../../models/eventStreamModel.ts" />
/// <reference path="../../factories/eventStreamFactory.ts" />

"use strict";

module app.angular.Directives {
    import EventStreamDataModel = angular.Models.EventStreamDataModel;

    export interface IMainContentScope extends ng.IScope {
        model: angular.Models.EventStreamDataModel;
    }

    export class UserRegistration implements ng.IDirective {
        replace = true;
        restrict = "EA";
        scope = {};
        templateUrl = "/App/components/userRegistration/userRegistration.html";

        controller($scope: IMainContentScope, eventStreamFactory: angular.Factories.EventStreamFactory) {
            $scope.model = new EventStreamDataModel();

            eventStreamFactory.getResponse()
                .success((eventStream: angular.Models.EventStreamResponseModel) => {
                    $scope.model.streamId = eventStream.data.streamId;
                    console.log($scope.model);
                });
        }
    }
}

angular.module("app")
    .directive("userRegistration", () => new app.angular.Directives.UserRegistration());

