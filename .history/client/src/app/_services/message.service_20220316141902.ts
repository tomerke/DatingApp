import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { HubConnection } from '@microsoft/signalr';
import { environment } from 'src/environments/environment';
import { Message } from '../_models/message';
import { User } from '../_models/user';
import { getPaginatedResult, getPaginationHeaders } from './paginationHelper';

@Injectable({
  providedIn: 'root'
})
export class MessageService {
  baseUrl = environment.apiUrl;
  hubUrl = environment.hubUrl;
  private hubConnection: HubConnection;

  constructor(private http: HttpClient) { }

  createHubConnection(user: User, otherUsername: string){
    this.hubConnection = new 
  }

  getMessages(pageNumber: number, pageSize: number, container: string) {
    let params = getPaginationHeaders(pageNumber, pageSize);
    params = params.append('Container', container);
    // console.log('Container ' +JSON.stringify(params))
    return getPaginatedResult<Message[]>(this.baseUrl + 'messages', params, this.http);
  }

  getMessageThread(username: string){
    return this.http.get<Message[]>(this.baseUrl+ 'messages/thread/' + username);
  }

  sendMessage(username: string, content: string){
    return this.http.post<Message>(this.baseUrl + 'messages', {recipientUsername: username, content: content});
  }

  deleteMessage(id: number){
    return this.http.delete(this.baseUrl +'messages/' + id);
  }
}