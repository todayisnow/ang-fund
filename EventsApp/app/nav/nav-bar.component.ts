import { Component } from '@angular/core' 
import { AuthService } from '../user/auth.service'
import { ISession } from '../events/shared/index'
import { EventService } from '../events/index'
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

export class NavBarComponent {
    searchTerm: string = ""
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
}