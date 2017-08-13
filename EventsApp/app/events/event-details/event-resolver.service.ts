import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot, Router } from '@angular/router';
import { EventService, IEvent } from '../shared/index';

@Injectable()
export class EventResolver implements Resolve<IEvent> {
    constructor(private eventService: EventService, private router:Router) {
    }
    resolve(route: ActivatedRouteSnapshot) {

        return this.eventService.getEvent(route.params['id']).catch(() => {
            this.router.navigate(['/404']);
            return Observable.of(false)
        });
    }


}