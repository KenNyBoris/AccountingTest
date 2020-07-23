import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { GetAllEmployeesModel } from '../models/employee/get-all-employees.model';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { CreateEmployeeModel } from '../models/employee/create-emloyee.model';

@Injectable({
  providedIn: 'root'
})

export class EmployeeService {
  
  private apiUrl: string = environment.apiUrl;
  constructor(private httpClient: HttpClient) {
  }

  create(model: CreateEmployeeModel): Observable<void> {
    return this.httpClient.post<void>(this.apiUrl + 'Employee/create', model);
  }

  getAll(): Observable<GetAllEmployeesModel[]> {
    return this.httpClient.get<GetAllEmployeesModel[]>(this.apiUrl + "Employee/get-all")
  }
}
