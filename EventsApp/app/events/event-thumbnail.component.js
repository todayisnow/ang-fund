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
var EventThumbnailComponent = (function () {
    function EventThumbnailComponent() {
    }
    return EventThumbnailComponent;
}());
__decorate([
    core_1.Input(),
    __metadata("design:type", Object)
], EventThumbnailComponent.prototype, "event", void 0);
EventThumbnailComponent = __decorate([
    core_1.Component({
        selector: "event-thumbnail",
        styles: ["\n.pad-left {margin-left: 10px;}\n.well div {color: #bbb;}\n"],
        template: "\n   <div class=\"well hoverwell thumbnail\">\n        <h2>{{event.name}}</h2>\n        <div>Date: {{event.date}}</div>\n        <div>Time {{event.time}}</div>\n        <div>Price: ${{ event.price }}</div>\n        <div>\n            <span>Location: {{event.location.address}}</span>\n            \n            <span class =\"pad-left\">{{event.location.city}}, {{event.location.country}}</span>\n        </div>\n    </div>\n"
    }),
    __metadata("design:paramtypes", [])
], EventThumbnailComponent);
exports.EventThumbnailComponent = EventThumbnailComponent;
//# sourceMappingURL=event-thumbnail.component.js.map