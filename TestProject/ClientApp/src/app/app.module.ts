import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CreateGroupComponent } from './create-group/create-group.component';
import { StudentsListComponent } from './students-list/students-list.component';
import { DataTransferService } from './DataTransferService';
import { ChangeGroupComponent } from './change-group/change-group.component';
import { CreateStudentComponent } from './create-student/create-student.component';
import { ChangeStudentComponent } from './change-student/change-student.component'

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CreateGroupComponent,
    StudentsListComponent,
    ChangeGroupComponent,
    CreateStudentComponent,
    ChangeStudentComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      //{ path: '', component: HomeComponent, pathMatch: 'full' },
      { path: '', component: HomeComponent },
      { path: 'create-group', component: CreateGroupComponent },
      { path: 'students-list', component: StudentsListComponent },
      { path: 'change-group', component: ChangeGroupComponent },
      { path: 'create-student', component: CreateStudentComponent },
      { path: 'change-student', component: ChangeStudentComponent }
    ])
  ],
  providers: [
    DataTransferService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
