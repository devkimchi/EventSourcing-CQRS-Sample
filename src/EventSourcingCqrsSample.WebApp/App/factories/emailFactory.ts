/// <reference path="../../Scripts/typings/angularjs/angular.d.ts" />
/// <reference path="../models/emailModel.ts"/>

"use strict";

module app.angular.Factories {
    export class EmailFactory {
        private _posteEmailUrl: string = "/api/events/email-changed";

        constructor(private $http: ng.IHttpService) {
        }

        postEmailChange(request: angular.Models.EmailChangeRequestModel): ng.IHttpPromise<angular.Models.EmailChangeResponseModel> {
            return this.$http.post<angular.Models.EmailChangeResponseModel>(this._posteEmailUrl, request);
        }
    }
}

angular.module("app")
    .factory("emailFactory", [
        "$http",
        ($http) => new app.angular.Factories.EmailFactory($http)
    ]);
