import { Component, Input } from '@angular/core'
import { IEvent} from './shared/event.model'

@Component({
    selector: "event-thumbnail",
    moduleId: './app/events/',
    templateUrl:'./event-thumbnail.component.html',
    styles: [`
.pad-left {margin-left: 10px;}
.well div {color: #bbb;}
.thumbnail {min-height:230px}
.red {color:#300 !important}
.green {color:#030 !important}
.bold { font-weight:bold}
`],

})

export class EventThumbnailComponent {
    @Input() event: IEvent

    getStartTimeClass()
    {
        const isEarly = this.event && this.event.time === '8:00 am'
        return { green: isEarly, bold: isEarly }// or return strings or array 

    }
    
}
