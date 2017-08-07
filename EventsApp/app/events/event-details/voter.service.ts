import { Injectable } from '@angular/core'
import { ISession } from '../shared/index'

@Injectable()

export class VoterService {

    addVoter(session: ISession, voterName: string): void {
        session.voters.push(voterName);

    }
    deleteVoter(session: ISession, voterName: string): void {
        //var index = session.voters.indexOf(voterName);
        //if (index > -1) {
        //    session.voters.splice(index, 1);
        //}
        session.voters = session.voters.filter(vote => vote !== voterName)
    }
    userHasVoted(session: ISession, voterName: string): Boolean {
       
        return session.voters.some(m => m === voterName) 
    }
}