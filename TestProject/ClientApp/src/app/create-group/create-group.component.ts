import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-create-group',
  templateUrl: './create-group.component.html'
})
export class CreateGroupComponent {

  public createGroupViewModel: CreateGroupViewModel;
  done: boolean = false;
  success: boolean | undefined;
  formCompleted: boolean = true;
  public group: GroupViewModel = new GroupViewModel(0, "", 0, "", 0, "", 0, "");

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private router: Router) {

    http.get<CreateGroupViewModel>(baseUrl + 'Group/CreateGroup').subscribe(result => {
      this.createGroupViewModel = result;
    },
      error => console.error(error));
  
  }

  //public group: GroupViewModel = new GroupViewModel(0, "", 0, "", 0, "", 0, "");
  submit(group: GroupViewModel) {
    if (group.name == "" || group.year == 0 || group.year == null || group.specialty == "" || group.courseID == 0 || group.teacherID == 0) {
      this.done = true;
      this.formCompleted = false;
      this.success = false;
    }
    else {
      const body = { id: group.id, name: group.name, year: group.year, specialty: group.specialty, teacherID: group.teacherID, courseID: group.courseID };
      this.http.post(this.baseUrl + 'Group/CreateGroup', body).subscribe((data: any) => {
        this.success = data;
        this.done = true;
        this.formCompleted = true;
        if (this.success) {
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

export class CreateGroupViewModel {
  constructor() { };
}

