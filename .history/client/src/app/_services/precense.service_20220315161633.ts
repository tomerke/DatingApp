import { Injectable } from '@angular/core';
import { HubConnection, HubConnectionBuilder } from '@microsoft/signalr';
import { ToastrService } from 'ngx-toastr';
import { BehaviorSubject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { User } from '../_models/user';

@Injectable({
  providedIn: 'root'
})
export class PrecenseService {
  hubUrl = environment.hubUrl;
  private hubConnection: HubConnection;
  private onlineUsersSource =  new BehaviorSubject<string[]>([]);
  onlineUsers$ = this.onlineUsersSource.asObservable();

  constructor(private toatr: ToastrService) { }

  createHubConnection(user: User){
    this.hubConnection = new HubConnectionBuilder()
    .withUrl(this.hubUrl + 'presence', {
      accessTokenFactory: () => user.token
    })
    .withAutomaticReconnect()
    .build()

    this.hubConnection
    .start()
    .catch(error => console.error(error))

    this.hubConnection.on('UserIsOnline', username => {
      this.toatr.info(username + 'has connected');
    });

    this.hubConnection.on('GetOnlineUsers',  (usernames))

    this.hubConnection.on('UserIsOffline', username => {
      this.toatr.warning(username + 'has disconnected');
    })
  }


  stopHubConnection(){
    this.hubConnection.stop().catch(error => console.log(error));
  }
}
