/// <reference path="../../Scripts/typings/angularjs/angular.d.ts" />

"use strict";

module app.angular.Factories {
    export class SalutationsFactory {
        private _baseUrl: string = "/api/salutations";

        constructor(private $http: ng.IHttpService) {
        }

        getResponse(): ng.IHttpPromise<Array<angular.Models.Salutation>> {
            return this.$http.get<Array<angular.Models.Salutation>>(this._baseUrl);
        }
    }
}

angular.module("app")
    .factory("salutationsFactory", [
        "$http",
        ($http) => new app.angular.Factories.SalutationsFactory($http)
    ]);
