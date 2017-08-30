import { Component, Input, Inject ,ElementRef,ViewChild} from '@angular/core';
import { JQ_TOCKEN } from './jQuery.service';
@Component({
    selector: 'simple-modal', 
    template: `
<div id="{{elementId}}" class="modal fade" tabindex="-1" #modalContainer >
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal">
                    <span>&times;</span>
                </button>
                <h4 class="modal-title">{{title}}</h4>
            </div>
            <div class="modal-body" (click)="closeModal(modalContainer)">
                <ng-content></ng-content>
            </div>
        </div>
    </div>
</div>
`,
    styles: [`
.modal-body {height:250px;overflow-y:scroll}
`]
})

export class SimpleModalComponent {
    @Input() title: string;
    @Input() elementId: string;
    @Input() closeOnBodyClick: string;
    @ViewChild('modalContainer') containerEl: ElementRef; // hold a dom and Viewchildren if many with the same name and ContentChild if the elemnt inside ng-content
    constructor(@Inject(JQ_TOCKEN) private $: any) {

    }
    closeModal() {
        if (this.closeOnBodyClick.toLocaleLowerCase() === 'true') {
            this.$(this.containerEl.nativeElement).modal('hide');

            // this.$(`#${this.elementId}`).modal('hide')
        }
    }
}
