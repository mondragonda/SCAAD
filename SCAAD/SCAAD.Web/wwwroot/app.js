!function(){"use strict";function a(a,b,c,d,e,f){f.theme("default").primaryPalette("teal").accentPalette("pink").warnPalette("red").backgroundPalette("grey"),d.setBaseUrl(e.apiUrl),c.withCredentials=!1,c.storageType="localStorage",c.tokenName="access_token",c.baseUrl=e.apiUrl,c.loginUrl="/oauth/token",b.otherwise("/dashboard"),a.state("login",{url:"/",templateUrl:"views/login.html",controller:"loginController"}).state("app",{url:"/app","abstract":!0,templateUrl:"views/app.html",resolve:{}}).state("app.dashboard",{url:"^/dashboard",templateUrl:"views/dashboard.html",controller:"dashboardController"})}angular.module("app",["ngMaterial","ui.router","satellizer","angular-loading-bar","ngAnimate","restangular","md.data.table"]).config(a),a.$inject=["$stateProvider","$urlRouterProvider","$authProvider","RestangularProvider","EnvProvider","$mdThemingProvider"]}(),function(){"use strict";function a(a,b,c){a.$state=c,a.pagina={titulo:""},a.$mdSidenav=b}angular.module("app").controller("appController",a),a.$inject=["$scope","$mdSidenav","$state"]}(),function(){"use strict";function a(a,b){a.pagina.titulo="Dashboard",a.selected=[],a.query={order:"nombre",limit:10,page:1},a.getDocentes=function(){a.promesa=b.getAll().then(function(b){a.docentes=b})},a.getDocentes()}angular.module("app").controller("dashboardController",a),a.$inject=["$scope","Docentes"]}(),function(){"use strict";function a(a,b,c,d){a.pagina.titulo="Inicio de sesion",a.login=function(a){a.grant_type="password",c.go("app.dashboard")}}angular.module("app").controller("loginController",a),a.$inject=["$scope","$auth","$state","Restangular"]}(),function(){"use strict";function a(a,b){function c(){var c=a.defer();return b.all("api/Docentes").getList().then(function(a){c.resolve(a)})["catch"](function(a){c.reject(a)}),c.promise}var d={getAll:c};return d}angular.module("app").factory("Docentes",a),a.$inject=["$q","Restangular"]}();