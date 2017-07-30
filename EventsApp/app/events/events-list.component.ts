import { Component } from '@angular/core'
import {EVENTS } from './mock-events'
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

export class EventsListComponent {
    events = EVENTS
    }

   

