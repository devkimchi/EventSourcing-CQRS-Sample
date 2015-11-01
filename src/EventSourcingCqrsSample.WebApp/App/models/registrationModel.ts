/// <reference path="../../Scripts/typings/angularjs/angular.d.ts" />

"use strict";

module app.angular.Models {
    export class Salutation {
        text: string;
        value: string;
    }

    export class RegistrationModel {
        salutations: Array<Salutation>;
    }
}