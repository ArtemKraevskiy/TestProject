import { Injectable } from "@angular/core";

@Injectable({ providedIn: 'root' })
export class DataTransferService {
  groupID: number;
  groupName: string;
  studentID: number;
  groupSelected: boolean = false;
}
