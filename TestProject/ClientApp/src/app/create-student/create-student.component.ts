import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { DataTransferService } from '../DataTransferService';
import { Router } from '@angular/router';

@Component({
  selector: 'app-create-student',
  templateUrl: './create-student.component.html'
})
export class CreateStudentComponent {

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

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private dataTransferService: DataTransferService, private router: Router) {
    this.myForm.patchValue({ id: 0, name: "", phoneNumber: 0, photo: "", groupID: this.dataTransferService.groupID });
  }


  get f() {
    return this.myForm.controls;
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
    if (this.myForm.controls['name'].value == "" || this.myForm.controls['phoneNumber'].value == "" || this.myForm.controls['phoneNumber'].value == 0 || this.myForm.controls['photo'].value == "")
    {
      this.done = true;
      this.formCompleted = false;
      this.success = false;
    }
    else {
      this.http.post(this.baseUrl + 'Student/CreateStudent', this.myForm.value).subscribe((data: any) => {
        this.success = data;
        this.done = true;
        this.formCompleted = true;
        if (this.success) {
          setTimeout(() => { this.router.navigate(['/students-list']); }, 1000);
        }
      });
    }
  }
}
