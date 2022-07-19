import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { DataTransferService } from '../DataTransferService';
import { Router } from '@angular/router';

@Component({
  selector: 'app-change-student',
  templateUrl: './change-student.component.html'
})

export class ChangeStudentComponent {
  public changeStudentViewModel: ChangeStudentViewModel;
  done: boolean = false;
  success: boolean | undefined;
  formCompleted: boolean = true;
  myForm = new FormGroup({
    id: new FormControl('', [Validators.required]),
    name: new FormControl('', [Validators.required, Validators.minLength(3)]),
    phoneNumber: new FormControl('', [Validators.required]),
    photo: new FormControl('', [Validators.required]),
    groupID: new FormControl('', [Validators.required])
  });

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, dataTransferService: DataTransferService, private router: Router) {

    http.get<ChangeStudentViewModel>(baseUrl + 'Student/ChangeStudent/' + dataTransferService.studentID).subscribe(result => {
      this.changeStudentViewModel = result;
      this.myForm.patchValue(
        {
          id: this.changeStudentViewModel.id,
          name: this.changeStudentViewModel.name,
          phoneNumber: this.changeStudentViewModel.phoneNumber,
          photo: this.changeStudentViewModel.photo,
          groupID: this.changeStudentViewModel.groupID
        });
    },
      error => console.error(error));
  }

  onFileChange(event: any) {
    const reader = new FileReader();

    if (event.target.files && event.target.files.length) {
      const [file] = event.target.files;
      reader.readAsDataURL(file);

      reader.onload = () => {
        this.myForm.patchValue({ photo: reader.result });
      };
    }
  }
  
  submit() {
    if (this.myForm.controls['name'].value == "" || this.myForm.controls['phoneNumber'].value == null || this.myForm.controls['phoneNumber'].value == 0) {
      this.done = true;
      this.formCompleted = false;
      this.success = false;
    }
    else {
      this.http.put(this.baseUrl + 'Student/ChangeStudent', this.myForm.value).subscribe((data: any) =>
      {
        this.success = data;
        this.done = true;
        this.formCompleted = true;
        if (this.success) {
          setTimeout(() => { this.router.navigate(['/students-list']); }, 1000);
        }
      })
    }
  }

  
}


export class ChangeStudentViewModel {
  constructor(
    public id: number,
    public name: string,
    public phoneNumber: number,
    public photo: string,
    public groupID: number
  ) { };
}
