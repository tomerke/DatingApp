import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-test-errors',
  templateUrl: './test-errors.component.html',
  styles: [
  ]
})
export class TestErrorsComponent implements OnInit {
  baseUrl = 'http://localhost:5000/api/';
  validationErrors: string[] = [];

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
  }

  get404Error(){
    this.http.get(this.baseUrl + 'baggy/not-found').subscribe(response =>{
      console.log(response);
    }, error =>{
      console.log(error);
    });
  }
  get400Error(){
    this.http.get(this.baseUrl + 'baggy/bad-request').subscribe(response =>{
      console.log(response);
    }, error =>{
      console.log(error);
    });
  }

  get500Error(){
    this.http.get(this.baseUrl + 'baggy/server-error').subscribe(response =>{
      console.log(response);
    }, error =>{
      console.log(error);
    });
  }

  get401Error(){
    this.http.get(this.baseUrl + 'baggy/auth').subscribe(response =>{
      console.log(response);
    }, error =>{
      console.log(error);
    });

  }
  get400Validation(){
    this.http.post(this.baseUrl + 'account/register', {}).subscribe(response =>{
      console.log(response);
    }, error =>{
      console.log(error);
      this.validationErrors = error;
    });
  }
}
