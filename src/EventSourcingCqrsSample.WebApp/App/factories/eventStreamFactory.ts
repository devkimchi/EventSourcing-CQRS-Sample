/// <reference path="../../Scripts/typings/angularjs/angular.d.ts" />
/// <reference path="../models/eventStreamModel.ts" />

"use strict";

module app.angular.Factories {
    import EventStreamResponseModel = angular.Models.EventStreamResponseModel;
    import UserRegistrationResponseModel = angular.Models.UserRegistrationResponseModel;

    export class EventStreamFactory {
        private _eventStreamUrl: string = "/api/events/stream";
        private _registrationUrl: string = "/api/events/registration";

        constructor(private $http: ng.IHttpService) {
        }

        getEventStream(): ng.IHttpPromise<EventStreamResponseModel> {
            return this.$http.get<EventStreamResponseModel>(this._eventStreamUrl);
        }

        registerUser(request: angular.Models.UserRegistrationRequestModel): ng.IHttpPromise<UserRegistrationResponseModel> {
            return this.$http.post<UserRegistrationResponseModel>(this._registrationUrl, request);
        }
    }
}

angular.module("app")
    .factory("eventStreamFactory", [
        "$http",
        ($http) => new app.angular.Factories.EventStreamFactory($http)
    ]);
