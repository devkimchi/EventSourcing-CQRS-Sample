/// <reference path="../../Scripts/typings/angularjs/angular.d.ts" />
/// <reference path="../models/replayViewModel.ts" />

"use strict";

module app.angular.Factories {
    import ReplayViewModel = angular.Models.ReplayViewModel;

    export class ReplayViewFactory {
        constructor(private $http: ng.IHttpService) {
            this.model = new ReplayViewModel();
        }

        model: angular.Models.ReplayViewModel;

        setSalutation(title: string): void {
            if (title == undefined) {
                return;
            }

            this.model.title = title;
        }

        setUsername(username: string): void {
            if (username == undefined) {
                return;
            }

            this.model.username = username;
        }

        setEmail(email: string): void {
            if (email == undefined) {
                return;
            }

            this.model.email = email;
        }

        getReplayedView(): angular.Models.ReplayViewModel {
            return this.model;
        }
    }
}

angular.module("app")
    .factory("replayViewFactory", [
        "$http",
        ($http) => new app.angular.Factories.ReplayViewFactory($http)
    ]);
