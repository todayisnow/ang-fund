import { RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { HttpModule} from '@angular/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';// validation ,form, two way binding
import { BrowserModule } from '@angular/platform-browser';
import { EventsAppComponent} from './events-app.component';
import {
    EventsListComponent,
    EventThumbnailComponent,
    CreateEventComponent,  
    CreateSessionComponent,
    SessionListComponent,
    EventDetailsComponent, 
    EventService,
    EventRouteActivator,
    EventListResolver,
    DurationPipe,
    UpVoteComponent,
    VoterService,
    LocationValidator,
    EventResolver
} from './events/index';

import { NavBarComponent } from './nav/nav-bar.component';
import { Error404Component} from './error/404.component';

import {
    TOASTR_TOCKEN,
    Toastr,
    CollapsibleWellComponent,
    JQ_TOCKEN,
    SimpleModalComponent,
    ModalTriggerDirective
} from './common/index';
import { AuthService } from './user/auth.service';

import { appRoutes } from './routes';

declare let toastr: Toastr;
declare let jQuery: Object;

@NgModule({
    imports: [
        BrowserModule,
        FormsModule,
        ReactiveFormsModule,
        RouterModule.forRoot(appRoutes),
        HttpModule
        
    ],
    declarations: [
        EventsAppComponent,
        EventsListComponent,
        EventThumbnailComponent,
        NavBarComponent,
        CreateSessionComponent,
        SessionListComponent,
        EventDetailsComponent,
        CreateEventComponent,
        Error404Component,
        CollapsibleWellComponent,
        DurationPipe,
        ModalTriggerDirective,
        SimpleModalComponent,
        UpVoteComponent,
        LocationValidator
    ],
    providers: [
        EventService,
        {
            provide: TOASTR_TOCKEN,
            useValue: toastr
        },
        EventRouteActivator,
        {
            provide: 'CanDeactivateCreateEvent',
            useValue:chechDirtyState
        },
        {
            provide: JQ_TOCKEN,
            useValue: jQuery
        },
        EventListResolver,
        EventResolver,

        AuthService,
        VoterService
    ],
    bootstrap: [EventsAppComponent]

})

export class AppModule { }

function chechDirtyState(component: CreateEventComponent) {
    
    if (component.isDirty)
        return window.confirm('You have not saved this event, do you really want to cancel?');
    else
        return true;
}