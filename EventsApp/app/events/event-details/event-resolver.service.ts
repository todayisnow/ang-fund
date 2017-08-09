import { Injectable } from '@angular/core'
import { Resolve, ActivatedRouteSnapshot } from '@angular/router'
import { EventService, IEvent } from '../shared/index'

@Injectable()
export class EventResolver implements Resolve<IEvent>{
    constructor(private eventService: EventService) {
    }
    resolve(route: ActivatedRouteSnapshot) {
        
        return this.eventService.getEvent(route.params['id']);
    }


}