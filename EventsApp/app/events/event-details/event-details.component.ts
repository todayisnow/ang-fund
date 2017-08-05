
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router'
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
        let id = +this.route.snapshot.params['id']
        this.event = this.eventService.getEvent(id)
    }
    addSession() {
        this.addMode = true
    }
    cancelSession() {
        this.addMode = false
    }
    saveSession(sessionData: ISession) {
        const nextId = Math.max.apply(null, this.event.sessions.map(m => m.id)) + 1
        sessionData.id = nextId
        this.event.sessions.push(sessionData)
        this.eventService.updateEvent(this.event)
        this.addMode= false
    }
    
}
