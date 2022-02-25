import { Component, OnInit } from '@angular/core';
import { Message } from '../_models/message';

@Component({
  selector: 'app-messages',
  templateUrl: './messages.component.html',
  styleUrls: ['./messages.component.css']
})
export class MessagesComponent implements OnInit {
  messages: Message[] = [];
  pa
  constructor() { }

  ngOnInit(): void {
  }

}
