import { CanActivate, ActivatedRouteSnapshot, Router } from '@angular/router'
import { Injectable } from '@angular/core'
import { EventService } from '../shared/event.service'
import 'rxjs/add/operator/catch';
@Injectable()

export class EventRouteActivator implements CanActivate {
    constructor(private eventService:EventService,private router:Router) {

    }
    canActivate(route: ActivatedRouteSnapshot) {
        let id = +route.params['id'];
        if (isNaN(id) || id < 1) {
            // start a new navigation to redirect to list page
            this.router.navigate(['/404']);
            // abort current navigation
            return false;
        };
        this.eventService.getEvent(id).subscribe((events) => {

            return true
        }, error => {
            this.router.navigate(['/404'])
            return false
        })
        
    }
}