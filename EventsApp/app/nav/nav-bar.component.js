"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var auth_service_1 = require("../user/auth.service");
var index_1 = require("../events/index");
var NavBarComponent = (function () {
    function NavBarComponent(auth, eventService) {
        this.auth = auth;
        this.eventService = eventService;
        this.searchTerm = '';
        this.foundSession = [];
    }
    NavBarComponent.prototype.searchSessions = function (searchTerm) {
        var _this = this;
        this.eventService.searchSessions(searchTerm).subscribe(function (sessions) {
            _this.foundSession = sessions;
        });
    };
    NavBarComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.eventService.eventsChanges.subscribe(function (events) { return _this.events = events; });
    };
    return NavBarComponent;
}());
NavBarComponent = __decorate([
    core_1.Component({
        selector: 'nav-bar',
        moduleId: './app/nav/',
        templateUrl: './nav-bar.component.html',
        styles: ["\n     li > a.active {color: #F97924}\n    .nav.navbar-nav {font-size: 15px;}\n    #searchForm {margin-right: 100ppx;}\n    @media (max-width: 1200px) {#searchForm {display:none}}\n"]
    }),
    __metadata("design:paramtypes", [auth_service_1.AuthService, index_1.EventService])
], NavBarComponent);
exports.NavBarComponent = NavBarComponent;
//# sourceMappingURL=nav-bar.component.js.map