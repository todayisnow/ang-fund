import { Component, OnInit, Inject } from '@angular/core'
import { ActivatedRoute } from '@angular/router'
import { EventService, IEvent } from './shared/index'

@Component({
    selector: 'events-list',
    template: `
            <div>
                <h1>Upcoming Angular 2 Events</h1>
                <hr />
                <div class="row">
                    <div class="col-md-5" *ngFor="let event of events">
                        <event-thumbnail [event]="event" #thumb></event-thumbnail>
                    </div>
                </div>
            </div>
`
})

export class EventsListComponent implements OnInit {
    events: IEvent[]
    constructor(
        private eventService: EventService,
        private route: ActivatedRoute
        ) {

    }

    ngOnInit() {
        //this.eventService.getEvents().subscribe(data => this.events = data)
        //this.events = this.eventService.getEvents()
        this.events = this.route.snapshot.data['events']

    }

   
}

   

