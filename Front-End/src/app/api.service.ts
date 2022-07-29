import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { EmployeeActivity } from '../app/model/EmployeeActivity';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private http: HttpClient) { }

  getActivities() {
    return this.http.get<any>('https://localhost:7058/api/activities');
  }

  getActivitySignUps(actId : number) {
    return this.http.get<any>(`https://localhost:7058/api/EmployeeActivities?activityId=${actId}`)
  }

  postSignUp(data : EmployeeActivity) {
    return this.http.post<any>('https://localhost:7058/api/EmployeeActivities', data);
  }
}
