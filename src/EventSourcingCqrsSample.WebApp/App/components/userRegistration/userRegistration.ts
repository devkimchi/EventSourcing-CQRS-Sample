/// <reference path="../../../Scripts/typings/angularjs/angular.d.ts" />
/// <reference path="../../models/eventStreamModel.ts" />
/// <reference path="../../models/userRegistrationModel.ts" />
/// <reference path="../../factories/eventStreamFactory.ts" />
/// <reference path="../../factories/materialViewFactory.ts" />

"use strict";

module app.angular.Directives {
    import EventStreamDataModel = angular.Models.EventStreamDataModel;
    import UserRegistrationRequestModel = angular.Models.UserRegistrationRequestModel;

    export interface IUserRegistrationScope extends ng.IScope {
        model: angular.Models.EventStreamDataModel;
        click: Function;
    }

    export class UserRegistration implements ng.IDirective {
        replace = true;
        restrict = "EA";
        scope = {};
        templateUrl = "/App/components/userRegistration/userRegistration.html";

        link($scope: IUserRegistrationScope, element: JQuery, attributes: ng.IAttributes) {
            var $submit = element.find("input#submit");
            $submit.on("click", () => {
                var streamId = element.data("stream-id");
                $scope.click(streamId);
            });
        }

        controller($scope: IUserRegistrationScope, eventStreamFactory: angular.Factories.EventStreamFactory, materialViewFactory: angular.Factories.MaterialViewFactory) {
            $scope.model = new EventStreamDataModel();

            eventStreamFactory.getEventStream()
                .success((response: angular.Models.EventStreamResponseModel) => {
                    $scope.model.streamId = response.data.streamId;
                    console.log($scope.model);
                });

            $scope.click = (streamId) => {
                var request = new UserRegistrationRequestModel(streamId);

                eventStreamFactory.registerUser(request)
                    .success((response: angular.Models.UserRegistrationResponseModel) => {
                        materialViewFactory.setMaterialisedView(response.data.title, response.data.username, response.data.email);
                        console.log(response);
                    });
            }
        }
    }
}

angular.module("app")
    .directive("userRegistration", () => new app.angular.Directives.UserRegistration());

