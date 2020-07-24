import { Component, OnInit } from '@angular/core';
import { MatButton } from '@angular/material/button';
import { MatTable } from '@angular/material/table';
import { EmployeeService } from '../services/employee.service';
import { GetAllEmployeesModel } from '../models/employee/get-all-employees.model';
import { MatDialogRef } from '@angular/material/dialog/dialog-ref';
import { CreateEmployeePopUpComponent } from './create-employee-pop-up/create-employee-pop-up.component';
import { MatDialog } from '@angular/material/dialog';
import { CreatePositionComponent } from '../position/create-position/create-position.component';
import { PositionService } from '../services/position.service';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.scss']
})
export class EmployeeComponent implements OnInit {
  public employees: GetAllEmployeesModel[];
  columnsToDisplay = ['position', 'name', 'salary', 'appointmentDate', 'dismissalDate'];

  constructor(private employeeService: EmployeeService,
    private positionService: PositionService,
    public dialog: MatDialog) {
    this.employees = [];
   }

  ngOnInit(): void {
    this.getEmployees();
  }

  getEmployees(): void {
    this.employeeService.getAll().subscribe(response => {
      this.employees = response;
    })
  }

  createEmployee(): void {
    let dialogRef = this.dialog.open(CreateEmployeePopUpComponent, {
      height: '350px',
      width: '600px',
    });
    dialogRef.afterClosed().subscribe(response => {
      if(!response) {
        return;
      }
      this.employeeService.create(response).subscribe(employeeId => {
        this.getEmployees();
      })
    })
  }

  createPosition(): void {
    let dialogRef = this.dialog.open(CreatePositionComponent, {
      height: '200px',
      width: '300px',
    });
    dialogRef.afterClosed().subscribe(response => {
      if(!response) {
        return;
      }
      this.positionService.create(response).subscribe();
    })
  }

}
