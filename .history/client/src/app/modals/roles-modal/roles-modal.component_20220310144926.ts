import { Component, EventEmitter, OnInit, Input } from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-roles-modal',
  templateUrl: './roles-modal.component.html',
  styleUrls: ['./roles-modal.component.css']
})
export class RolesModalComponent implements OnInit {
@Input() updateSelectedRoles = new EventEmitter();
user: User

  constructor(public bsModalRef: BsModalRef) { }

  ngOnInit(): void {
  }

}