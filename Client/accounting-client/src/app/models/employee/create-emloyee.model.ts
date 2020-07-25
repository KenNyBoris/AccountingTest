export class CreateEmployeeModel {
    firstName: string;
    lastName: string;
    salary: number;
    position: CreateEmployeePositionModelViewModel;
    constructor() {
        this.firstName = '';
        this.lastName = '';
        this.position = new CreateEmployeePositionModelViewModel();
        this.salary = 0;
    }
}

export class CreateEmployeePositionModelViewModel {
    id: string;
    appointmentDate: string;
    dismissalDate?: string;
}