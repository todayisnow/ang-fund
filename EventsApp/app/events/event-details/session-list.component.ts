
import { Component, Input, OnChanges } from '@angular/core';
import { ISession } from '../shared/index'
import { AuthService } from '../../user/auth.service'
import { VoterService } from './voter.service'


@Component({
    selector: 'session-list',
    moduleId: './app/events/event-details/',
    templateUrl: './session-list.component.html',
    styles: [`
collapsible-well h6 {margin-top:-5px;margin-buttom:10px}
`]
})
export class SessionListComponent implements OnChanges {
    @Input() sessions: ISession[]
    visibleSession: ISession[] = []
    @Input() filterBy: string
    @Input() sortBy: string
    constructor(private auth: AuthService,
        private voterService: VoterService) {
       
    }
    ngOnChanges() { // will be called every time input changes
        if (this.sessions) {
            this.filterSession(this.filterBy)
            this.sortBy === 'name' ? this.visibleSession.sort(sortByNameAsc) : this.visibleSession.sort(sortByVotesDesc)
        }
    }

    filterSession(filter: string) {
        if (filter === 'all')
            this.visibleSession = this.sessions.slice(0) // cloning
        else
            this.visibleSession = this.sessions.filter(session => {
                return session.level.toLocaleLowerCase() === filter;
            })

    }
    toggleVote(session) {
        
        if (this.userHasVoted(session)) {
            this.voterService.deleteVoter(session, this.auth.currentUser.userName)
        }
        else {
            this.voterService.addVoter(session, this.auth.currentUser.userName)
        }
        if (this.sortBy === 'votes') {
            this.visibleSession.sort(sortByVotesDesc)
        }
    }
    userHasVoted(session) {
        return this.voterService.userHasVoted(session, this.auth.currentUser.userName)
    }
}
function sortByNameAsc(s1: ISession, s2: ISession) {
    if (s1.name > s2.name) return 1
    else if (s1.name === s2.name) return 0
    else return -1
}
function sortByVotesDesc(s1: ISession, s2: ISession) {
    return s2.voters.length - s1.voters.length
}
