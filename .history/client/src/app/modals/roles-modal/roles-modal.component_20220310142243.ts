import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-roles-modal',
  templateUrl: './roles-modal.component.html',
  styleUrls: ['./roles-modal.component.css']
})
export class RolesModalComponent implements OnInit {

  constructor(public bsModalRef: BsMo) { }

  ngOnInit(): void {
  }

}
