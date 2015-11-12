/// <reference path="../../../Scripts/typings/angularjs/angular.d.ts" />
/// <reference path="../../factories/replayViewFactory.ts" />

"use strict";

module app.angular.Directives {
    export interface IUserReplayedScope extends ng.IScope {
        model: angular.Models.ReplayViewModel;
    }

    export class UserReplayed implements ng.IDirective {
        replace = true;
        restrict = "EA";
        scope = {};
        templateUrl = "/App/components/userReplayed/userReplayed.html";

        controller($scope: IUserReplayedScope, replayViewFactory: angular.Factories.ReplayViewFactory) {
            $scope.model = replayViewFactory.getReplayedView();
        }
    }
}

angular.module("app")
    .directive("userReplayed", () => new app.angular.Directives.UserReplayed());

