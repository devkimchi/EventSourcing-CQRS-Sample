/// <reference path="../../../Scripts/typings/angularjs/angular.d.ts" />
/// <reference path="../../factories/emailFactory.ts" />
/// <reference path="../../factories/replayViewFactory.ts" />

"use strict";

module app.angular.Directives {
    import EmailDataModel = angular.Models.EmailDataModel;
    import EmailChangeRequestModel = angular.Models.EmailChangeRequestModel;

    export interface IUserEmailScope extends ng.IScope {
        model: angular.Models.EmailDataModel;
        change: Function;
    }

    export class UserEmail implements ng.IDirective {
        replace = true;
        restrict = "EA";
        scope = {};
        templateUrl = "/App/components/userEmail/userEmail.html";

        link($scope: IUserEmailScope, element: JQuery, attributes: ng.IAttributes) {
            var $select = element.find("input");
            $select.on("change", () => {
                var streamId = element.data("stream-id");
                var value = $scope.model.value;
                $scope.change($select.attr("id"), $select.attr("name"), value, streamId);
            });
        }

        controller($scope: IUserEmailScope, emailFactory: angular.Factories.EmailFactory, replayViewFactory: angular.Factories.ReplayViewFactory) {
            $scope.model = new EmailDataModel();

            $scope.change = (id, name, value, streamId) => {
                var request = new EmailChangeRequestModel(id, name, value, streamId);

                emailFactory.postEmailChange(request)
                    .success((response: angular.Models.EmailChangeResponseModel) => {
                        replayViewFactory.setEmail(response.data.value);
                        console.log(response);
                    })
                    .error((response: angular.Models.EmailChangeResponseModel) => {
                        console.log(response);
                    });
            }
        }
    }
}

angular.module("app")
    .directive("userEmail", () => new app.angular.Directives.UserEmail());

