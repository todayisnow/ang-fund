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
var core_1 = require("@angular/core");
var platform_browser_1 = require("@angular/platform-browser");
var forms_1 = require("@angular/forms"); //validation ,form, two way binding
var router_1 = require("@angular/router");
var http_1 = require("@angular/http");
var events_app_component_1 = require("./events-app.component");
var index_1 = require("./events/index");
var nav_bar_component_1 = require("./nav/nav-bar.component");
var _404_component_1 = require("./error/404.component");
var index_2 = require("./common/index");
var auth_service_1 = require("./user/auth.service");
var routes_1 = require("./routes");
var AppModule = (function () {
    function AppModule() {
    }
    return AppModule;
}());
AppModule = __decorate([
    core_1.NgModule({
        imports: [
            platform_browser_1.BrowserModule,
            forms_1.FormsModule,
            forms_1.ReactiveFormsModule,
            router_1.RouterModule.forRoot(routes_1.appRoutes),
            http_1.HttpModule
        ],
        declarations: [
            events_app_component_1.EventsAppComponent,
            index_1.EventsListComponent,
            index_1.EventThumbnailComponent,
            nav_bar_component_1.NavBarComponent,
            index_1.CreateSessionComponent,
            index_1.SessionListComponent,
            index_1.EventDetailsComponent,
            index_1.CreateEventComponent,
            _404_component_1.Error404Component,
            index_2.CollapsibleWellComponent,
            index_1.DurationPipe,
            index_2.ModalTriggerDirective,
            index_2.SimpleModalComponent,
            index_1.UpVoteComponent,
            index_1.LocationValidator
        ],
        providers: [
            index_1.EventService,
            {
                provide: index_2.TOASTR_TOCKEN,
                useValue: toastr
            },
            index_1.EventRouteActivator,
            {
                provide: 'CanDeactivateCreateEvent',
                useValue: chechDirtyState
            },
            {
                provide: index_2.JQ_TOCKEN,
                useValue: jQuery
            },
            index_1.EventListResolver,
            index_1.EventResolver,
            auth_service_1.AuthService,
            index_1.VoterService
        ],
        bootstrap: [events_app_component_1.EventsAppComponent]
    }),
    __metadata("design:paramtypes", [])
], AppModule);
exports.AppModule = AppModule;
function chechDirtyState(component) {
    if (component.isDirty)
        return window.confirm('You have not saved this event, do you really want to cancel?');
    else
        return true;
}
//# sourceMappingURL=app.module.js.map