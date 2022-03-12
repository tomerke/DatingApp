import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/_models/user';
import { AdminService } from 'src/app/_services/admin.service';

@Component({
  selector: 'app-user-managment',
  templateUrl: './user-managment.component.html',
  styleUrls: ['./user-managment.component.css']
})
export class UserManagmentComponent implements OnInit {
  users: Partial<User[]>;

  constructor(private adminService: AdminService, private modalService: BsM) { }

  ngOnInit(): void {
    this.getUsersWithRoles();
  }

getUsersWithRoles(){
  this.adminService.getUserWithRoles().subscribe(users =>{
    this.users = users;
  });
}

}
