import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, tap } from 'rxjs';
import { ErrorHandling } from '../errorHandling';
import { PersonResponse } from '../models/PersonResponse';
import { ServConfig } from '../servconfig';

@Injectable()
export class PersonService extends ErrorHandling {
  constructor(private httpClient: HttpClient) {
    super();
  }
  path = ServConfig.ApiPath + '/person';

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
    }),
  };

  getPersons(): Observable<PersonResponse[]> {
    return this.httpClient
      .get<PersonResponse[]>(this.path + '/GetAllPerson', this.httpOptions)
      .pipe(
        tap((data) => {
          return this.tapIntercepter(data);
        }),
        catchError(this.handleError)
      );
  }

  getPersonById(Id: number): Observable<PersonResponse> {
    return this.httpClient
      .get<PersonResponse>(
        this.path + '/GetPersonById?Id=' + Id.toString(),
        this.httpOptions
      )
      .pipe(
        tap((data) => {
          return this.tapIntercepter(data);
        }),
        catchError(this.handleError)
      );
  }
}
