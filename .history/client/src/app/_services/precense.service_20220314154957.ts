import { Injectable } from '@angular/core';
import { HubConnection } from '@microsoft/signalr';
import { ToastrService } from 'ngx-toastr';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PrecenseService {
  hubUrl = environment.hubUrl;
  private hubConnection: HubConnection;

  constructor(private toatr: ToastrService) { }

  createHubConnection()
}
