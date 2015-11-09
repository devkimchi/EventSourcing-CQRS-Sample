/// <reference path="../../Scripts/typings/angularjs/angular.d.ts" />
/// <reference path="../models/userRegistrationModel.ts" />

"use strict";

module app.angular.Factories {
    import StorageViewModel = angular.Models.StorageViewModel;

    export class StorageViewFactory {
        constructor(private $http: ng.IHttpService) {
            this.model = new StorageViewModel();
        }

        model: angular.Models.StorageViewModel;

        setStorageView(title: string, username: string, email: string): void {
            this.model.title = title;
            this.model.username = username;
            this.model.email = email;
        }

        geStorageView(): angular.Models.StorageViewModel {
            return this.model;
        }
    }
}

angular.module("app")
    .factory("storageViewFactory", [
        "$http",
        ($http) => new app.angular.Factories.StorageViewFactory($http)
    ]);
