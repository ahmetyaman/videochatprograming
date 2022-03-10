import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { ErrorHandling } from '../errorHandling';

import { ServConfig } from '../servconfig';
import { AlertifyService } from './alertify.service';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { PersonForLoginDto } from '../models/PersonForLoginDto';
import {  catchError, Observable, tap } from 'rxjs';
import { PersonResponse } from '../models/PersonResponse';

@Injectable()
export class AuthService extends ErrorHandling {
  constructor(
    private httpClient: HttpClient,
    private alertifyService: AlertifyService,
    private router: Router
  ) {
    super();
  }

  path = ServConfig.ApiPath + '/Auth';
  TOKEN_KEY = 'token';
  loggedPerson: PersonResponse;
  TOKEN_STR = '';

  httpHeaders = {
    headers: new HttpHeaders({
      'content-type': 'application/json',
    }),
  };

  private loginPost(loginUser: PersonForLoginDto): Observable<PersonResponse> {
    return this.httpClient
      .post<PersonResponse>(this.path + '/Login', loginUser, this.httpHeaders)
      .pipe(
        tap((data) => {
          return this.tapIntercepter(data);
        }),
        catchError(this.handleError)
      );
  }

  login(loginUser: PersonForLoginDto) {
    this.loginPost(loginUser).subscribe((data) => {
      this.loggedPerson = data;

      this.TOKEN_STR = this.codeDataForToken(this.loggedPerson);
      this.saveToken(this.TOKEN_STR);
    
      this.router.navigateByUrl('/chat-page');

      this.alertifyService.success('You logged in ');
    });
  }

  private codeDataForToken(personData: PersonResponse): string {
    return (
      personData.Id.toString() +
      '#||#' +
      personData.Email +
      '#||#' +
      personData.Name +
      '#||#' +
      personData.SurName +
      '#||#' +
      personData.Password
    );
  }
  decodeTokenData(tokenStr: string): PersonResponse {
    let sep = '#||#';
    let seperatedData = tokenStr.split(sep, 5);

    let person: PersonResponse = new PersonResponse();
    person.Id = Number.parseInt(seperatedData[0]);
    person.Email = seperatedData[1];
    person.Name = seperatedData[2];
    person.SurName = seperatedData[3];
    person.Password = seperatedData[4];

    return person;
  }

  saveToken(token: any) {
    localStorage.setItem(this.TOKEN_KEY, token);
  }
  logOut() {
    localStorage.removeItem(this.TOKEN_KEY);
    this.alertifyService.warning('You logged Out ');
    this.router.navigateByUrl('/login');
  }
  loggedIn() {
    return this.token == undefined ? false : true;
  }
  get token() {
    return localStorage.getItem(this.TOKEN_KEY);
  }

  get currentUserId() {
    if (this.token == null) throw  new Error("There is no token");
    else return this.decodeTokenData(this.token ?? '').Id;
  }
}
