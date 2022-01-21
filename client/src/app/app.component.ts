import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'DatingApp';
  users: any;
  constructor(private httpClient: HttpClient){
  }


  ngOnInit() {
    this.getUsers();
  }


  getUsers(){
    this.httpClient.get('http://localhost:5000/api/users').subscribe(response =>{
      this.users = response;
    }, error => {
      console.log(error);
    });
  }
}
