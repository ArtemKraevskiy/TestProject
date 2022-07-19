import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { DataTransferService } from '../DataTransferService';
import { group } from '@angular/animations';
import { Router } from '@angular/router';

@Component({
  selector: 'app-students-list',
  templateUrl: './students-list.component.html',
})
export class StudentsListComponent {
  public students: StudentViewModel[];
  groupID: number;

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private dataTransferService: DataTransferService, private router: Router) {
    this.groupID = dataTransferService.groupID;
    http.get<StudentViewModel[]>(baseUrl + 'Student/ListStudents/' + this.groupID).subscribe(result => {
      this.students = result;
    }, error => console.error(error));
  }

  transferStudent(id: number) {
    this.dataTransferService.studentID = id;
  }

  deleteStudent(id: number) {
    this.http.delete(this.baseUrl + 'Student/' + id).subscribe((data) => {
      this.router.navigate(['/students-list']);
    });
  }

}

export class StudentViewModel {
  constructor(
    //public id: number,
    public name: string,
    public phoneNumber: number,
    public photo: string,
    public group: string
    //public teacherID: number,
    //public teacher: string,
    //public courseID: number,
    //public course: string
  ) { };
}
