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
var router_1 = require("@angular/router");
var index_1 = require("./shared/index");
var EventsListComponent = (function () {
    function EventsListComponent(eventService, route) {
        this.eventService = eventService;
        this.route = route;
    }
    EventsListComponent.prototype.ngOnInit = function () {
        // this.eventService.getEvents().subscribe(data => this.events = data)
        // this.events = this.eventService.getEvents()
        this.events = this.route.snapshot.data['events'];
    };
    return EventsListComponent;
}());
EventsListComponent = __decorate([
    core_1.Component({
        selector: 'events-list',
        template: "\n            <div>\n                <h1>Upcoming Angular 2 Events</h1>\n                <hr />\n                <div class=\"row\">\n                    <div class=\"col-md-5\" *ngFor=\"let event of events\">\n                        <event-thumbnail [event]=\"event\" #thumb></event-thumbnail>\n                    </div>\n                </div>\n            </div>\n"
    }),
    __metadata("design:paramtypes", [index_1.EventService,
        router_1.ActivatedRoute])
], EventsListComponent);
exports.EventsListComponent = EventsListComponent;
//# sourceMappingURL=events-list.component.js.map