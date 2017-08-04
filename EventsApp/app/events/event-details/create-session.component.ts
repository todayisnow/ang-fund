
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms'
import { ISession, EventService,restrictedWords } from '../shared/index'
import { ToastrService } from '../../common/toastr.service'
import { Router } from '@angular/router'
@Component({
    selector: 'create-session',
    moduleId: './app/events/event-details/',
    templateUrl: './create-session.component.html',
    styles: [`
em {float:right; color:#E05C65;padding-left:10px}
.error input, .error select , .error textarea {background-color:#E3C3C5}
.error ::-webkit-input-placeholder {color:#999}
.error ::-moz-placeholder {color:#999}
.error :-moz-placeholder {color:#999}
.error :-ms-input-placeholder {color:#999}


`]
})
export class CreateSessionComponent implements OnInit {

    sessionForm: FormGroup
    name: FormControl
    presenter: FormControl
    duration: FormControl
    level: FormControl
    abstract: FormControl
    constructor(private router: Router,
        private toastr: ToastrService
    ) {

    }
    ngOnInit() {
        this.name = new FormControl('', Validators.required)
        this.presenter = new FormControl('', Validators.required)
        this.duration = new FormControl('', Validators.required)
        this.level = new FormControl('', Validators.required)
        this.abstract = new FormControl('', [Validators.required, Validators.maxLength(400), restrictedWords(['foo', 'BAR'])])
        this.sessionForm = new FormGroup({
            name: this.name,
            presenter: this.presenter,
            duration: this.duration,
            level: this.level,
            abstract: this.abstract
        })
    }
    // custom validator
    //private restrictedWords(control: FormControl): { [key: string]: any } {
        

    //    return control.value.includes('foo') ? { 'restrictedWords': [ 'foo','boo']}:null
    //}
    
    saveSession(formValue) {
        let session: ISession = {
            id: undefined,
            name: formValue.name,
            presenter: formValue.presenter,
            duration: +formValue.duration,
            level: formValue.level,
            abstract: formValue.abstract,
            voters: []
        }
        console.log(session)
        this.toastr.success("Session Saved!!!")
    }
    cancel() {
        this.router.navigate(['/events'])
    }
}
