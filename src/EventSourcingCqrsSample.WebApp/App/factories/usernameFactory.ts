/// <reference path="../../Scripts/typings/angularjs/angular.d.ts" />
/// <reference path="../models/usernameModel.ts"/>

"use strict";

module app.angular.Factories {
    export class UsernameFactory {
        private _postUsernameUrl: string = "/api/events/username-changed";

        constructor(private $http: ng.IHttpService) {
        }

        postUsernameChange(request: angular.Models.UsernameChangeRequestModel): ng.IHttpPromise<angular.Models.UsernameChangeResponseModel> {
            return this.$http.post<angular.Models.UsernameChangeResponseModel>(this._postUsernameUrl, request);
        }
    }
}

angular.module("app")
    .factory("usernameFactory", [
        "$http",
        ($http) => new app.angular.Factories.UsernameFactory($http)
    ]);
