/// <reference path="../../Scripts/typings/angularjs/angular.d.ts" />
/// <reference path="../models/materialViewModel.ts" />

"use strict";

module app.angular.Factories {
    import MaterialViewModel = angular.Models.MaterialViewModel;

    export class MaterialViewFactory {
        constructor(private $http: ng.IHttpService) {
            this.model = new MaterialViewModel();
        }

        model: angular.Models.MaterialViewModel;

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

        getMaterialisedView(): angular.Models.MaterialViewModel {
            return this.model;
        }
    }
}

angular.module("app")
    .factory("materialViewFactory", [
        "$http",
        ($http) => new app.angular.Factories.MaterialViewFactory($http)
    ]);
