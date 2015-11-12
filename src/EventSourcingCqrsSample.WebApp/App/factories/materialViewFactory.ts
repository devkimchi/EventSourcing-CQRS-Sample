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

        setMaterialisedView(title: string, username: string, email: string): void {
            this.model.title = title;
            this.model.username = username;
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
