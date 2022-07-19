import { Component, Inject, OnInit, DoCheck } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { strict } from 'assert';
import { DataTransferService } from '../DataTransferService';
import { Router } from '@angular/router';

@Component({
  selector: 'app-change-group',
  templateUrl: './change-group.component.html'
})
export class ChangeGroupComponent {

  public changeGroupViewModel: ChangeGroupViewModel;
  done: boolean = false;
  formCompleted: boolean = true;
  success: boolean | undefined;
  public group: GroupViewModel = new GroupViewModel(0, "", 0, "", 0, "", 0, "");

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, dataTransferService: DataTransferService, private router: Router) {

    http.get<ChangeGroupViewModel>(baseUrl + 'Group/ChangeGroup/' + dataTransferService.groupID).subscribe(result => {
      this.changeGroupViewModel = result;
      this.group.id = this.changeGroupViewModel.id;
      this.group.name = this.changeGroupViewModel.name;
      this.group.year = this.changeGroupViewModel.year;
      this.group.specialty = this.changeGroupViewModel.specialty;
      this.group.teacherID = this.changeGroupViewModel.teacherID;
      this.group.courseID = this.changeGroupViewModel.courseID;
    },
      error => console.error(error));

  }

  submit(group: GroupViewModel) {
    if (group.name == "" || group.year == 0 || group.year == null || group.specialty == "") {
      this.done = true;
      this.formCompleted = false;
      this.success = false;
    }
    else {
      const body = { id: group.id, name: group.name, year: group.year, specialty: group.specialty, teacherID: group.teacherID, courseID: group.courseID };
      this.http.put(this.baseUrl + 'Group/ChangeGroup', body).subscribe((data: any) =>
      {
        this.success = data;
        this.done = true;
        this.formCompleted = true;
        if (this.success)
        {
          setTimeout(() => { this.router.navigate(['/']); }, 1000);
        }
      });
    }
  }

}

export class GroupViewModel {
  constructor(
    public id: number,
    public name: string,
    public year: number,
    public specialty: string,
    public teacherID: number,
    public teacher: string,
    public courseID: number,
    public course: string
  ) { };
}

export class ChangeGroupViewModel {
  constructor(
    public id: number,
    public name: string,
    public year: number,
    public specialty: string,
    public teacherID: number,
    public courseID: number
  ) { };
}
