/// <reference path="../../Scripts/typings/angularjs/angular.d.ts" />
/// <reference path="./errorModel.ts" />

"use strict";

module app.angular.Models {
    export class UsernameDataModel {
        value: string;
    }

    export class UsernameChangeRequestModel {
        constructor(id: string = null, name: string = null, value: string = null, streamId: string = null) {
            this.id = id;
            this.name = name;
            this.value = value;
            this.streamId = streamId;
        }

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