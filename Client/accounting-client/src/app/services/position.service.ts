import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { GetAllPositionsModel } from '../models/position/get-all-positions.model';
import { Observable } from 'rxjs';
import { CreatePositionModel } from '../models/position/create-position.model';

@Injectable({
  providedIn: 'root'
})
export class PositionService {


  private apiUrl: string = environment.apiUrl;
  constructor(private httpClient: HttpClient) {
  }

  getAll(): Observable<GetAllPositionsModel[]> {
    return this.httpClient.get<GetAllPositionsModel[]>(this.apiUrl + 'Position/get-all');
  }

  create(model: CreatePositionModel): Observable<void> {
    return this.httpClient.post<void>(this.apiUrl + 'Position/create', model);
  }
}

