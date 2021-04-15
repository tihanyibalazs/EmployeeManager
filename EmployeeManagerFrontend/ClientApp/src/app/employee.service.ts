import { HttpClient } from '@angular/common/http';
import { Inject } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../environments/environment';
import { Employee } from './employee';

export class EmployeeService {
  private controllerUrl: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.controllerUrl = baseUrl;
  }

  public getEmployees(): Observable<Employee[]> {
    return this.http.get<Employee[]>(this.controllerUrl + 'employeemanagerfrontend/get');
  }

  public addEmployee(employee: Employee): Observable<Employee> {
    return this.http.post<Employee>(this.controllerUrl + 'employeemanagerfrontend/post', employee);
  }

  public updateEmployee(employee: Employee): Observable<Employee> {
    return this.http.put<Employee>(this.controllerUrl + 'employeemanagerfrontend/put', employee);
  }

  public deleteEmployee(employeeId: Number): Observable<void> {
    return this.http.delete<void>(this.controllerUrl + 'employeemanagerfrontend/delete/' + employeeId);
  }
}
