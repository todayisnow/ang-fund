import { Component, OnInit, Inject } from '@angular/core'
import { ActivatedRoute } from '@angular/router'
import { EventService, IEvent } from './shared/index'
import { TOASTR_TOCKEN, Toastr  } from '../common/toastr.service'

@Component({
    selector: 'events-list',
    template: `
            <div>
                <h1>Upcoming Angular 2 Events</h1>
                <hr />
                <div class="row">
                    <div class="col-md-5" *ngFor="let event of events">
                        <event-thumbnail [event]="event" #thumb (click)="handleThumbnailClick(event.name)"></event-thumbnail>
                    </div>
                </div>
            </div>
`
})

export class EventsListComponent implements OnInit {
    events: IEvent[]
    constructor(
        private eventService: EventService,
        @Inject(TOASTR_TOCKEN) private toastr: Toastr,
        private route: ActivatedRoute
        ) {
    }

    ngOnInit() {
        //this.eventService.getEvents().subscribe(data => this.events = data)
        //this.events = this.eventService.getEvents()
        this.events = this.route.snapshot.data['events']
        
    }

    handleThumbnailClick(data) {
        this.toastrService.success(data)
    }
}

   

