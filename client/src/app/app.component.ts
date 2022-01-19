<<<<<<< HEAD
import { Component } from '@angular/core';
=======
import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
>>>>>>> 9dab8948417adb7099fcfff67c50022f7bd167f6

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
<<<<<<< HEAD
export class AppComponent {
  title = 'DatingAPp';
=======
export class AppComponent implements OnInit{
  title = 'The Dating App';
  users: any;
  constructor(private httpClient: HttpClient){
  }

  ngOnInit() {
    this.getUsers();
  }

  getUsers(){
    this.httpClient.get('https://localhost:5001/api/users').subscribe(response =>{
      this.users = response;
    }, error => {
      console.log(error);
    });
  }
>>>>>>> 9dab8948417adb7099fcfff67c50022f7bd167f6
}
