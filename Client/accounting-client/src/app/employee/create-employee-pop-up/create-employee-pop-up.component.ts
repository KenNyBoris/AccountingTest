import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { GetAllPositionsModel } from 'src/app/models/position/get-all-positions.model';
import { forkJoin, Observable } from 'rxjs';
import { PositionService } from 'src/app/services/position.service';
import { CreateEmployeeModel } from 'src/app/models/employee/create-emloyee.model';

@Component({
  selector: 'app-create-employee-pop-up',
  templateUrl: './create-employee-pop-up.component.html',
  styleUrls: ['./create-employee-pop-up.component.scss']
})
export class CreateEmployeePopUpComponent implements OnInit {

  constructor(private dialogRef: MatDialogRef<CreateEmployeePopUpComponent>,
    private positionService: PositionService) {
    this.positions = [];
    this.employeeModel = new CreateEmployeeModel();
   }
  public createEmployeeForm: FormGroup;
  public positions: GetAllPositionsModel[];
  public employeeModel: CreateEmployeeModel;
  ngOnInit(): void {
    this.getPositions();
    this.initializeForm();
  }

  get getFirstNameControl() {return this.createEmployeeForm.controls.firstName}
  get getLastNameControl() {return this.createEmployeeForm.controls.lastName}
  get getPositionIdControl() {return this.createEmployeeForm.controls.position}
  get getSalaryControl() {return this.createEmployeeForm.controls.salary}
  get getAppointmentDateControl() {return this.createEmployeeForm.controls.appointmentDate}
  get getDismissalDateControl() {return this.createEmployeeForm.controls.dismissalDate}


  getPositions(): void {
    this.positionService.getAll().subscribe(response => {
      this.positions = response;
    })
  }

  private initializeForm() {
    this.createEmployeeForm = new FormGroup({
      firstName: new FormControl(this.employeeModel.firstName, Validators.required),
      lastName: new FormControl(this.employeeModel.lastName, Validators.required),
      position: new FormControl('', Validators.required),
      salary: new FormControl(this.employeeModel.salary, [Validators.required, Validators.min(199)]),
      appointmentDate: new FormControl(this.employeeModel.position.appointmentDate, Validators.required),
      dismissalDate: new FormControl(this.employeeModel.position.dismissalDate)
    });
  }

  createEmployee(): void {
    if(!this.createEmployeeForm.valid) {
      return;
    }
    if(this.getDismissalDateControl.value && this.getDismissalDateControl.value < this.getAppointmentDateControl.value){
      return;
    }
    this.employeeModel.position.appointmentDate = this.getAppointmentDateControl.value;
    this.employeeModel.firstName = this.getFirstNameControl.value;
    this.employeeModel.lastName = this.getLastNameControl.value;
    this.employeeModel.position.id = this.getPositionIdControl.value.id;
    this.employeeModel.salary = this.getSalaryControl.value;
    this.employeeModel.position.dismissalDate = this.getDismissalDateControl.value;
    this.dialogRef.close(this.employeeModel);
  }

  cancel(): void {
    this.dialogRef.close();
  }
}

