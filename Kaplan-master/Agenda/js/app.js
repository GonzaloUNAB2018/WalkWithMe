var app = angular.module('app',
         ['ngRoute',
          'angularModalService',
          'moment-picker',
          'ui-notification',
         'angularUtils.directives.dirPagination']
          );

app.config(function (NotificationProvider) {
    NotificationProvider.setOptions({
        delay: 3000,
        startTop: 55,
        startRight: 10,
        verticalSpacing: 20,
        horizontalSpacing: 20,
        positionX: 'center',
        positionY: 'top'
    });

});