import { Injectable, EventEmitter } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { Subject } from 'rxjs/Subject';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { IEvent, ISession } from './event.model'; 
@Injectable()

export class EventService {
    events: IEvent[];
    eventsChanges: Subject<IEvent[]> = new Subject < IEvent[] >();
    constructor(private http: Http) { }
    getEvents(): Observable<IEvent[]> {
        return this.http.get('api/events').map((response: Response) => {
            
                this.events = <IEvent[]>response.json();
                this.eventsChanges.next(this.events);
                return this.events;
            
        }).catch(this.handleError);
    }
    getEvent(id: number): Observable<IEvent> {
        return this.http.get('/api/events/' + id).map((response: Response) => {
            return <IEvent>response.json();
        }).catch(this.handleError);
    }
    saveEvent(event): Observable<IEvent> {
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });

        return this.http.post('/api/events', event, options).map((response: Response) => {
            return response.json();
        }).catch(this.handleError);
    }

    searchSessions(searchTerm: string) {
        // var term = searchTerm.toLocaleLowerCase()
        // var result: ISession[] = []
        // EVENTS.forEach(event => {
        //    var matchedSessions = event.sessions.filter(session => session.name.toLocaleLowerCase().indexOf(term) > -1)
            
        //    matchedSessions = matchedSessions.map((session: any) => {
        //        session.eventId = event.id
        //        return session
        //    })
        //   result= result.concat(matchedSessions)
        // })
        
        // var emitter = new EventEmitter(true);
        
        // setTimeout(() => { emitter.emit(result) },100)
        // return emitter
        return this.http.get('/api/sessions/search?search=' + searchTerm).map((response: Response) => {
            return response.json();
        }).catch(this.handleError);
    }
    private handleError(error: Response) {
        return Observable.throw(error.statusText);
    }
}


