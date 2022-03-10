import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, tap } from 'rxjs';
import { ErrorHandling } from '../errorHandling';
import { ChatByGroupNameDto } from '../models/ChatByGroupNameDto';
import { ChatResponse } from '../models/ChatResponse';
import { ServConfig } from '../servconfig';

@Injectable()
export class ChatService extends ErrorHandling {

  constructor( private httpClient :HttpClient) { 
    super () ; 
  }
  path = ServConfig.ApiPath + '/chat';

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
    }),
  };

getChatsByGroupName (groupName:string ) :Observable<ChatResponse[]> {
  let groupNameDto= new ChatByGroupNameDto();
  groupNameDto.groupName=groupName;

 return  this.httpClient
 .post<ChatResponse[]> (this.path+"/GetChatByGroupName",groupNameDto,this.httpOptions)
 .pipe(
    tap(data=>{return this.tapIntercepter(data);}),
    catchError(this.handleError)
 );
}

saveMessage (chat:ChatResponse){

}
}
