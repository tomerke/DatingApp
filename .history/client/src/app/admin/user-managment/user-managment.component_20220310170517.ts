import { Component, OnInit } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { RolesModalComponent } from 'src/app/modals/roles-modal/roles-modal.component';
import { User } from 'src/app/_models/user';
import { AdminService } from 'src/app/_services/admin.service';

@Component({
  selector: 'app-user-managment',
  templateUrl: './user-managment.component.html',
  styleUrls: ['./user-managment.component.css']
})
export class UserManagmentComponent implements OnInit {
  users: Partial<User[]>;
  bsModalRef: BsModalRef;

  constructor(private adminService: AdminService, private modalService: BsModalService) { }

  ngOnInit(): void {
    this.getUsersWithRoles();
  }

getUsersWithRoles(){
  this.adminService.getUserWithRoles().subscribe(users =>{
    this.users = users;
  });
}

openRolesModal(user: User){
  const config = {
    class: 'modal-dialog-center',
    initialState:{
      user,
      roles
    }
  }

  this.bsModalRef = this.modalService.show(RolesModalComponent, config );
  this.bsModalRef.content.closeBtnName = 'Close';
}

private getRolesArray(user){
const roles = [];
const userRoles = user.roles;
const availableRoles: any[] = [
  {name: 'Admin', value: 'Admin'},
  {name: 'Moderator', value: 'Moderator'},
  {name: 'Member  ', value: 'User'}
]
}

}
