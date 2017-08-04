import { NgModule } from '@angular/core'
import { BrowserModule } from '@angular/platform-browser'
import { FormsModule, ReactiveFormsModule } from '@angular/forms';//validation ,form, two way binding
import { RouterModule } from '@angular/router';
import { EventsAppComponent} from './events-app.component'
import {
    EventsListComponent,
    EventThumbnailComponent,
    CreateEventComponent,
    CreateSessionComponent,
    SessionListComponent,
    EventDetailsComponent,

    EventService,
    EventRouteActivator,
    EventListResolver
} from './events/index'

import { NavBarComponent } from './nav/nav-bar.component'
import { Error404Component} from './error/404.component'

import { ToastrService } from './common/toastr.service'
import { AuthService } from './user/auth.service'

import { appRoutes } from './routes'



@NgModule({
    imports: [
        BrowserModule,
        FormsModule,
        ReactiveFormsModule,
        RouterModule.forRoot(appRoutes),
        
        
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
        Error404Component
    ],
    providers: [
        EventService,
        ToastrService,
        EventRouteActivator,
        {
            provide: 'CanDeactivateCreateEvent',
            useValue:chechDirtyState
        },
        EventListResolver,
        AuthService
    ],
    bootstrap: [EventsAppComponent]

})

export class AppModule { }

function chechDirtyState(component: CreateEventComponent) {
    
    if (component.isDirty)
        return window.confirm('You have not saved this event, do you really want to cancel?')
    else
        return true
}