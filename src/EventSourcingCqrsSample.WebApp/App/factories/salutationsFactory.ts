/// <reference path="../../Scripts/typings/angularjs/angular.d.ts" />
/// <reference path="../models/salutationModel.ts" />

"use strict";

module app.angular.Factories {
    export class SalutationsFactory {
        private _getSalutationsUrl: string = "/api/salutations";
        private _postSalutationUrl: string = "/api/events/salutation-changed";

        constructor(private $http: ng.IHttpService) {
        }

        getSalutations(): ng.IHttpPromise<angular.Models.SalutationResoponseModel> {
            return this.$http.get<angular.Models.SalutationResoponseModel>(this._getSalutationsUrl);
        }

        postSalutationChange(request: angular.Models.SalutationChangeRequestModel): ng.IHttpPromise<angular.Models.SalutationChangeResponseModel> {
            return this.$http.post<angular.Models.SalutationChangeResponseModel>(this._postSalutationUrl, request);
        }
    }
}

angular.module("app")
    .factory("salutationsFactory", [
        "$http",
        ($http) => new app.angular.Factories.SalutationsFactory($http)
    ]);
