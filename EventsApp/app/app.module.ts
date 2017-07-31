import { NgModule } from '@angular/core'
import { BrowserModule } from '@angular/platform-browser'
import { FormsModule } from '@angular/forms';//validation ,form, two way binding
import { RouterModule } from '@angular/router';

import { EventsAppComponent } from './events-app.component';
import { EventsListComponent } from './events/events-list.component'
import { EventThumbnailComponent } from './events/event-thumbnail.component'
import { CreateEventComponent } from './events/create-event.component'
import { CreateSessionComponent } from './events/event-details/create-session.component'
import { SessionListComponent } from './events/event-details/session-list.component'
import { EventDetailsComponent } from './events/event-details/event-details.component'
import { NavBarComponent } from './nav/nav-bar.component'
import { Error404Component} from './error/404.component'

import { EventService } from './events/shared/event.service'
import { ToastrService } from './common/toastr.service'

import {appRoutes } from './routes'

@NgModule({
    imports: [BrowserModule, FormsModule, RouterModule.forRoot(appRoutes)],
    declarations: [EventsAppComponent, EventsListComponent, EventThumbnailComponent,
        NavBarComponent, CreateSessionComponent, SessionListComponent, EventDetailsComponent,
        CreateEventComponent, Error404Component],
    providers: [EventService, ToastrService],
    bootstrap: [EventsAppComponent]

})

export class AppModule { }