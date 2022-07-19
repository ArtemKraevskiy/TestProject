import { Component, Inject, OnInit, OnDestroy } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { DataTransferService } from '../DataTransferService';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  public groups: GroupViewModel[];
  success: boolean = true;

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private dataTransferService: DataTransferService, private router: Router) {
    
    http.get<GroupViewModel[]>(baseUrl + 'Group/ListGroups').subscribe(result => {
      this.groups = result;
    }, error => console.error(error));
  }

  transferGroup(id: number, name: string) {
    this.dataTransferService.groupID = id;
    this.dataTransferService.groupSelected = true;
    this.dataTransferService.groupName = name;
  }

  changeGroup(id: number) {
    this.dataTransferService.groupID = id;
  }

  deleteGroup(id: number) {
    this.dataTransferService.groupID = id;
    this.http.delete(this.baseUrl + 'Group/' + id).subscribe((data: any) => {
      //this.router.navigate(['/']);
      //this.http.get<GroupViewModel[]>(this.baseUrl + 'Group/ListGroups').subscribe(result => {
      //  this.groups = result;
      //}, error => console.error(error));
      this.success = data;
      if (data)
        this.http.get<GroupViewModel[]>(this.baseUrl + 'Group/ListGroups').subscribe(result => { this.groups = result; })
      setTimeout(() => { this.success = true; }, 1000);
    });
  }


}

export class GroupViewModel {
  constructor(
  ) { };
}
