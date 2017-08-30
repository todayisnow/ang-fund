import { Injectable } from '@angular/core';
import { Resolve } from '@angular/router';
import { EventService, IEvent } from './shared/index';

@Injectable()
export class EventListResolver implements Resolve<IEvent[]> {
    constructor(private eventService: EventService) {
    }
    resolve() {
        return this.eventService.getEvents();
    }


}