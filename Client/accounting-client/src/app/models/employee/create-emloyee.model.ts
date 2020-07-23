export class CreateEmployeeModel {
    firstName: string;
    lastName: string;
    salary: number;
    appointmentDate: string;
    positionId: string;
    dismissalDate?: string;
    constructor() {
        this.firstName = '';
        this.lastName = '';
        this.positionId = '';
        this.salary = 0;
    }
}