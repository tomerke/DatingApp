import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Member } from 'src/app/_models/member';
import { Pagination } from 'src/app/_models/pagination';
import { UserParams } from 'src/app/_models/userParams';
import { MembersService } from 'src/app/_services/members.service';

@Component({
  selector: 'app-member-list',
  templateUrl: './member-list.component.html',
  styleUrls: ['./member-list.component.css']
})
export class MemberListComponent implements OnInit {
  // members$: Observable<Member[]>;
  members: Member[];
  pagination: Pagination;
  userParams: UserParams;

  constructor(private memberService: MembersService) { }

  ngOnInit(): void {
   this. loadMembers();
  }

  loadMembers(){
    this.memberService.getMembers(this.pageNumber, this.pageSize).subscribe(( response =>{
      this.members = response.result;
      this.pagination = response.pagination;
    }));
  }

  pageChanged(event: any){
    this.pageNumber = event.page;
    this. loadMembers();
  }

}
