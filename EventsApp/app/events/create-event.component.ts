
import { Component } from '@angular/core';
import { Router } from '@angular/router'
@Component({
    selector: 'create-event',
    moduleId: './app/events/',
    templateUrl:'./create-event.component.html'

})
export class CreateEventComponent {
    isDirty: boolean = true;


    constructor(private router:Router) {
        
    }
    cancel() {
        this.router.navigate(['/events'])
    }
    save() {
        this.isDirty = false
    }
}
