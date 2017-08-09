
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router, Params } from '@angular/router'
import { EventService, IEvent, ISession } from '../shared/index'


@Component({
    selector: 'event-details',
    moduleId: './app/events/event-details/',
    templateUrl: './event-details.component.html',
    styles: [`
        .container {padding-left:20px; padding-right:20px}
        .event-image {height:100px;}
        a {cursor: pointer}
`]
})
export class EventDetailsComponent implements OnInit {
    event: IEvent
    addMode: boolean = false
    filterBy: string = 'all'
    sortBy: string = 'votes'
    constructor(private eventService: EventService,
        private route: ActivatedRoute,
        private router: Router
        ) {

    }
    ngOnInit()
    {
        //navigate to the same component need a reset
        this.route.data.forEach((data) => {
            this.event = data['event']
            this.addMode = false
             })
       
        //let id = +this.route.snapshot.params['id']
        //this.event = this.eventService.getEvent(id)
    }
    addSession() {
        this.addMode = true
    }
    cancelSession() {
        this.addMode = false
    }
    saveSession(sessionData: ISession) {
        if (this.event.sessions.length > 0) {
            const nextId = Math.max.apply(null, this.event.sessions.map(s => s.id));
            sessionData.id = nextId + 1
        }
        else
            sessionData.id = 1;
        this.event.sessions.push(sessionData)
        this.eventService.saveEvent(this.event).subscribe(() => {
            this.addMode = false
        })
    }
    
}
