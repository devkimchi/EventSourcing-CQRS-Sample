/// <reference path="../../Scripts/typings/angularjs/angular.d.ts" />
/// <reference path="./errorModel.ts" />

"use strict";

module app.angular.Models {
    export class SalutationDataModel {
        text: string;
        value: string;
    }

    export class SalutationCollectionDataModel {
        value: string;
        salutations: Array<SalutationDataModel>;
    }

    export class SalutationResoponseModel {
        data: Array<SalutationDataModel>;
    }

    export class SalutationChangeRequestModel {
        id: string;
        name: string;
        value: string;
        streamId: string;
    }

    export class SalutationChangeResponseModel {
        data: SalutationDataModel;
        error: ErrorModel;
    }
}