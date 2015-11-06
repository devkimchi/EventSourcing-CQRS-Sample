/// <reference path="../../Scripts/typings/angularjs/angular.d.ts" />
/// <reference path="./errorModel.ts" />

"use strict";

module app.angular.Models {
    export class EmailDataModel {
        value: string;
    }

    export class EmailChangeRequestModel {
        id: string;
        name: string;
        value: string;
        streamId: string;
    }

    export class EmailChangeResponseModel {
        data: EmailDataModel;
        error: ErrorModel;
    }
}