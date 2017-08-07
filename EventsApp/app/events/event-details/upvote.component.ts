import { Component, Input, Output , EventEmitter} from '@angular/core'
import { EventService} from '../shared/event.service'
@Component({
    selector: 'upvote',
    moduleId:'./app/events/event-details/',
    styleUrls: ['./upvote.component.css'],
    template: `
<div class="votingWidgetContainer pointable" (click)="onClick()">
    <div class="votingWidget well">
        <div class="votingButton">
            <li  class="glyphicon glyphicon-heart" [style.color]="iconColor"></li>
           
        </div>
        <div class="badge-inverse badge votingCount">
            <div>
                {{count}}
            </div>
        </div>
    </div>
</div>
`
 
})
export class UpVoteComponent {
    @Input() count: number
    //'based on input value you need to to stuff it can be ngOnChange or input setter'
    @Input() set voted(val) {
        this.iconColor = val ? 'red' : 'white'
        
    }
    iconColor: string 
    @Output() vote = new EventEmitter()
    constructor(private eventService: EventService) {

    }
    onClick() {
        this.vote.emit({})
    }


}
