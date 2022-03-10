import { Component, OnInit } from '@angular/core';

import { AuthService } from 'src/app/services/globalserv/auth.service';
import { ChatService } from 'src/app/services/localserv/chat.service';
import { PersonService } from 'src/app/services/localserv/person.service';
import { ChatResponse } from 'src/app/services/models/ChatResponse';
import { PersonResponse } from 'src/app/services/models/PersonResponse';

@Component({
  selector: 'app-chat-page',
  templateUrl: './chat-page.component.html',
  styleUrls: ['./chat-page.component.css'],
  providers: [PersonService, ChatService],
})
export class ChatPageComponent implements OnInit {
  constructor(
    private personService: PersonService,
    private authService: AuthService,
    private chatService: ChatService
    
  ) {}

  ngOnInit(): void {
    this.getLoggedPerson();
    this.getPersons();
  }

  

  personList: PersonResponse[] = [];
  loggedPerson: PersonResponse = new PersonResponse();
  withChatPerson: PersonResponse = new PersonResponse();
  chats: ChatResponse[] = [];
  getPersons(): void {
    this.personService.getPersons().subscribe((data) => {
      let persons = data;
      persons = persons
        .filter((p) => p.Id !== this.loggedPerson.Id)
        .map((person) => person);
      console.log(JSON.stringify(persons));
      this.personList = persons;
    });
  }
  getLoggedPerson(): void {
    let Id: number = this.authService.currentUserId;
    this.personService.getPersonById(Id).subscribe((data) => {
      this.loggedPerson = data;
    });
  }

  getChatsByGroupName(groupName: string): void {
    this.chatService.getChatsByGroupName(groupName).subscribe((data) => {
      this.chats = data;
    });
  }
  OnListTabPersonClick(person: PersonResponse) {
    this.chats = [];
    this.withChatPerson = person;
    let chatGroupName = this.getChatGroupName(
      this.loggedPerson,
      this.withChatPerson
    );

    this.getChatsByGroupName(chatGroupName);
  }
  getChatGroupName(
    callerPerson: PersonResponse,
    replierPerson: PersonResponse
  ): string {
    return callerPerson.Id.toString() + '#||#' + replierPerson.Id.toString();
  }

  messageText:string
  OnSaveMessage(){
    let chat:ChatResponse=new ChatResponse();
    chat.GroupId=this.getChatGroupName(
      this.loggedPerson,
      this.withChatPerson
    );
    chat.Message=this.messageText;
    chat.SendDate= new Date();
    chat.SenderId=this.loggedPerson.Id;
    
    
//this.chatService.saveMessage(chat).subscribe(data=>{});
  }
}
