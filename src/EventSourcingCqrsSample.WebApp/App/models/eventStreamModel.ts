/// <reference path="../../Scripts/typings/angularjs/angular.d.ts" />
/// <reference path="./errorModel.ts" />

"use strict";

module app.angular.Models {
    export class EventStreamDataModel {
        streamId: string;
    }

    export class EventStreamResponseModel {
        data: EventStreamDataModel;
        error: ErrorModel;
    }
}