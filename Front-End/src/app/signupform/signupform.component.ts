import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { ApiService } from '../api.service';


// models
import { Employee, EmployeeActivity } from '../model/EmployeeActivity';

@Component({
  selector: 'app-signupform',
  templateUrl: './signupform.component.html',
  styleUrls: ['./signupform.component.css']
})
export class SignupformComponent implements OnInit {
  ActivitiesList : any;
  selectedActivity : string = "";
  FormSubmitted : boolean = false;
  signupForm!: FormGroup;
  ActivitiesSignups : any;

  constructor(private api : ApiService, private http:HttpClient) { }
  
  ngOnInit(): void {
    // get list for dropdown
    this.getActivitiesList();
  }

  getActivitiesList() {
    this.api.getActivities().subscribe(activities => {
      this.ActivitiesList = activities;
    });
  }

  changeActivity(e: any) : void{
    this.selectedActivity = e.target.value;
  }

  submitDataToAcmeApi(employeeActivity : EmployeeActivity) : void {
      this.api.postSignUp(employeeActivity)
        .subscribe({
          next: (res) => {
            this.FormSubmitted = true;
            this.getActivitySignUps(res.ActivityId);
          },
          error:() => {
            alert("An error occured when submitting sign-up form. Please try again.");
          }
        });
  }

  getActivitySignUps(id : number) : void {
    this.api.getActivitySignUps(id).subscribe(signups => {
      this.ActivitiesSignups = signups;
    });
  }

  submit(e: any, data : any) : void {
    e.preventDefault();
    let empl = new Employee(data.firstName, data.lastName, data.email);
    let employeeActivity = new EmployeeActivity(empl, this.selectedActivity, data.coment);
    this.submitDataToAcmeApi(employeeActivity);
  }

}
