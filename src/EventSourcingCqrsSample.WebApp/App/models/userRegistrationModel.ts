/// <reference path="../../Scripts/typings/angularjs/angular.d.ts" />
/// <reference path="./errorModel.ts" />
"use strict";

module app.angular.Models {
    export class UserRegistrationRequestModel {
        constructor(streamId: string) {
            this.streamId = streamId;
        }

        streamId: string;
    }

    export class UserRegistrationDataModel {
        title: string;
        username: string;
        email: string;
    }

    export class UserRegistrationResponseModel {
        data: UserRegistrationDataModel;
        error: ErrorModel;
    }
}