import { Component } from '@angular/core';

@Component({
    selector: 'collapsible-well',
    template: `
<div class="well pointable" (click)="toggleContent()">
<h4>
<ng-content select ="[well-title]">
</ng-content>
</h4>
<ng-content *ngIf="visable" select="[well-body]">
</ng-content>
</div>
`
})

export class CollapsibleWellComponent {
    
    visable: boolean = true;

    toggleContent() {
        this.visable = !this.visable;

    }

}
