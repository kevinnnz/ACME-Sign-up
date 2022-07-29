
export class Employee {
    firstName : string;
    lastName : string;
    email : string;

    constructor(firstName : string, lastName : string, email : string) {
        this.firstName = firstName;
        this.lastName = lastName;
        this.email = email;
    }
}

export class EmployeeActivity {
    employee : Employee;
    activityId : string;
    comment : string;
    
    constructor(employee: Employee, activityId: string, comment: string) {
        this.employee = employee;
        this.activityId = activityId;
        this.comment = comment;
    }
}
