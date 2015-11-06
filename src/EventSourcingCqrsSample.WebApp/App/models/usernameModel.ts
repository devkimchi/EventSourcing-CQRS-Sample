/// <reference path="../../Scripts/typings/angularjs/angular.d.ts" />
/// <reference path="./errorModel.ts" />

"use strict";

module app.angular.Models {
    export class UsernameDataModel {
        value: string;
    }

    export class UsernameChangeRequestModel {
        id: string;
        name: string;
        value: string;
        streamId: string;
    }

    export class UsernameChangeResponseModel {
        data: UsernameDataModel;
        error: ErrorModel;
    }
}