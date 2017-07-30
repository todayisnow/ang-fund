import { Component, Input , Output, EventEmitter} from '@angular/core'


@Component({
    selector: "event-thumbnail",
    styles: [`
.pad-left {margin-left: 10px;}
.well div {color: #bbb;}
.thumbnail {min-height:210px}
.red {color:#300 !important}
.green {color:#030 !important}
.bold { font-weight:bold}
`],
    template: `
            <div class="well hoverwell thumbnail">
                <h2>{{event?.name}}</h2><!--if event is null dont try to bind-->
                <span *ngIf="event?.onlineUrl" class="label label-warning">Online Only</span>
                <div>Date: {{event.date}}</div>
                <div [ngSwitch]="event.time" [ngClass]="getStartTimeClass()" ><!--can be inline and also [ngStyle] is the same {"style":"x===y? '':''",}-->
                    Time {{event.time}}
                    <span *ngSwitchCase= "'8:00 am'">(Early Start)</span>
                    <span *ngSwitchCase= "'10:00 am'">(Late Start)</span>
                    <span *ngSwitchDefault>(Normal Start)</span>
                </div>
                
                <div [class.red]="event.price<700">Price: \${{ event.price }}</div>
                <div *ngIf="event.location">
                    <span>Location: {{event.location.address}}</span>

                    <span class="pad-left">{{event.location.city}}, {{event.location.country}}</span>
                </div>
                <div [hidden]="!event.onlineUrl">
                    Online URL: {{event.onlineUrl}}
                </div>
            </div>
`
})

export class EventThumbnailComponent {
    @Input() event: any

    getStartTimeClass()
    {
        const isEarly = this.event && this.event.time === '8:00 am'
        return { green: isEarly, bold: isEarly }// or return strings or array 

    }
    
}
