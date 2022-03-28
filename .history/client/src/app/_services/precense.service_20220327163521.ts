import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { HubConnection, HubConnectionBuilder } from '@microsoft/signalr';
import { ToastrService } from 'ngx-toastr';
import { BehaviorSubject } from 'rxjs';
import { take } from 'rxjs/operators';
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

  constructor(private toatr: ToastrService, private router: Router) { }

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

    this.hubConnection.on('GetOnlineUsers',  (usernames: string[]) =>{
      this.onlineUsersSource.next(usernames);
    });

    this.hubConnection.on('UserIsOffline', username => {
      this.toatr.warning(username + 'has disconnected');
    })

    this.hubConnection.on('NewMessageReceived', ({username, knowAs}) => {
      this.toatr.info(knowAs + ' has sent u a new message!').onTap
      .pipe(take(1))
      .subscribe(() => this.router.navigateByUrl(/))
    })
  }


  stopHubConnection(){
    this.hubConnection.stop().catch(error => console.log(error));
  }
}
