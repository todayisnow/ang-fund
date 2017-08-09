import { Component,OnInit } from '@angular/core' 
import { AuthService } from '../user/auth.service'
import { ISession } from '../events/shared/index'
import { EventService, IEvent } from '../events/index'
@Component({
    selector: 'nav-bar',
    moduleId: './app/nav/',
    templateUrl: './nav-bar.component.html',
    styles: [`
     li > a.active {color: #F97924}
    .nav.navbar-nav {font-size: 15px;}
    #searchForm {margin-right: 100ppx;}
    @media (max-width: 1200px) {#searchForm {display:none}}
`]
})

export class NavBarComponent implements OnInit {
    searchTerm: string = ""
    events :IEvent[]
    foundSession:ISession[] =[]
    constructor(private auth: AuthService,
        private eventService: EventService
        )
    {

    }
    searchSessions(searchTerm)
    {
   
        this.eventService.searchSessions(searchTerm).subscribe(sessions => {
            this.foundSession = sessions
        })
        
    }
    ngOnInit() {
        this.eventService.eventsChanges.subscribe(events => this.events = events)
    }
   

}